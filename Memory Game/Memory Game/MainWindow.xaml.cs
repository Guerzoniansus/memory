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
            Game.PlaySound("click");

            // quit knop die ervoor zorgt dat de app afsluit
            Application.Current.Shutdown();
        }

        public void LoadClick(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");

            GameWindow gameWindow = new GameWindow();

            SaveUtils.LoadGame();

            gameWindow.Show();

            this.Close();
        }

        private void Highscore_Click(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");

            // hier moet code komen dat die naar window1 gaat
            //NewGame NewGame = new NewGame();

            //NewGame.Show();

            DifficultyWindow dWindow = new DifficultyWindow();
            dWindow.Show();

            this.Close();

        }

        private void LoadGameClick(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");

            GameWindow GameWindow = new GameWindow();
            SaveUtils.LoadGame();
            GameWindow.Show();

            this.Hide();

        }

        private void MyMouseEnterEvent(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = Brushes.LightGray;
        }

        private void MyMouseLeavevEvent(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = Brushes.White;
        }
    }
}