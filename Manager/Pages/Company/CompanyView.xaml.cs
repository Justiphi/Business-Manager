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
            Status.AllEmployees = MySQLDb.Load.GetAllEmployees(MySQLDb.Load.currentCompany.CompanyId);
            employeeDataGrid.ItemsSource = Status.AllEmployees;
        }
    }
}
