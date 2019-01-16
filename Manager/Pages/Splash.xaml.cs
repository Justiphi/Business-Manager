using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Page
    {
        ConfigClass config;

        private static Splash instance;

        public static Splash Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Splash();
                }
                return (instance);
            }
        }

        public Splash()
        {
            InitializeComponent();
        }

        private void Initialize(object sender, RoutedEventArgs e)
        {
            if(Status.LoadStage == 1)
            {
                config = new ConfigClass();
                status.Content = "Initializing connection to Database...";

                string file;

                file = System.IO.Path.Combine(AppContext.BaseDirectory, "_config.json");

                //ensures _config.json exists
                if (!File.Exists(file))
                {
                    throw new ApplicationException("Unable to locate the _config.json file.");
                }

                //loads configuration from _config.json file into memory
                config = JsonConvert.DeserializeObject<ConfigClass>(File.ReadAllText(file));

                MySQLDb.db.Connect(config.connectionString);
                status.Content = "Ensuring Database is made...";
                MySQLDb.db.Create();
                status.Content = "Checking Companies in Database...";
                Status.CompanyNames = MySQLDb.db.GetCompanies();
                if(Status.CompanyNames.Count == 0)
                {
                    this.NavigationService.Navigate(new Company.AddCompany());
                }
                status.Content = "Done";
                Status.LoadStage = 2;
                this.NavigationService.Navigate(Login.Instance);
            }
            else
            {
                status.Content = $"Setting up interface for {MySQLDb.Load.currentUser.Employee.FirstName} {MySQLDb.Load.currentUser.Employee.LastName}";
                Menu.Instance.CompanyB.Content = MySQLDb.Load.currentCompany.CompanyName;
                Menu.Instance.WelcomeL.Content = $"Welcome Back {MySQLDb.Load.currentUser.Employee.FirstName}!";
                if(MySQLDb.Load.currentUser.AccessLevel <= 2)
                {
                    Pages.Employees.EmpBrowse.Instance.SecretB.IsEnabled = true;
                }
                status.Content = "Loading all Employee entries...";
                Status.AllEmployees = MySQLDb.Load.GetAllEmployees(MySQLDb.Load.currentCompany.CompanyId);
                status.Content = "loading first employee to memory...";
                Status.CurrentEmployee = Status.AllEmployees[0];
                status.Content = "Done";
                this.NavigationService.Navigate(Menu.Instance);
            }
        }
    }
}
