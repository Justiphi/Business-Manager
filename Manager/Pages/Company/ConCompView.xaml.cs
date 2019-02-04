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
    /// Interaction logic for ConCompView.xaml
    /// </summary>
    public partial class ConCompView : Page
    {
        public ConCompView()
        {
            InitializeComponent();
        }

        private void DelB_Click(object sender, RoutedEventArgs e)
        {
            if(contactDataGrid.SelectedIndex != -1)
            {
                MySQLDb.Save.RemoveContact((MySQLDb.Contact)contactDataGrid.SelectedItem);
            }
        }

        private void ViewB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Menu.Instance);
        }
    }
}
