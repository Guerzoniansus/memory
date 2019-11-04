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
    /// Interaction logic for Rules.xaml
    /// </summary>
    public partial class Rules : Window
    {

        Game game;
        public Rules()
        {
            InitializeComponent();

            game = Game.GetGame();

            AddInfo();
        }

        private void AddInfo()
        {
            Information.Text = "The base score for a card match is " + Game.scoreMatchBonus + "." +  Environment.NewLine + Environment.NewLine +
                "You will get an increasingly higher streak bonus if you get multiple matches in a row." + Environment.NewLine + Environment.NewLine +
            "The starting bonus streak score for Easy is " + Game.scoreStreakBonusEasy + " with a maximum of " + Game.scoreStreakMaxEasy + "." +  Environment.NewLine + Environment.NewLine +
            "The starting bonus streak score for Medium is " + Game.scoreStreakBonusMedium + " with a maximum of " + Game.scoreStreakMaxMedium + "." + Environment.NewLine + Environment.NewLine  +
            "The starting bonus streak score for Medium is " + Game.scoreStreakBonusHard + " with a maximum of " + Game.scoreStreakMaxHard + "." + Environment.NewLine + Environment.NewLine ;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            this.Close();
        }

        private void RulesWindow_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyMouseEnterEvent(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = Brushes.LightGray;
        }

        private void MyMouseLeaveEvent(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = Brushes.White;
        }
    }
}
