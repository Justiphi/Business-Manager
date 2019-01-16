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
    /// Interaction logic for ContactEdit.xaml
    /// </summary>
    public partial class ContactEdit : Page
    {

        private static ContactEdit instance;

        public static ContactEdit Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContactEdit();
                }
                return (instance);
            }
        }

        public ContactEdit()
        {
            InitializeComponent();
        }

        public void DisplayData()
        {
            Status.CurrentContact = Status.AllContacts[Status.CurrentConId];
            this.Fname.Text = Status.CurrentContact.FirstName;
            this.LName.Text = Status.CurrentContact.LastName;
            this.Region1.Text = Status.CurrentContact.Region;
            this.Role.Text = Status.CurrentContact.Role;
            this.Phone.Text = Status.CurrentContact.PhoneNumber;
            this.DOB.Text = Status.CurrentContact.DOB;
            this.Email.Text = Status.CurrentContact.Email;
            this.CompanyL.SelectedValue = Status.CurrentContact.ConComp.CompanyName;
        }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            MySQLDb.Contact contact = new MySQLDb.Contact {
                FirstName = this.Fname.Text,
                LastName = this.LName.Text,
                Role = this.Role.Text,
                Email = this.Email.Text,
                DOB = this.DOB.Text,
                Region = this.Region1.Text,
                PhoneNumber = this.Phone.Text,
                ImageURL = Windows.NotesEdit.Instance.ImgUrl.Text,
                Description = Windows.NotesEdit.Instance.Des.Text,
                StaffNotes = Windows.NotesEdit.Instance.SNotes.Text
            };

            if (Windows.SecretsEdit.Instance.IsFilled())
            {
                contact.Secret = new MySQLDb.Secret {
                    IRDNo = Windows.SecretsEdit.Instance.IRD.Text,
                    BankNo = Windows.SecretsEdit.Instance.Bank.Text,
                    TaxCode = Windows.SecretsEdit.Instance.Tax.Text
                };
            }


            if (Status.EmpEditMode)
            {
                this.NavigationService.Navigate(ContactBrowse.Instance);
            }
            else
            {
                MySQLDb.Save.AddContact(MySQLDb.Load.currentCompany.CompanyId, (int)this.CompanyL.SelectedValue, contact);
                this.NavigationService.Navigate(Menu.Instance);
            }

            Windows.SecretsEdit.Instance.Reset();
            Windows.NotesEdit.Instance.Reset();
            this.Fname.Text = "";
            this.LName.Text = "";
            this.Region1.Text = "";
            this.Role.Text = "";
            this.Phone.Text = "";
            this.DOB.Text = "";
            this.Email.Text = "";
        }

        private void MenuB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Menu.Instance);
        }

        private void NotesB_Click(object sender, RoutedEventArgs e)
        {
            Windows.NotesEdit.Instance.Show();
        }

        private void SecretB_Click(object sender, RoutedEventArgs e)
        {
            Windows.SecretsEdit.Instance.Show();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Status.ContactCompanies = MySQLDb.Load.GetAllConComps(MySQLDb.Load.currentCompany.CompanyId);
            this.CompanyL.ItemsSource = Status.ContactCompanies;
            this.CompanyL.DisplayMemberPath = "CompanyName";
            this.CompanyL.SelectedValuePath = "ConCompId";
        }
    }
}
