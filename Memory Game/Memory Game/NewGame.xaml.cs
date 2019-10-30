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
            if (Game.GetGame().GetDifficulty(Hard))
            {
                CardAmount.
            }

        }
         
        
        private void SpBtn_Click(Object sender, RoutedEventArgs e)
        {
           // Set game op Singleplayer

            P2Input.Visibility = Visibility.Hidden;
            P2Text.Visibility = Visibility.Hidden;
            Game.GetGame().SetMultiplayer(false);
        }
        private void MpBtn_Click(Object sender, RoutedEventArgs e)
        {
            // Set game op Multiplayer

            P2Input.Visibility = Visibility.Visible;
            P2Text.Visibility = Visibility.Visible;
            Game.GetGame().SetMultiplayer(true);
            
        }

    

        private void ProceedBtn_Click(Object sender, RoutedEventArgs e)
        {
            // Set player Names
            string player1 = P1Input.Text;
            string player2 = P2Input.Text;
            
            // Alleen alphanumerieke input voor player1
            char[] letters = player1.ToCharArray();
            

            foreach (char letter in letters)
            {

                if (!(char.IsLetter(letter)) && (!(char.IsNumber(letter)))){

                    MessageBox.Show("Alleen letters en cijfers, geen speciale tekens!");
                    
                    
                }                                        
                
            }
            // Alleen alphanumerieke input voor player2
            char[] letters2 = player2.ToCharArray();


            foreach (char letter in letters2)
            {

                if (!(char.IsLetter(letter)) && (!(char.IsNumber(letter))))
                {

                    MessageBox.Show("Alleen letters en cijfers, geen speciale tekens!");


                }

            }
           
            // Laat speler 2 naam leeg
            if (player2 == null)
            {
                player2 = "";
            }

            // Set playernames vast
            Game.GetGame().SetPlayers(player1, player2);

            // Set de geselecteerde hoeveelheid kaarten
            string CardAmountString = CardAmount.Text;
            Game.GetGame().SetAmountOfCards(Convert.ToInt32(CardAmountString));

            // Opent het speelveld
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
            this.Close();

        }

        private void BackBtn_Click(Object sender, RoutedEventArgs e)
        {
            // Returned naar het Main Menu

            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            this.Close();

        }
       
       
       
           




    }
}
