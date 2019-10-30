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

        public HighscoreData(string playerName, double score, Difficulty difficultty, bool isMultiplayer)
        {
            this.PlayerName = playerName;
            this.Score = score;
            this.Difficulty = difficultty;
            this.IsMultiplayer = isMultiplayer;
        }

    }
}