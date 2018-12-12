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

namespace Manager.Pages.Contacts
{
    /// <summary>
    /// Interaction logic for ContactBrowse.xaml
    /// </summary>
    public partial class ContactBrowse : Page
    {
        private static ContactBrowse instance;

        public static ContactBrowse Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContactBrowse();
                }
                return (instance);
            }
        }

        public ContactBrowse()
        {
            InitializeComponent();
        }

        private void MenuB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Menu.Instance);
        }

        private void ListB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(ContactList.Instance);
        }

        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            Status.EmpEditMode = true;
            ContactEdit.Instance.DisplayData();
            this.NavigationService.Navigate(ContactEdit.Instance);
        }

        private void PrevB_Click(object sender, RoutedEventArgs e)
        {
            Status.CurrentEmpId--;
            DisplayData();
        }

        private void NextB_Click(object sender, RoutedEventArgs e)
        {
            Status.CurrentEmpId++;
            DisplayData();
        }

        private void SecretB_Click(object sender, RoutedEventArgs e)
        {
            MySQLDb.Secret secret = MySQLDb.Load.GetEmpSecret(Status.CurrentEmpId);
            Windows.Secrets.Instance.EmpNameL.Content = $"{Status.CurrentEmployee.FirstName} {Status.CurrentEmployee.LastName}";
            Windows.Secrets.Instance.IRDL.Content = secret.IRDNo;
            Windows.Secrets.Instance.TaxL.Content = secret.TaxCode;
            Windows.Secrets.Instance.BankL.Content = secret.BankNo;
            Windows.Secrets.Instance.Show();
        }

        private void NotesB_Click(object sender, RoutedEventArgs e)
        {
            if (Status.CurrentEmployee.ImageURL != null)
            {
                Thickness margin = Windows.Notes.Instance.TextGrid.Margin;
                margin.Top = 200;
                Windows.Notes.Instance.TextGrid.Margin = margin;

                Windows.Notes.Instance.EmpImg.Visibility = Visibility.Visible;
                Status.CurrentImage.BeginInit();
                Status.CurrentImage.UriSource = new Uri(Status.CurrentEmployee.ImageURL, UriKind.Absolute);
                Status.CurrentImage.EndInit();
                Windows.Notes.Instance.EmpImg.Source = Status.CurrentImage;
            }
            else
            {
                Windows.Notes.Instance.EmpImg.Visibility = Visibility.Collapsed;

                Thickness margin = Windows.Notes.Instance.TextGrid.Margin;
                margin.Top = 57;
                Windows.Notes.Instance.TextGrid.Margin = margin;
            }
            Windows.Notes.Instance.EmpNameL.Content = $"{Status.CurrentEmployee.FirstName} {Status.CurrentEmployee.LastName}";
            Windows.Notes.Instance.DesL.Content = Status.CurrentEmployee.Description;
            if (Status.AccessLevel == MySQLDb.Load.currentUser.AccessLevel && Status.AccessLevel < 4)
            {
                Windows.Notes.Instance.SNL.Content = Status.CurrentEmployee.StaffNotes;
            }
            else
            {
                Windows.Notes.Instance.SNL.Content = "You do not have a high enough access level to view staff notes";
            }
            Windows.Notes.Instance.Show();
        }

        public void DisplayData()
        {
            Status.CurrentContact = Status.AllContacts[Status.CurrentConId];

            if ((Status.CurrentConId + 1) < Status.AllContacts.Count)
            {
                this.NextB.IsEnabled = true;
            }
            else
            {
                this.NextB.IsEnabled = false;
            }
            if (Status.CurrentConId == 0)
            {
                this.PrevB.IsEnabled = false;
            }
            else
            {
                this.PrevB.IsEnabled = true;
            }

            this.Fname.Content = Status.CurrentContact.FirstName;
            this.LName.Content = Status.CurrentContact.LastName;
            this.Company.Content = Status.CurrentContact.ConComp.CompanyName;
            this.Role.Content = Status.CurrentContact.Role;
            this.Phone.Content = Status.CurrentContact.PhoneNumber;
            this.DOB.Content = Status.CurrentContact.DOB;
            this.Email.Content = Status.CurrentContact.Email;
            this.Region.Content = Status.CurrentContact.Region;
        }

        private void FilterB_Click(object sender, RoutedEventArgs e)
        {
            Status.ListMode = false;
            Windows.EmployeeFilter.Instance.Show();
        }
    }
}
