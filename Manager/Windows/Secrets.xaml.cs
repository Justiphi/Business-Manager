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
    /// Interaction logic for Secrets.xaml
    /// </summary>
    public partial class Secrets : Window
    {
        private static Secrets instance;
        
        public static Secrets Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Secrets();
                }
                return (instance);
            }
        }

        public Secrets()
        {
            InitializeComponent();
        }

        private void OkB_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
