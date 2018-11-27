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

namespace Manager.Pages
{
    /// <summary>
    /// Interaction logic for ObjectList.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private static Menu instance;

        public static Menu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Menu();
                }
                return (instance);
            }
        }

        public Menu()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void EmpBrowseB_Click(object sender, RoutedEventArgs e)
        {
            Employees.EmpBrowse.Instance.DisplayData();
            this.NavigationService.Navigate(Employees.EmpBrowse.Instance);
        }

        private void EmpAdd_Click(object sender, RoutedEventArgs e)
        {
            Status.EmpEditMode = false;
            this.NavigationService.Navigate(Employees.EmpEdit.Instance);
        }

        private void EmpListB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Employees.EmpList.Instance);
        }

        private void ConBrowseB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Contacts.ContactBrowse.Instance);
        }

        private void ConListB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Contacts.ContactList.Instance);
        }

        private void ConAdd_Click(object sender, RoutedEventArgs e)
        {
            Status.ConEditMode = false;
            this.NavigationService.Navigate(Contacts.ContactEdit.Instance);
        }
    }
}
