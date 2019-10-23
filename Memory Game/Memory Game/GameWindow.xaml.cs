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
            Game.SetGame(game);
            InitializeComponent();
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS, Difficulty.EASY, 16);
            game.SetGrid(grid);
            windowGrid = GameGrid;

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
