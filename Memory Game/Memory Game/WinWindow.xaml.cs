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
    /// Interaction logic for WinWindow.xaml
    /// </summary>
    public partial class WinWindow : Window

        
    {

        Game game;

        public WinWindow()
        {
            InitializeComponent();

            game = Game.GetGame();

            AddText();

            
        }

        private void AddText()
        {
            PlayerName.Text = "Player 1 = " + game.GetPlayer1() + Environment.NewLine + "Player 2 = " + game.GetPlayer2() + Environment.NewLine + Environment.NewLine + "Player (X) heeeft gewonnen met (X) aantal punten" ;
          
            // string winner = game.GetWinner();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}