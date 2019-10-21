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
    public partial class MainWindow : Window
    {
        MemoryGrid grid;
        private Grid windowGrid;

        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        Game game;

        public MainWindow()
        {
            game = new Game();
            Game.SetGame(game);
            MainWindow window = this;

            InitializeComponent();
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS, Difficulty.EASY, 16);
            game.SetGrid(grid);
            game.SetGridWindow(window);

            windowGrid = GameGrid;

        }

        /// <summary>
        /// Get the grid of the window
        /// </summary>
        /// <returns>GameGrid</returns>
        public Grid getWindowGrid()
        {
            return windowGrid;
        }

        private void ButtonClickMenu(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonClickReset(object sender, RoutedEventArgs e)
        {

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
