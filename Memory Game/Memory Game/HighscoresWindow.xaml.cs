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
    public class Data
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public string Difficulty { get; set; }

        public int place { get; set; }
    }
    /// <summary>
    /// Interaction logic for Highscores.xaml
    /// </summary>
    public partial class HighscoresWindow : Window
    {
        public HighscoresWindow()
        {
            InitializeComponent();
            ShowScores();
        }







        private void ShowScores()
        {
            Highscores highscores = new Highscores();

            List<HighscoreData> singleplayerScores = highscores.GetScoresSingleplayer();
            List<HighscoreData> multiplayerScores = highscores.GetScoresMultiplayer();

            // dit is single player, moet nog een keer doen voor multiplayer
            int place = 0;
            List<Data> items = new List<Data>();
            for (int i = 0; i < singleplayerScores.Count; i++)
            {

                HighscoreData data = singleplayerScores[i];

                int rank = i + 1; // (je begint bij 0, de 0e plek is dus Rank 1)
                string playerName = data.PlayerName;
                double score = data.Score;
                Difficulty difficulty = data.Difficulty;
                string difficultyString = difficulty.ToString().ToUpper();
                
                place = 1 + place;

                // whatever code je verder zelf nodig hebt om het op het scherm te zetten, je hebt hier de variabelen die je nodig hebt
                // je moet ze nog wel zelf converten naar strings enzo
                // VOORBEELD (als ze strings zijn ipv double en Difficulty)
                // Console.WriteLine(rank+ ". " + playerName + " - " + score+ " (" + difficulty + ")");
                // output: 1. bob - 700 (HARD)



                items.Add(new Data() { place = place , Name = playerName, Score = (int)score, Difficulty = difficultyString });
            }

            lvDataBinding.ItemsSource = items;


            items = new List<Data>();
            place = 0;
            // dit is single player, moet nog een keer doen voor multiplayer
            for (int i = 0; i < multiplayerScores.Count; i++)
            {

                HighscoreData data = multiplayerScores[i];

                int rank = i + 1; // (je begint bij 0, de 0e plek is dus Rank 1)
                string playerName = data.PlayerName;
                double score = data.Score;
                Difficulty difficulty = data.Difficulty;
                string difficultyString = difficulty.ToString().ToUpper();

                place = 1 + place;
                // whatever code je verder zelf nodig hebt om het op het scherm te zetten, je hebt hier de variabelen die je nodig hebt
                // je moet ze nog wel zelf converten naar strings enzo
                // VOORBEELD (als ze strings zijn ipv double en Difficulty)
                // Console.WriteLine(rank+ ". " + playerName + " - " + score+ " (" + difficulty + ")");
                //// output: 1. bob - 700 (HARD)
                items.Add(new Data() { place = place, Name = playerName, Score = (int)score, Difficulty = difficultyString });

            }
            lvDataBinding_Copy.ItemsSource = items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            this.Close();
        }
    }
}
