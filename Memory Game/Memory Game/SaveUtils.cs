using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using YamlDotNet.RepresentationModel;


namespace Memory_Game

{
    public class SaveUtils
    {

        /*
         * memory.yaml formatting:
         * game:
             player1: undefined
             player2: undefined2
             difficulty: undefined
             isMultiplayer: False
             time: 300
             turn: undefined
             amountOfCards: 16
             scorePlayer1: 0
             scorePlayer2: 0
           cards:
             0:
                frontImageUrl: frontTestImage.png
                backImageUrl: backTestImage.png
                flipped: True
                found: False
             1:
                frontImageUrl: frontTestImage.png
                backImageUrl: backTestImage.png
                flipped: False
                found: False
         * 
         */


        /// <summary>
        /// Saves the entire state of the game into memory.yaml
        /// </summary>
        public static void SaveGame()
        {
            // Credit voor de code https://stackoverflow.com/questions/37116684/build-a-yaml-document-dynamically-from-c-sharp

            Game game = Game.GetGame();
            MemoryGrid grid = game.GetGrid();

            // Dit is nodig om het te laten werken
            const string initialContent = "#---\nversion: 1\n";

            // Maak een yaml object
            var sr = new StringReader(initialContent);
            var stream = new YamlStream();
            stream.Load(sr);

            var rootMappingNode = (YamlMappingNode)stream.Documents[0].RootNode;

            // Voeg de game data en grid data toe aan de save file, opgesplitst in 2 methoden om het overzichtelijker te maken
            SaveGameData(rootMappingNode, game);
            SaveGridData(rootMappingNode, grid);

            // Sla het bestand op
            using (TextWriter writer = File.CreateText("memory.yaml")) { 
                stream.Save(writer, false);
                writer.Close();
            }

        }

        private static void SaveGameData(YamlMappingNode rootMappingNode, Game game)
        {
            // Voeg alle game data toe aan rootMappingNode in de yaml file
            var data = new YamlMappingNode();
            data.Add("player1", game.GetPlayer1());
            data.Add("player2", game.GetPlayer2());
            data.Add("difficulty", game.GetDifficulty().ToString().ToLower());
            data.Add("isMultiplayer", game.IsGameMultiplayer().ToString());
            data.Add("time", game.GetTimeLeft().ToString());
            data.Add("turn", game.GetTurn());
            data.Add("amountOfCards", game.GetAmountOfCards().ToString());
            data.Add("scorePlayer1", game.getScore(game.GetPlayer1()).ToString());
            data.Add("scorePlayer2", game.getScore(game.GetPlayer2()).ToString());

            rootMappingNode.Add("game", data);
        }

        private static void SaveGridData(YamlMappingNode rootMappingNode, MemoryGrid grid)
        {
            // Voeg alle card data toe aan rootMappingNode in de yaml file

            List<Card> cards = grid.GetCardsAsList();
            var cardIds = new YamlMappingNode();

            foreach (Card card in cards)
            {
                var cardData = new YamlMappingNode();

                cardData.Add("frontImageUrl", card.GetFrontImageUrl());
                cardData.Add("backImageUrl", card.GetBackImageUrl());
                cardData.Add("flipped", card.IsFlipped().ToString());
                cardData.Add("found", card.IsFound().ToString());

                cardIds.Add(card.getId().ToString(), cardData);
                
            }

            rootMappingNode.Add("cards", cardIds);
        }

