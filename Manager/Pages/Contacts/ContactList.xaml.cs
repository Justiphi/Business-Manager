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
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class ContactList : Page
    {
        private static ContactList instance;

        public static ContactList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContactList();
                }
                return (instance);
            }
        }

        public ContactList()
        {
            InitializeComponent();
        }

        private void MenuB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Menu.Instance);
        }

        private void FilterB_Click(object sender, RoutedEventArgs e)
        {
            Windows.ContactFilter.Instance.Show();
        }

        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            int Selection = this.contactDataGrid.SelectedIndex;
            Status.CurrentEmpId = Selection;
            ContactEdit.Instance.DisplayData();
            this.NavigationService.Navigate(ContactEdit.Instance);
        }

        private void ViewB_Click(object sender, RoutedEventArgs e)
        {
            int Selection = this.contactDataGrid.SelectedIndex;
            Status.CurrentEmpId = Selection;
            ContactBrowse.Instance.DisplayData();
            this.NavigationService.Navigate(ContactBrowse.Instance);
        }

        private void lvDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.contactDataGrid.SelectedIndex != -1)
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
    }
}
