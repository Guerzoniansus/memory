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
    /// Interaction logic for WinWindow.xaml
    /// </summary>
    public partial class WinWindow : Window

        
    {

        Game game;

        // Needed to prevent crashes
        bool isClosing;

        GameWindow gameWindow;

        public WinWindow(GameWindow gameWindow)
        {
            InitializeComponent();

            game = Game.GetGame();

            AddText();

            isClosing = false;
            this.gameWindow = gameWindow;
        }

        private void AddText()
        {
            PlayerName.Text = "Player 1 = " + game.GetPlayer1() + Environment.NewLine + "Player 2 = " + game.GetPlayer2() + Environment.NewLine + Environment.NewLine + "Player (X) heeeft gewonnen met (X) aantal punten" ;
          
            // string winner = game.GetWinner();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            isClosing = true;

            MainWindow menu = new MainWindow();
            menu.Show();

            Game.StopMusic();
            gameWindow.Close();
            this.Close();
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

        /// <summary>
        /// Makes sure that if you click outside the window (and the window gets minimized), it actually gets closed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            if (isClosing == false)
            {
                MainWindow menu = new MainWindow();
                menu.Show();

                Game.StopMusic();
                gameWindow.Close();
                Close();
            }
        }
    }
}
