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
    /// Interaction logic for AddCompany.xaml
    /// </summary>
    public partial class AddCompany : Page
    {
        public AddCompany()
        {
            InitializeComponent();
        }

        private void ExitB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveB_Click(object sender, RoutedEventArgs e)
        {
            MySQLDb.Company company = new MySQLDb.Company
            {
                CompanyName = this.CompanyInput.Text,
                Sector = this.SectorInput.Text
            };
            this.NavigationService.Navigate(Employees.EmpEdit.Instance);
        }
    }
}
