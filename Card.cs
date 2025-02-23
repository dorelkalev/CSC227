using System;

namespace WarGame
{
    internal class Card
    {
        private string suit;
        private string rank;
        private int rankValue;

        public Card(string suit, string rank, int rankValue)
        {
            this.suit = suit;
            this.rank = rank;
            this.rankValue = rankValue;
        }

        public string GetSuit() { return suit; }
        public string GetRank() { return rank; }
        public int GetRankValue() { return rankValue; }

        public override string ToString()
        {
            return rank + " of " + suit + ": " + pointValue;
        }
    }
}
