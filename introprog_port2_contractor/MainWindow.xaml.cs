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

            Contractor newContractor = new Contractor(FirstName.Text, LastName.Text, DateOfBirth.Text, int.Parse(HourlyWage.Text));

            contractorService.AddContractor(newContractor);


        }

        private void RemoveContractor_Click(object sender, RoutedEventArgs e)
        {
            Contractor oldContractor = (Contractor)ContractorListbox.SelectedItem;
            contractorService.RemoveContractor(oldContractor);
            ContractorListbox.ItemsSource = contractorService.GetContractors();
        }
    }
}
