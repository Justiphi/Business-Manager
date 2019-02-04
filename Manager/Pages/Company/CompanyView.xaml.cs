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

namespace Manager.Pages.Company
{
    /// <summary>
    /// Interaction logic for CompanyView.xaml
    /// </summary>
    public partial class CompanyView : Page
    {
        private static CompanyView instance;

        public static CompanyView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompanyView();
                }
                return (instance);
            }
        }

        public CompanyView()
        {
            InitializeComponent();
        }

        private void MenuB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Menu.Instance);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();   
        }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(AddConComp.Instance);
        }

        private void DelB_Click(object sender, RoutedEventArgs e)
        {
            if(employeeDataGrid.SelectedIndex != -1)
            {
                MySQLDb.Save.RemoveEmployee((MySQLDb.Employee)employeeDataGrid.SelectedItem);
            }
            if(conCompDataGrid.SelectedIndex != -1)
            {
                MySQLDb.Save.RemoveConComp((MySQLDb.ConComp)conCompDataGrid.SelectedItem);
            }
            Refresh();
        }

        private void ViewB_Click(object sender, RoutedEventArgs e)
        {
            if (employeeDataGrid.SelectedIndex != -1)
            {
                Status.CurrentEmpId = Status.AllEmployees.IndexOf((MySQLDb.Employee)employeeDataGrid.SelectedItem);
                Employees.EmpBrowse.Instance.DisplayData();
                this.NavigationService.Navigate(Employees.EmpBrowse.Instance);
            }
            if (conCompDataGrid.SelectedIndex != -1)
            {
            }
        }

        private void Refresh()
        {
            Status.AllEmployees = MySQLDb.Load.GetAllEmployees(MySQLDb.Load.currentCompany.CompanyId);
            employeeDataGrid.ItemsSource = Status.AllEmployees;
            Status.ContactCompanies = MySQLDb.Load.GetAllConComps(MySQLDb.Load.currentCompany.CompanyId);
            conCompDataGrid.ItemsSource = Status.ContactCompanies;
        }
    }
}
