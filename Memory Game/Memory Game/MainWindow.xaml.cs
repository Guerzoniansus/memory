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

        static void MainWindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LWin)
            {
                e.Handled = true;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");

            QuitConfirm QuitConfirm = new QuitConfirm();

            QuitConfirm.Show();
        }

        public void LoadClick(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");

            GameWindow gameWindow = new GameWindow();
            SaveUtils.LoadGame();
            Game.GetGame().SetGameWindow(gameWindow);
            gameWindow.UpdateWindow();
            gameWindow.Show();


            Game.PlayMusic();

            this.Close();
        }

        private void Highscore_Click(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");

            HighscoresWindow HighscoresWindow = new HighscoresWindow();

            HighscoresWindow.Show();

            this.Close();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");

            DifficultyWindow dWindow = new DifficultyWindow();
            dWindow.Show();

            this.Close();

        }

        private void LoadGameClick(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");

            GameWindow gameWindow = new GameWindow();

            SaveUtils.LoadGame();
            Game.GetGame().SetGameWindow(gameWindow);
            gameWindow.Show();
            Game.GetGame().GetGameWindow().UpdateWindow();

            Game.PlayMusic();

            this.Close();

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

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");
            Rules Rules = new Rules();
            Rules.Show();

            this.Close();
        }
    }
}