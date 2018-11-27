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

namespace Manager.Pages.Employees
{
    /// <summary>
    /// Interaction logic for EmpList.xaml
    /// </summary>
    public partial class EmpList : Page
    {
        private static EmpList instance;

        public static EmpList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmpList();
                }
                return (instance);
            }
        }

        public EmpList()
        {
            InitializeComponent();
            Status.AllEmployees = MySQLDb.Load.GetAllEmployees(MySQLDb.Load.currentCompany);
            lvDataBinding.ItemsSource = Status.AllEmployees;
        }

        private void MenuB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Menu.Instance);
        }

        private void ViewB_Click(object sender, RoutedEventArgs e)
        {
            int Selection = this.lvDataBinding.SelectedIndex;
            Status.CurrentEmpId = Selection;
            EmpBrowse.Instance.DisplayData();
            this.NavigationService.Navigate(EmpBrowse.Instance);
        }

        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            int Selection = this.lvDataBinding.SelectedIndex;
            Status.CurrentEmpId = Selection;
            Status.EmpEditMode = true;
            EmpEdit.Instance.DisplayData();
            this.NavigationService.Navigate(EmpEdit.Instance);
        }

        private void lvDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.lvDataBinding.SelectedIndex != -1)
            {
                this.EditB.IsEnabled = true;
                this.ViewB.IsEnabled = true;
            }
            else
            {
                this.EditB.IsEnabled = false;
                this.ViewB.IsEnabled = false;
            }
        }

        private void Initialize(object sender, RoutedEventArgs e)
        {
            this.lvDataBinding.SelectedIndex = -1;
            if (this.lvDataBinding.SelectedIndex != -1)
            {
                this.EditB.IsEnabled = true;
                this.ViewB.IsEnabled = true;
            }
            else
            {
                this.EditB.IsEnabled = false;
                this.ViewB.IsEnabled = false;
            }
        }

        private void FilterB_Click(object sender, RoutedEventArgs e)
        {
            Status.ListMode = true;
            Windows.EmployeeFilter.Instance.Show();
        }

        public void RefreshList()
        {
            this.lvDataBinding.SelectedIndex = -1;
            this.EditB.IsEnabled = false;
            this.ViewB.IsEnabled = false;
            this.lvDataBinding.ItemsSource = Status.AllEmployees;
            this.lvDataBinding.Items.Refresh();
        }
    }
}
