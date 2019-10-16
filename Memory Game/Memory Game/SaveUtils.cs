﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

            SaveGameData(rootMappingNode, game);
            SaveGridData(rootMappingNode, grid);

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
            game.SetGridWindow(Game.GetGame().GetGridWindow());

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


            MemoryGrid grid = new MemoryGrid(Game.GetGame().GetGridWindow().getWindowGrid(), 4, 4, difficulty, amountOfCards, cards);
            game.SetGrid(grid);

            // Zet de game als de nieuwe game
            Game.SetGame(game);

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






























        /// <summary>
        /// Writes the given object instance to an XML file.
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [XmlIgnore] attribute.</para>
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        private static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>
        /// Reads an object instance from an XML file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the XML file.</returns>
        private static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        

    }
}