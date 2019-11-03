using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memory_Game
{
    class HighscoreData
    {

        public string PlayerName { get; private set; }
        public double Score { get; private set; }

        public Difficulty Difficulty { get; private set; }

        public bool IsMultiplayer { get; private set; }

        /// <summary>
        /// A HighscoreData object can be used by the Highscores class to give high score data
        /// </summary>
        /// <param name="playerName">Name of the player</param>
        /// <param name="score">Score the player got</param>
        /// <param name="difficultty">Difficulty the player was playing on</param>
        /// <param name="isMultiplayer">Whether the player played singleplayer or multiplayer</param>
        public HighscoreData(string playerName, double score, Difficulty difficultty, bool isMultiplayer)
        {
            this.PlayerName = playerName;
            this.Score = score;
            this.Difficulty = difficultty;
            this.IsMultiplayer = isMultiplayer;
        }

    }
}