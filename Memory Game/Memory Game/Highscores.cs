using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace Memory_Game
{
    class Highscores
    {
        // highscores.yaml format: index: Naam-score-difficulty
        //singleplayer:
        //  0: Empty 1-0-easy
        //  1: Empty 2-0-easy
        //  2: Empty 3-0-easy
        //  3: Empty 4-0-easy
        //  4: Empty 5-0-easy
        //multiplayer:
        //  0: Empty 1-0-easy
        //  1: Empty 2-0-easy
        //  2: Empty 3-0-easy
        //  3: Empty 4-0-easy
        //  4: Empty 5-0-easy

        private List<HighscoreData> scoresSingleplayer;
        private List<HighscoreData> scoresMultiplayer;

        private const int totalScores = 5;

        public Highscores()
        {
            scoresSingleplayer = new List<HighscoreData>();
            scoresMultiplayer = new List<HighscoreData>();

            LoadScores();
        }

        ~Highscores()
        {
            //SaveScores();
        }

        public void SaveScores()
        {

            // Credit voor de code https://stackoverflow.com/questions/37116684/build-a-yaml-document-dynamically-from-c-sharp

            // Dit is nodig om het te laten werken
            const string initialContent = "#---\nversion: 1\n";

            // Maak een yaml object
            var sr = new StringReader(initialContent);
            var stream = new YamlStream();
            stream.Load(sr);

            var rootMappingNode = (YamlMappingNode)stream.Documents[0].RootNode;

            // Voeg alle game data toe aan rootMappingNode in de yaml file
            var dataSingleplayer = new YamlMappingNode();
            var dataMultiplayer = new YamlMappingNode();

            // SINGLEPLAYER

            for (int i = 0; i < scoresSingleplayer.Count; i++)
            {
                HighscoreData scoreData = scoresSingleplayer[i];

                string playerName = scoreData.PlayerName;
                string score = Convert.ToString(scoreData.Score);
                string difficulty = scoreData.Difficulty.ToString();

                // Format: index: playerName-score-difficulty | EXAMPLE: 0: Frank-600-easy
                dataSingleplayer.Add(i.ToString(), playerName + "-" + score + "-" + difficulty);
            }

            rootMappingNode.Add("singleplayer", dataSingleplayer);

            // MULTIPLAYER

            for (int i = 0; i < scoresMultiplayer.Count; i++)
            {
                HighscoreData scoreData = scoresMultiplayer[i];

                string playerName = scoreData.PlayerName;
                string score = Convert.ToString(scoreData.Score);
                string difficulty = scoreData.Difficulty.ToString();

                // Format: index: playerName-score-difficulty | EXAMPLE: 0: Frank-600-easy
                dataMultiplayer.Add(i.ToString(), playerName + "-" + score + "-" + difficulty);
            }

            rootMappingNode.Add("multiplayer", dataMultiplayer);

            // Sla het bestand op    

            try
            {
                using (TextWriter writer = File.CreateText("highscores.yaml"))
                {
                    stream.Save(writer, false);
                    writer.Close();
                    Console.WriteLine("Highscores saved");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("WAAAAAAAAAAAAAAA ER IS EEN STOMME IO EXCEPTIE");
            }

        }

        /// <summary>
        /// Takes a player score, compares it to the high scores, and adds it to the list if it's a new high score
        /// </summary>
        /// <param name="newScoreData">A HighscoreData object with the player, score, difficulty, and whether it was single or multiplayer</param>
        public void TryAddNewScore(HighscoreData newScoreData)
        {
            if (newScoreData.IsMultiplayer == false)
            {

                // Loop door alle singleplayer scores
                for (int i = 0; i < totalScores; i++)
                {
                    HighscoreData scoreData = scoresSingleplayer[i];

                    // Als nieuwe score groter is dan score op index i
                    if (newScoreData.Score > scoreData.Score)
                    {
                        // j = total scores-1. j blijft boven de huidge index. j wordt steeds minder. 
                        for (int j = totalScores - 1; j > i; j--)
                        {
                            // Om null pointer exceptions te voorkomen
                            if (j - 1 < 0) continue;

                            // Stel: i = 2. j = 3. 
                            // Dan de score op plek j wordt j - 1. Zo gaat hij van onderaan naar boven, tot de huidige index die vervangen moet worden
                            // .... Ik heb het zelf geschreven en zelfs ik vind het moeilijk te begrijpen. Ik had een verlicht moment
                            scoresSingleplayer[j] = scoresSingleplayer[j - 1];
                        }

                        scoresSingleplayer[i] = newScoreData;

                        break;
                    }
                }
            }

            // Uitleg: zie hierboven
            else if (newScoreData.IsMultiplayer == true)
            {
                for (int i = 0; i < totalScores; i++)
                {
                    HighscoreData scoreData = scoresMultiplayer[i];

                    if (newScoreData.Score > scoreData.Score)
                    {


                        for (int j = totalScores - 1; j > i; j--)
                        {
                            if (j - 1 < 0) continue;

                            scoresMultiplayer[j] = scoresMultiplayer[j - 1];
                        }

                        scoresMultiplayer[i] = newScoreData;

                        break;
                    }
                }
            }

            SaveScores();

            PrintDebugStuff();
        }

        public List<HighscoreData> GetScoresSingleplayer()
        {
            return scoresSingleplayer;
        }

        public List<HighscoreData> GetScoresMultiplayer()
        {
            return scoresMultiplayer;
        }

        public void LoadScores()
        {
            // Ik heb dit gebruikt van deze code https://dotnetfiddle.net/rrR2Bb wat onderdeel is van https://aaubry.net/pages/yamldotnet.html

            // Check if a save file exists. The try catch is nodig omdat het programma anders crasht als er geen savefile bestaat
            // De Close() is nodig omdat hij het bestand anders open blijft en er later dan niet naar gesavet kan worden
            try
            {
                var testinput = File.OpenText("highscores.yaml");
                testinput.Close();
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("File does not exist fwafawfwa");
                return;
            }

            // Maak een nieuwe yaml object  

            var input = File.OpenText("highscores.yaml");

            var yaml = new YamlStream();
            yaml.Load(input);

            // Als je dit niet doet blijft het bestand open in het achtergrond en kan je later weer niet saven
            input.Close();

            // Laad de game data
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
            var singleplayer = (YamlMappingNode)mapping.Children[new YamlScalarNode("singleplayer")];
            var multiplayer = (YamlMappingNode)mapping.Children[new YamlScalarNode("multiplayer")];

            Console.WriteLine("Loading high scores... SINGLE PLAYER");

            // Loop door elke score in de high scores. SINGLE PLAYER
            for (int i = 0; i < totalScores; i++)
            {

                // 0: Empty 1-0-easy. "scoreLine" is dan "Empty 1-0-easy"
                // Format: Naam-score-difficulty
                // scoreLine wordt opgesplitst bij elke - om dan naam, score en difficulty te krijgen
                string scoreLine = singleplayer.Children[new YamlScalarNode(Convert.ToString(i))].ToString();
                string[] scoreLineArray = scoreLine.Split('-');

                string playerName = scoreLineArray[0];
                double playerScore = Convert.ToDouble(scoreLineArray[1]);
                string playerDifficultyString = scoreLineArray[2];
                Difficulty playerDifficulty = (Difficulty)Enum.Parse(typeof(Difficulty), playerDifficultyString, true);

                // Voeg de data toe aan de score lists
                HighscoreData score = new HighscoreData(playerName, playerScore, playerDifficulty, false);
                scoresSingleplayer.Add(score);

                Console.WriteLine(i + ": " + scoreLine);
            }

            Console.WriteLine("Loading high scores... MULTIPLAYER");

            // Loop door elke score in de high scores. MULTIPLAYER
            for (int i = 0; i < totalScores; i++)
            {

                // 0: Empty 1-0-easy. "scoreLine" is dan "Empty 1-0-easy"
                // Format: Naam-score-difficulty
                // scoreLine wordt opgesplitst bij elke - om dan naam, score en difficulty te krijgen
                string scoreLine = multiplayer.Children[new YamlScalarNode(Convert.ToString(i))].ToString();
                string[] scoreLineArray = scoreLine.Split('-');

                string playerName = scoreLineArray[0];
                double playerScore = Convert.ToDouble(scoreLineArray[1]);
                string playerDifficultyString = scoreLineArray[2];
                Difficulty playerDifficulty = (Difficulty)Enum.Parse(typeof(Difficulty), playerDifficultyString, true);

                // Voeg de data toe aan de score lists
                HighscoreData score = new HighscoreData(playerName, playerScore, playerDifficulty, true);
                scoresMultiplayer.Add(score);
                Console.WriteLine(i + ": " + scoreLine);

            }

        }

        /// <summary>
        ///  Print alle scores om te kijken of alles werkt
        /// </summary>
        private void PrintDebugStuff()
        {
            Console.WriteLine("Singleplayer highscores:");

            int i = 1;

            foreach (HighscoreData scoreData in scoresSingleplayer)
            {

                string playerName = scoreData.PlayerName;
                string playerScore = Convert.ToString(scoreData.Score);
                string playerDifficulty = scoreData.Difficulty.ToString();

                Console.WriteLine(i + ". " + playerName + " - " + playerScore + " (" + playerDifficulty + ")");

                i++;
            }

            Console.WriteLine("Multiplayer highscores:");

            i = 1;

            foreach (HighscoreData scoreData in scoresMultiplayer)
            {

                string playerName = scoreData.PlayerName;
                string playerScore = Convert.ToString(scoreData.Score);
                string playerDifficulty = scoreData.Difficulty.ToString();

                Console.WriteLine(i + ". " + playerName + " - " + playerScore + " (" + playerDifficulty + ")");

                i++;
            }
        }

    }

}