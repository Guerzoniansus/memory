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
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        

        public NewGame()
        {
            InitializeComponent();
         
        }
        string player1 = P1Input.Text;
        string player2 = P2Input.Text;
       
        private void SpBtn_Click(Object sender, RoutedEventArgs e)
        {
           
            P2Input.Visibility = Visibility.Hidden;
            P2Text.Visibility = Visibility.Hidden;
            Game.GetGame().SetMultiplayer(false);
        }
        private void MpBtn_Click(Object sender, RoutedEventArgs e)
        {
            P2Input.Visibility = Visibility.Visible;
            P2Text.Visibility = Visibility.Visible;
            Game.GetGame().SetMultiplayer(true);
            
        }
        
        private void ProceedBtn_Click(Object sender, RoutedEventArgs e)
        {
           Game.GetGame().SetPlayers(player1, player2);
            Game.GetGame().SetAmountOfCards(CardAmount);


            
           GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
            this.Close();
        }

        private void BackBtn_Click(Object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            this.Close();

        }
       
       
       
           




    }
}
