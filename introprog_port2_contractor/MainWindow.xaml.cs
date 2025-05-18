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
            
           

        }

        private void GetContractor_Click(object sender, RoutedEventArgs e)
        {

            ContractorListbox.ItemsSource = contractorService.GetContractors(); 

        }

        private void AddContractor_Click(object sender, RoutedEventArgs e)
        {

            Contractor newContractor = new Contractor(FirstName.Text, LastName.Text, DateTime.Parse(DateOfBirth.Text), int.Parse(HourlyWage.Text));

            contractorService.AddContractor(newContractor);
            ContractorListbox.ItemsSource = contractorService.GetContractors(); 


        }

        private void RemoveContractor_Click(object sender, RoutedEventArgs e)
        {
            Contractor oldContractor = (Contractor)ContractorListbox.SelectedItem;
            contractorService.RemoveContractor(oldContractor);
            ContractorListbox.ItemsSource = contractorService.GetContractors();
        }

        private void ShowJobs_Click(object sender, RoutedEventArgs e)
        {
            ContractorListbox.ItemsSource = JobService.GetJobs();
        }

        private void GetJobs_Click(object sender, RoutedEventArgs e)
        {
            ContractorListbox.ItemsSource = JobService.GetJobs();

        }

        private void CreateJob_Click(object sender, RoutedEventArgs e)
        {
            bool isCompleted = IsCompleted.IsChecked == true;
            Contractor selectedContractor = (Contractor)ContractorListbox.SelectedItem ;

            Job newJob = new Job(JobTitle.Text, DateTime.Parse(JobDate.Text), int.Parse(Cost.Text), isCompleted , selectedContractor );
            JobService.CreateJob(newJob);
            ContractorListbox.ItemsSource = JobService.GetJobs();
            
        }

        private void DeleteJob_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AssignJob_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
