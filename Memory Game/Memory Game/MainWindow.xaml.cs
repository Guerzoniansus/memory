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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// test
    /// test 2 joe
    /// test 4
    public partial class MainWindow : Window
    {

        Game game;

        public MainWindow()
        {
            game = new Game();
            Game.SetGame(game);
            InitializeComponent();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            QuitConfirm QuitConfirm = new QuitConfirm();

            QuitConfirm.Show();
            //if (MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    Application.Current.Shutdown();
            //}
        }

        private void Highscore_Click(object sender, RoutedEventArgs e)
        {
            HighscoresWindow HighscoresWindow = new HighscoresWindow();

            HighscoresWindow.Show();

            this.Close();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            // hier moet code komen dat die naar window1 gaat
            NewGame NewGame = new NewGame();

            NewGame.Show();

            this.Close();

        }

        private void LoadGameClick(object sender, RoutedEventArgs e)
        {
         
            GameWindow GameWindow = new GameWindow();
            SaveUtils.LoadGame();
            GameWindow.Show();
           
            this.Close();

        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            Rules Rules = new Rules();
            Rules.Show();

            this.Close();
        }

        private void Hoofdmenu_Click(object sender, RoutedEventArgs e)
        {
            WinWindow WinWindow = new WinWindow();
            WinWindow.Show();

        }
    }
}
