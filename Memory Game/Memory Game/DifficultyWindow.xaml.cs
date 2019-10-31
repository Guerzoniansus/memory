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
        Difficulty difficulty;
        public DifficultyWindow()
        {
            InitializeComponent();
            Checkbox_Easy.IsChecked = true;
            Game.GetGame().SetDifficulty(difficulty);

        }

        
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to quit?");
        }
        public void Button_Click1(object sender, RoutedEventArgs e)
        {

            Game.GetGame().SetDifficulty(difficulty);


            NewGame newgame = new NewGame();
            newgame.Show();
            this.Close();
        }

        private void Closebutton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void CheckBox_Checked_Easy(object sender, RoutedEventArgs e)
        {

         
            Checkbox_Medium.IsChecked = false;
            Checkbox_Hard.IsChecked = false;
           

            difficulty = Difficulty.EASY;
        }

        public void Checkbox_Unchecked_Easy(object sender, RoutedEventArgs e)
        {

            if (Checkbox_Medium.IsChecked == false && Checkbox_Hard.IsChecked == false)
            {
              Checkbox_Easy.IsChecked = true;
            }

            
        }

        public void Checkbox_Unchecked_Medium(object sender, RoutedEventArgs e)
        {
            if (Checkbox_Easy.IsChecked == false && Checkbox_Hard.IsChecked == false)
            {
                Checkbox_Medium.IsChecked = true;
            }
            
        }

        public void Checkbox_Unchecked_Hard(object sender, RoutedEventArgs e)
        {

            if (Checkbox_Easy.IsChecked == false && Checkbox_Medium.IsChecked == false)
            {
                Checkbox_Hard.IsChecked = true;
            }
        }

        public void CheckBox_Checked_Medium(object sender, RoutedEventArgs e)
        {
            
            Checkbox_Easy.IsChecked = false;
            Checkbox_Hard.IsChecked = false;

            difficulty = Difficulty.MEDIUM;

        }

        public void CheckBox_Checked_Hard(object sender, RoutedEventArgs e)
        {

            Checkbox_Easy.IsChecked = false;
            Checkbox_Medium.IsChecked = false;

            difficulty = Difficulty.HARD;

        }

    }
}
