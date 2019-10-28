using System;
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
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        public NewGame()
        {
            InitializeComponent();
            button.Name = "ProceedBtn";
            button.Click += ProceedBtn_Click;
        }
        Button button = new Button();

        private void ProceedBtn_Click(Object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Goed getypt, Leuke namen!");
        }

        private void BackBtn_Click(Object sender, RoutedEventArgs e)
        {

        }
        private void SpBtn_Click(Object sender, RoutedEventArgs e)
        {

        }
        private void MpBtn_Click(Object sender, RoutedEventArgs e)
        {

        }
       

    }
}
