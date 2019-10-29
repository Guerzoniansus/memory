using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
 //       if (Difficulty == Hard)
	//{

	//}
       
       
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

        private void P1Input_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ProceedBtn_Click(Object sender, RoutedEventArgs e)
        {

            string player1 = P1Input.Text;
            string player2 = P2Input.Text;

            char[] letters = player1.ToCharArray();
            

            foreach (char letter in letters)
            {

                if (!(char.IsLetter(letter)) && (!(char.IsNumber(letter)))){

                    MessageBox.Show("Alleen letters en cijfers, geen speciale tekens!");                    
                }

            }

            Game.GetGame().SetPlayers(player1, player2);

            string CardAmountString = CardAmount.Text;
            Game.GetGame().SetAmountOfCards(CardAmountString);

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
