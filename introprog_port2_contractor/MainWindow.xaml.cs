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
            LoadUnassignedContractors();   



        }

        private void GetContractor_Click(object sender, RoutedEventArgs e)
        {

            ContractorTable.ItemsSource = contractorService.GetContractors();


        }

        private void AddContractor_Click(object sender, RoutedEventArgs e)
        {
            // forcing false as contractor to be created without being assigned to the pool
            bool isAssigned = false;
            Contractor newContractor = new Contractor(FirstName.Text, LastName.Text, DateTime.Parse(DateOfBirth.Text), int.Parse(HourlyWage.Text), isAssigned);

            contractorService.AddContractor(newContractor);
            ContractorTable.ItemsSource = contractorService.GetContractors();

        }

        private void RemoveContractor_Click(object sender, RoutedEventArgs e)
        {
            Contractor oldContractor = (Contractor)ContractorTable.SelectedItem;
            contractorService.RemoveContractor(oldContractor);
            ContractorTable.ItemsSource = contractorService.GetContractors();
        }


        private void GetJobs_Click(object sender, RoutedEventArgs e)
        {
            JobTable.ItemsSource = JobService.GetJobs();

        }

        private void CreateJob_Click(object sender, RoutedEventArgs e)
        {
            //bool isCompleted = IsCompleted.IsChecked == true;
            Contractor selectedContractor = (Contractor)ContractorAssigned.SelectedItem ;
            //need to validate if fields are correct
            Job newJob = new Job(0, JobTitle.Text, DateTime.Parse(JobDate.Text), int.Parse(Cost.Text), false , null );
            JobService.CreateJob(newJob);
            JobTable.ItemsSource = JobService.GetJobs();
            JobTitle.Clear(); 
            Cost.Clear();
            //IsCompleted.IsChecked = false;
            JobDate.SelectedDate = null ;

            
        }

        private void CompleteJob_Click(object sender, RoutedEventArgs e)
        {
            Job completedJob = (Job)JobTable.SelectedItem ;
            Contractor oldContractor = (Contractor)completedJob.ContractorAssigned;
            completedJob.Title = completedJob.Title;
            completedJob.Cost = completedJob.Cost;
            completedJob.JobDate = completedJob.JobDate;
            completedJob.Completed = true;
//need to validate if it can be shut
            completedJob.ContractorAssigned.IsAssigned = false;
            completedJob.ContractorAssigned = null;

            RefreshTables();
            LoadUnassignedContractors();

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
    }
}
