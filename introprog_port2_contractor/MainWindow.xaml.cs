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
            ContractorAssigned.ItemsSource = contractorService.GetContractors().Where(c => c.IsAssigned == false).ToList();


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
            bool isCompleted = IsCompleted.IsChecked == true;
            Contractor selectedContractor = (Contractor)ContractorAssigned.SelectedItem ;
            List<Contractor> contractors = new List<Contractor>(); 
            if (selectedContractor != null)
                contractors.Add(selectedContractor);
           
            Job newJob = new Job(0, JobTitle.Text, DateTime.Parse(JobDate.Text), int.Parse(Cost.Text), isCompleted , contractors );
            JobService.CreateJob(newJob);
            JobTable.ItemsSource = JobService.GetJobs();
            JobTitle.Clear(); 
            Cost.Clear();
            //ContractorAssigned.SelectedIndex = -1 ;
            IsCompleted.IsChecked = false;
            JobDate.SelectedDate = null ;

            
        }

        private void CompleteJob_Click(object sender, RoutedEventArgs e)
        {
            Job oldJob = (Job)JobTable.SelectedItem ;
            
        }

        private void AssignJob_Click(object sender, RoutedEventArgs e)
        {
            Contractor selectedContractor = (Contractor)ContractorAssigned.SelectedItem;
            Job selectedJob = (Job)JobTable.SelectedItem ;  
            JobService.AssignJob(selectedJob, selectedContractor);
            JobTable.ItemsSource = JobService.GetJobs();


        }

        public string ContractorsDisplay
        {
            get
            {
                if (ContractorsAssigned == null || ContractorsAssigned.Count == 0)
                    return "None";

                return string.Join(", ", ContractorsAssigned.Select(c => $"{c.FirstName} {c.LastName}"));
            }
        }

    }
}
