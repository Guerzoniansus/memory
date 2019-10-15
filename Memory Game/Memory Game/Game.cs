using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        // String = player, double = de score van de player
        private Dictionary<string, double> scores;

        public Game()
        {
            // For debugging purposes, you're supposed to change these yourself somewhere else from user input
            this.player1 = "undefined";
            this.player2 = "undefined";
            this.difficulty = Difficulty.UNDEFINED;
            this.isMultiplayer = false;
            this.time = STARTING_TIME;
            this.turn = player1;
            this.amountOfCards = 16;
        }

        public static void setGame(Game game)
        {
            Game.game = game;
        }

        public static Game getGame()
        {
            return Game.game;
        }

        public void setGrid(MemoryGrid grid)
        {
            this.memoryGrid = grid;
        }

        public void setPlayers(string player1, string player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public double getScore(string player)
        {
            return scores[player];
        }

        public string getTurn()
        {
            return turn;
        }

        public void setTurn(string playerName)
        {
            turn = playerName;
        }

        public void setScore(string player, double newScore)
        {
            scores[player] = newScore;
        }

        public void setMultiplayer(bool isTheGameMultiplayer)
        {
            isMultiplayer = isTheGameMultiplayer;
        }

        public void setDifficulty(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }

        public Difficulty getDifficulty()
        {
            return difficulty;
        }

        public int getTimeLeft()
        {
            return time;
        }

    }
}
