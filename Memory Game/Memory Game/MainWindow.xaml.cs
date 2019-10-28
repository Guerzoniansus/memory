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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// test.3
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
            // quit knop die ervoor zorgt dat de app afsluit
            Application.Current.Shutdown();
        }

        private void Highscore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            // hier moet code komen dat die naar window1 gaat
            NewGame NewGame = new NewGame();

            NewGame.Show();

            this.Close();

        }
    }
}
