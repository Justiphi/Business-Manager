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
        private AddConComp instance;

        public AddConComp Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new AddConComp();
                }
                return instance;
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
                CompanyName = this.CompanyL

            };
            MySQLDb.Save.AddConComp(MySQLDb.Load.currentCompany.CompanyId, company);
        }

        private void ExitB_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
