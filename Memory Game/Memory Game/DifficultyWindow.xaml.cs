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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for DifficultyWindow.xaml
    /// </summary>
    public partial class DifficultyWindow : Window
    {
        public DifficultyWindow()
        {
            InitializeComponent();   
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to quit?");
        }
        public void Button_Click1(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
            this.Close();
        }

        private void Closebutton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Game.GetGame().SetDifficulty(Difficulty.EASY);
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            Game.GetGame().SetDifficulty(Difficulty.MEDIUM);
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            Game.GetGame().SetDifficulty(Difficulty.HARD);
        }

     
    }
}
