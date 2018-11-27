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
    /// Interaction logic for EmpEdit.xaml
    /// </summary>
    public partial class EmpEdit : Page
    {
        private static EmpEdit instance;

        public static EmpEdit Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmpEdit();
                }
                return (instance);
            }
        }

        public EmpEdit()
        {
            InitializeComponent();
        }

        private void NotesB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SecretB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Menu.Instance);
        }

        private void Initialize(object sender, RoutedEventArgs e)
        {
            if (Status.EmpEditMode)
            {
                AddB.Content = "Update";
            }
            else
            {
                AddB.Content = "Add";
            }
        }

        public void DisplayData()
        {
            Status.CurrentEmployee = Status.AllEmployees[Status.CurrentEmpId];
            this.Fname.Text = Status.CurrentEmployee.FirstName;
            this.LName.Text = Status.CurrentEmployee.LastName;
            this.Region.Text = Status.CurrentEmployee.Region;
            this.Role.Text = Status.CurrentEmployee.Role;
            this.Phone.Text = Status.CurrentEmployee.PhoneNumber;
            this.DOB.Text = Status.CurrentEmployee.DOB;
            this.Email.Text = Status.CurrentEmployee.Email;
            this.EContact.Text = Status.CurrentEmployee.EmergencyContact;
        }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            if (Status.EmpEditMode)
            {
                this.NavigationService.Navigate(EmpBrowse.Instance);
            }
            else
            {
                this.NavigationService.Navigate(Menu.Instance);
            }

            this.Fname.Text = "";
            this.LName.Text = "";
            this.Region.Text = "";
            this.Role.Text = "";
            this.Phone.Text = "";
            this.DOB.Text = "";
            this.Email.Text = "";
            this.EContact.Text = "";
        }

        private void LogB_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
