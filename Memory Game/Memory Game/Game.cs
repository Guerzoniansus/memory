using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Memory_Game
{
    class Game
    {

        private static Game game;

        // Misschien verschillende tijden per difficulty, 300 seconden = 5 min
        public const int STARTING_TIME = 300;

        // TODO wat constanten voor de score formules

        // TODO getters and setters maken voor alles

        // TODO kiezen welke van de twee we gebruiken:
        private string player1, player2;
        private List<string> players;

        private MemoryGrid memoryGrid;

        private Difficulty difficulty;
        private bool isMultiplayer;
        private int time;
        public string turn; // player name whose turn it is
        private int amountOfCards;

        private MainWindow gridWindow;

        // String = player, double = de score van de player
        private Dictionary<string, double> scores;

        public Game()
        {
            // For debugging purposes, you're supposed to change these yourself somewhere else from user input
            this.player1 = "undefined";
            this.player2 = "undefined2";
            this.difficulty = Difficulty.UNDEFINED;
            this.isMultiplayer = false;
            this.time = STARTING_TIME;
            this.turn = player1;
            this.amountOfCards = 16;
            scores = new Dictionary<string, double>();
            scores.Add(player1, 0);
            scores.Add(player2, 0);
        }

        /// <summary>
        /// Set the static instance of the game object that can be used in other classes
        /// </summary>
        /// <param name="game">The game object to use</param>
        public static void SetGame(Game game)
        {
            Game.game = game;
        }

        /// <summary>
        /// Use Game.GetGame() to get the static object that's the same for every class
        /// </summary>
        /// <returns>The game</returns>
        public static Game GetGame()
        {
            return Game.game;
        }


        public void Reset()
        {
            this.time = STARTING_TIME;
            this.turn = player1;
            scores = new Dictionary<string, double>();
            scores.Add(player1, 0);
            scores.Add(player2, 0);
            memoryGrid.Reset();
        }

        public void SetGrid(MemoryGrid grid)
        {
            this.memoryGrid = grid;
        }

        public MemoryGrid GetGrid()
        {
            return memoryGrid;
        }

        //public void SetGridWindow(MainWindow window)
        //{
        //    this.gridWindow = window;
        //}

        //public MainWindow GetGridWindow()
        //{
        //    return gridWindow;
        //}

        public void SetPlayers(string player1, string player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public double GetScore(string player)
        {
            return scores[player];
        }

        public string GetTurn()
        {
            return turn;
        }

        public void SetTurn(string playerName)
        {
            turn = playerName;
        }

        public void SetScore(string player, double newScore)
        {
            scores[player] = newScore;
        }

        public double getScore(string player)
        {
            return scores[player];
        }

        public void SetMultiplayer(bool isTheGameMultiplayer)
        {
            isMultiplayer = isTheGameMultiplayer;
        }

        public bool IsGameMultiplayer()
        {
            return isMultiplayer;
        }

        public void SetAmountOfCards(int amountOfCards)
        {
            this.amountOfCards = amountOfCards;
        }

        public int GetAmountOfCards()
        {
            return amountOfCards;
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }

        public Difficulty GetDifficulty()
        {
            return difficulty;
        }

        public void SetTime(int newTime)
        {
            time = newTime;
        }

        public int GetTimeLeft()
        {
            return time;
        }

        public string GetPlayer1()
        {
            return player1;
        }

        public string GetPlayer2()
        {
            return player2;
        }

    }
}
