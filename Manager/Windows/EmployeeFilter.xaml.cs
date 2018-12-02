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
using System.Windows.Shapes;

namespace Manager.Windows
{
    /// <summary>
    /// Interaction logic for EmployeeFilter.xaml
    /// </summary>
    public partial class EmployeeFilter : Window
    {
        private static EmployeeFilter instance;

        public static EmployeeFilter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeFilter();
                }
                return (instance);
            }
        }

        public EmployeeFilter()
        {
            InitializeComponent();
        }

        private void CancelB_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfirmB_Click(object sender, RoutedEventArgs e)
        {
            Status.FilteredEmployees = Status.AllEmployees;
            if(this.NameT.Text != string.Empty && Status.FilteredEmployees.Count != 0)
            {
                Status.FilteredEmployees = Status.FilteredEmployees.Where(x => $"{x.FirstName} {x.LastName}".ToUpper().Contains(this.NameT.Text.ToUpper())).ToList();
            }
            if(this.PosT.Text != string.Empty && Status.FilteredEmployees.Count != 0)
            {
                Status.FilteredEmployees = Status.FilteredEmployees.Where(x => x.Role.ToUpper().Contains(PosT.Text.ToUpper())).ToList();
            }
            if(this.RegT.Text != string.Empty && Status.FilteredEmployees.Count != 0)
            {
                Status.FilteredEmployees = Status.FilteredEmployees.Where(x => x.Region.ToUpper().Contains(this.RegT.Text.ToUpper())).ToList();
            }

            if(Status.FilteredEmployees.Count != 0)
            {
                Status.AllEmployees = Status.FilteredEmployees;
                Status.CurrentEmpId = 0;
                if(Status.ListMode == false)
                {
                    Pages.Employees.EmpBrowse.Instance.DisplayData();
                    MainWindow.Instance.MainFrame.Navigate(Pages.Employees.EmpBrowse.Instance);
                }
                else
                {

                    Pages.Employees.EmpList.Instance.RefreshList();
                    MainWindow.Instance.MainFrame.Navigate(Pages.Employees.EmpList.Instance);
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("No employees found matching these filters");
            }
        }

        private void ResetB_Click(object sender, RoutedEventArgs e)
        {
            Status.AllEmployees = MySQLDb.Load.GetAllEmployees(MySQLDb.Load.currentCompany.CompanyId);
            Status.CurrentEmpId = 0;
            Pages.Employees.EmpBrowse.Instance.DisplayData();
            this.Hide();
            this.RegT.Text = string.Empty;
            this.NameT.Text = string.Empty;
            this.PosT.Text = string.Empty;
            Pages.Employees.EmpList.Instance.RefreshList();
        }
    }
}
