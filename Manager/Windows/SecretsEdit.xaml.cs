﻿using System;
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
    /// Interaction logic for SecretsEdit.xaml
    /// </summary>
    public partial class SecretsEdit : Window
    {
        private static SecretsEdit instance;

        public static SecretsEdit Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SecretsEdit();
                }
                return (instance);
            }
        }

        public SecretsEdit()
        {
            InitializeComponent();
        }

        private void OkB_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public bool IsFilled()
        {
            if(this.Tax.Text.Equals(string.Empty) && this.IRD.Text.Equals(string.Empty) && this.Bank.Text.Equals(string.Empty))
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            Tax.Text = string.Empty;
            Bank.Text = string.Empty;
            IRD.Text = string.Empty;
        }
    }
}
