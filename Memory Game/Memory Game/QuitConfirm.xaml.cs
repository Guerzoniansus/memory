﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for QuitConfirm.xaml
    /// </summary>
    public partial class QuitConfirm : Window
    {
        public QuitConfirm()
        {
            InitializeComponent();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
