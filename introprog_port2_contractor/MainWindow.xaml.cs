using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using introprog_port2_contractor.Services;
using introprog_port2_contractor.Models;

namespace introprog_port2_contractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContractorService contractorService = new ContractorService();
        JobService JobService = new JobService();  
        
        public MainWindow()
        {
            InitializeComponent();     
            // loading here becuase i've pre-created them
            LoadUnassignedContractors();   

        }

        private void GetContractor_Click(object sender, RoutedEventArgs e)
        {
            if (contractorService.GetContractors().Count > 0  )
            {
                ContractorTable.ItemsSource = contractorService.GetContractors();
            }
            else
            {
                MessageBox.Show("There are no contractors in the system. Create one to continue");
            }
        }

        private void AddContractor_Click(object sender, RoutedEventArgs e)
        {
            // forcing false as contractor to be created without being assigned to the pool
            decimal hourlywage;
            DateTime dateofbirth;


            if (!string.IsNullOrEmpty(FirstName.Text) && !string.IsNullOrEmpty(LastName.Text)  && decimal.TryParse(HourlyWage.Text, out hourlywage) && DateTime.TryParse(DateOfBirth.Text, out dateofbirth))
            {
                Contractor newContractor = new Contractor(FirstName.Text, LastName.Text, dateofbirth, hourlywage, false);
                contractorService.AddContractor(newContractor);
                ContractorTable.ItemsSource = contractorService.GetContractors();
            }
            else
            {
                MessageBox.Show($"There's something wrong with the inputs. Please check that" + "\n - First or Last Name are not empty" + "\n - Date of Birth is a valid date" +"\n - Hourly Wage is a number");
            }
        }

        private void RemoveContractor_Click(object sender, RoutedEventArgs e)
        {
            Contractor oldContractor = (Contractor)ContractorTable.SelectedItem;
            contractorService.RemoveContractor(oldContractor);
            ContractorTable.ItemsSource = contractorService.GetContractors();
        }


        private void GetJobs_Click(object sender, RoutedEventArgs e)
        {
            if (JobService.GetJobs().Count > 0) {
                JobTable.ItemsSource = JobService.GetJobs();

            }
            else
            {
                MessageBox.Show("There are no jobs yet. Create one to continue");
            }
        }

        private void CreateJob_Click(object sender, RoutedEventArgs e)
        {

            decimal cost;
            DateTime jobdate;

            if (!string.IsNullOrEmpty(JobTitle.Text)  && decimal.TryParse(Cost.Text, out cost) && DateTime.TryParse(JobDate.Text, out jobdate))
            {
            Job newJob = new Job(JobTitle.Text, jobdate, cost, false , null );
            JobService.CreateJob(newJob);
            JobTable.ItemsSource = JobService.GetJobs();
            JobTitle.Clear(); 
            Cost.Clear();
            JobDate.SelectedDate = null ;

            }
            else
            {
                MessageBox.Show($"There's something wrong with the inputs. Please check that" + "\n - Job has a title" + "\n - Job date is a valid date" + "\n - Cost is a number");
            }            
        }

        private void CompleteJob_Click(object sender, RoutedEventArgs e)
        {
            Job jobtobeClosed = (Job)JobTable.SelectedItem;

            if (jobtobeClosed.Completed == false)
            {
            //Contractor contractortobeUnassigned = (Contractor)jobtobeClosed.ContractorAssigned;
            jobtobeClosed.Title = jobtobeClosed.Title;
            jobtobeClosed.Cost = jobtobeClosed.Cost;
            jobtobeClosed.JobDate = jobtobeClosed.JobDate;
            jobtobeClosed.Completed = true;
            jobtobeClosed.ContractorAssigned.IsAssigned = false;
            jobtobeClosed.ContractorAssigned = null;
            RefreshTables();
            LoadUnassignedContractors();
            }
            else
            {
                MessageBox.Show("Job is already complete and cannot be closed");
            }
        }

        private void AssignJob_Click(object sender, RoutedEventArgs e)
        {
            Contractor selectedContractor = (Contractor)ContractorAssigned.SelectedItem;
            Job selectedJob = (Job)JobTable.SelectedItem ;  
            selectedJob.Title = selectedJob.Title;
            selectedJob.Cost = selectedJob.Cost;
            selectedJob.JobDate = selectedJob.JobDate ;
            selectedJob.Completed = selectedJob.Completed;
            selectedJob.ContractorAssigned = selectedContractor;
            selectedContractor.IsAssigned = true;  
            RefreshTables();    
            LoadUnassignedContractors();   

        }

        public void LoadUnassignedContractors()
        {

            ContractorAssigned.ItemsSource = contractorService.GetContractors().Where(c => c.IsAssigned == false).ToList();
        }

        public void RefreshTables()
        {
            JobTable.ItemsSource = JobService.GetJobs();
            ContractorTable.ItemsSource = contractorService.GetContractors();

        }

        private void ShowOpenJobs_Click(object sender, RoutedEventArgs e)
        {
            JobTable.ItemsSource = JobService.GetJobs().Where(j => j.Completed == false).ToList();
        }

        private void Button_CostSearch_Click(object sender, RoutedEventArgs e)
        {
            JobReporting.ItemsSource = JobService.GetJobs().Where(j => j.Cost >= int.Parse(MinCostSearch.Text) && j.Cost <= int.Parse(MaxCostSearch.Text)).ToList();
        }
    }
}
