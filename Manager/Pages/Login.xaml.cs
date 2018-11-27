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
using MySQLDb;

namespace Manager.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private static Login instance;

        public static Login Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Login();
                }
                return (instance);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Enter();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return && e.Key != Key.Enter)
                return;
            e.Handled = true;
            Enter();
        }

        private void Enter()
        {
            if (this.UserName.Text != string.Empty && this.PassWord.Password != string.Empty)
            {
                bool Test = MySQLDb.Load.CheckLogin(this.UserName.Text, this.PassWord.Password);
                if (Test)
                {
                    Status.AccessLevel = Load.currentUser.AccessLevel;
                    Status.Password = Load.currentUser.Password;
                    Status.UserId = Load.currentUser.UserId;
                    this.NavigationService.Navigate(Splash.Instance);
                }
                else
                {
                    MessageBox.Show("Invalid Username/Password, please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please ensure both fields are filled and try again.");
            }
        }
    }
}
