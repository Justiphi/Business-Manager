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
    /// Interaction logic for NotesEdit.xaml
    /// </summary>
    public partial class NotesEdit : Window
    {
        private static NotesEdit instance;

        public static NotesEdit Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NotesEdit();
                }
                return (instance);
            }
        }

        public NotesEdit()
        {
            InitializeComponent();
        }

        private void OkB_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public bool IsFilled()
        {
            if (this.ImgUrl.Text.Equals(string.Empty) && this.SNotes.Text.Equals(string.Empty) && this.Des.Text.Equals(string.Empty))
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            ImgUrl.Text = string.Empty;
            SNotes.Text = string.Empty;
            Des.Text = string.Empty;
        }
    }
}
