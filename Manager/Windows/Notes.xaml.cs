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
using System.Windows.Shapes;

namespace Manager.Windows
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Window
    {
        public Notes()
        {
            InitializeComponent();
        }

        private static Notes instance;

        public static Notes Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Notes();
                }
                return (instance);
            }
        }

        private void OkB_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
