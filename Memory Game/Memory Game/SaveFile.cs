using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memory_Game
{
    class SaveFile
    {

        public string player1, player2;
        public Difficulty difficulty;
        public bool isMultiplayer;
        public int time;
        public string turn;
        public int amountOfCards;
        
        public List<Card> cards;



    }
}
