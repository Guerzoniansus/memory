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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        MemoryGrid grid;
        private static Grid windowGrid;

        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;

        Game game;

        public GameWindow()
        {
            game = new Game();
            game.SetGameWindow(this);
            Game.SetGame(game);     

            InitializeComponent();

            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS, Difficulty.EASY, 16);
            game.SetGrid(grid);
            windowGrid = GameGrid;

            UpdateWindow();

        }

        /// <summary>
        /// Refreshes the players (in case of saving and loading), the scores, the time, and whose turn it is. 
        /// Used when initializing the window and after every turn. 
        /// </summary>
        public void UpdateWindow()
        {
            string player1 = game.GetPlayer1();
            string player2 = game.GetPlayer2();
            string turn = game.GetTurn();

            textPlayer1.Content = player1;
            textPlayer2.Content = game.IsGameMultiplayer() ? player2 : "";

            textPlayer1Score.Content = game.getScore(player1.ToString());
            textPlayer2Score.Content = game.IsGameMultiplayer() ? game.getScore(player2).ToString() : "";

            textTurn.Content = turn + "'s turn";

            TimeSpan t = TimeSpan.FromSeconds(game.GetTimeLeft());
            string time = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);

            textTime.Content = time;

            // Wat code om de difficulty zo te formatten dat alleen de eerste letter een hoofdletter is
            string difficulty = game.GetDifficulty().ToString().ToLower();
            char[] letters = difficulty.ToCharArray();
            char firstletter = letters[0].ToString().ToUpper().ToCharArray()[0]; ;
            letters[0] = firstletter;
            difficulty = new string(letters);

            textDifficulty.Content = "(" + difficulty + ")";
        }

        /// <summary>
        /// Get the grid of the window (aka GameGrid)
        /// </summary>
        /// <returns>GameGrid</returns>
        public static Grid getWindowGrid()
        {
            return windowGrid;
        }

        private void ButtonClickMenu(object sender, RoutedEventArgs e)
        {
            //TODO: game.Pause() or something

            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();

        }
        private void ButtonClickReset(object sender, RoutedEventArgs e)
        {
            game.Reset();
        }

        private void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            SaveUtils.SaveGame();
        }

        private void ButtonClickLoad(object sender, RoutedEventArgs e)
        {
            SaveUtils.LoadGame();

        }
    }
}
