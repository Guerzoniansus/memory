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
            Information.Text = "De basiscore voor een match is " + Game.scoreMatchBonus + Environment.NewLine + Environment.NewLine +
                "Als je meerdere kaarten achter elkaar goed krijgt, krijg je een streak bonus, en in singleplayer krijg je aan het einde van het spel nog een bonus afhankelijk van de tijd die over is." + Environment.NewLine + Environment.NewLine +
            "De bonus score voor easy is " + Game.scoreStreakBonusEasy + " met een maximum van " + Game.scoreStreakMaxEasy + " streakscore met een tijdbonus multiplier van " + Game.scoreTimeBonusEasy +  Environment.NewLine + Environment.NewLine +
            "De bonus score voor medium is " + Game.scoreStreakBonusMedium + " met een maximum van " + Game.scoreStreakMaxMedium + " streakscore met een tijdbonus multiplier van " + Game.scoreTimeBonusMedium +  Environment.NewLine + Environment.NewLine  +
            "De bonus score voor hard is " + Game.scoreStreakBonusHard + " met een maximum van " + Game.scoreStreakMaxHard + " streakscore met een tijdbonus multiplier van " + Game.scoreTimeBonusHard  + Environment.NewLine + Environment.NewLine ;

            // string winner = game.GetWinner();
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
