using System;

namespace WarCardGame
{
    internal class Card
    {
        private string suit;
        private string rank;
        private int pointValue;

        public Card(string s, string r, int pV)
        {
            this.suit = s;
            this.rank = r;
            this.pointValue = pV;
        }

        public string getSuit() { return suit; }
        public string getRank() { return rank; }
        public int getPointValue() { return pointValue; }
        public void setPointValue(int val) { pointValue = val; } //should only be used for aces.

        public override string ToString()
        {
            return rank + " of " + suit + ": " + pointValue;
        }
    }
}
