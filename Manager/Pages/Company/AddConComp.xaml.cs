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
    /// Interaction logic for AddConComp.xaml
    /// </summary>
    public partial class AddConComp : Page
    {
        private static AddConComp instance;

        public static AddConComp Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AddConComp();
                }
                return (instance);
            }
        }

        public AddConComp()
        {
            InitializeComponent();
        }

        private void SaveB_Click(object sender, RoutedEventArgs e)
        {
            MySQLDb.ConComp company = new MySQLDb.ConComp
            {
                CompanyName = this.CompanyInput.Text,
                Sector = this.SectorInput.Text,
                StaffNotes = this.StaffNotesInput.Text
            };
            MySQLDb.Save.AddConComp(MySQLDb.Load.currentCompany.CompanyId, company);
            this.NavigationService.Navigate(Menu.Instance);
            resetInput();
        }

        public void resetInput()
        {
            this.CompanyInput.Text = null;
            this.SectorInput.Text = null;
            this.StaffNotesInput.Text = null;
        }

        private void ExitB_Click(object sender, RoutedEventArgs e)
        {
            resetInput();
            this.NavigationService.Navigate(Menu.Instance);
        }
    }
}