        /// <summary>
        /// Loads game data, grid data, and does Game.SetGame() with a new game object
        /// </summary>
        public static void LoadGame()
        {
            // Ik heb dit gebruikt voor deze code https://dotnetfiddle.net/rrR2Bb wat onderdeel is van https://aaubry.net/pages/yamldotnet.html
            // Vraag me niet hoe het werkt, ik weet het ook niet zelfs al ben ik degene die het maakte, het was zo moeilijk en zo veel trial and error en random dingen proberen dat ik ervan wou huilen

            // Check if a save file exists. The try catch is nodig omdat het programma anders crasht als er geen savefile bestaat
            try
            {
              var testinput = File.OpenText("memory.yaml");
              testinput.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File does not exist");
                return;
            }

            // Maak een nieuwe yaml object  

            var input = File.OpenText("memory.yaml");

            var yaml = new YamlStream();
            yaml.Load(input);

            // Laad de game data
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
            var gameData = (YamlMappingNode)mapping.Children[new YamlScalarNode("game")];

            string player1 = gameData.Children[new YamlScalarNode("player1")].ToString();
            string player2 = gameData.Children[new YamlScalarNode("player2")].ToString();
            string difficultyString = gameData.Children[new YamlScalarNode("difficulty")].ToString();
            Difficulty difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), difficultyString, true);
            bool isMultiplayer = Boolean.Parse(gameData.Children[new YamlScalarNode("isMultiplayer")].ToString());
            int time = Convert.ToInt32(gameData.Children[new YamlScalarNode("time")].ToString());
            string turn = gameData.Children[new YamlScalarNode("turn")].ToString();
            int amountOfCards = Convert.ToInt32(gameData.Children[new YamlScalarNode("amountOfCards")].ToString());
            double scorePlayer1 = Convert.ToDouble(gameData.Children[new YamlScalarNode("scorePlayer1")].ToString());
            double scorePlayer2 = Convert.ToDouble(gameData.Children[new YamlScalarNode("scorePlayer2")].ToString());

            // Maak een nieuw Game object
            Game game = new Game();
            game.SetPlayers(player1, player2);
            game.SetDifficulty(difficulty);
            game.SetMultiplayer(isMultiplayer);
            game.SetTime(time);
            game.SetTurn(turn);
            game.SetAmountOfCards(amountOfCards);
            game.SetScore(player1, scorePlayer1);
            game.SetScore(player2, scorePlayer2);

            // Laad de grid en kaart data
            var cardIds = (YamlMappingNode)mapping.Children[new YamlScalarNode("cards")];

            List<Card> cards = new List<Card>();

            for (int id = 0; id < amountOfCards; id++)
            {
                var cardData = (YamlMappingNode)cardIds.Children[new YamlScalarNode(id.ToString())];

                string frontImageUrl = cardData.Children[new YamlScalarNode("frontImageUrl")].ToString();
                string backImageUrl = cardData.Children[new YamlScalarNode("backImageUrl")].ToString();
                bool flipped = Convert.ToBoolean(cardData.Children[new YamlScalarNode("flipped")].ToString());
                bool found = Convert.ToBoolean(cardData.Children[new YamlScalarNode("found")].ToString());

                Card card = new Card(id, frontImageUrl, backImageUrl, flipped, found);
                cards.Add(card);
            }

            int[] size = new int[] { };

            switch (game.GetAmountOfCards())
            {
                case 16:
                    size = new int[] { 4,4};
                    break;
                case 20:
                    size = new int[] { 5, 4 };
                    break;
                case 24:
                    size = new int[] { 6, 4 };
                    break;
                case 28:
                    size = new int[] { 7, 4 };
                    break;
            }

            Game.SetGame(game);
            MemoryGrid grid = new MemoryGrid(GameWindow.getWindowGrid(), size[0], size[1], difficulty, amountOfCards, cards);
            game.SetGrid(grid);
            // Zet de game als de nieuwe game

            // Als je dit niet doet blijft het bestand open in het achtergrond en kan je later weer niet saven
            input.Close();

            // For debugging
            Console.WriteLine("Loaded game data");
            Console.WriteLine("Player 1: " + player1);
            Console.WriteLine("Player 2: " + player2);
            Console.WriteLine("Difficulty " + difficultyString);
            Console.WriteLine("Is Multiplayer: " + isMultiplayer);
            Console.WriteLine("Time: " + time);
            Console.WriteLine("Turn: " + turn);
            Console.WriteLine("Amount of cards: " + amountOfCards);
            Console.WriteLine("Score player 1: " + scorePlayer1);
            Console.WriteLine("Score player 2: " + scorePlayer2);
        } 

    }
}
