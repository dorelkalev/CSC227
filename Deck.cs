using System;
using System.Collections.Generic;

namespace WarCardGame
{
    internal class Deck
    {
        private Random rng;
        private string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        private List<Card> deck;

        public Deck()
        {
            initialize();
        }

        public void initialize()
        {
            rng = new Random();
            deck = new List<Card>();
            foreach (var suit in suits)
            {
                int rankValue = 2;
                foreach (var rank in ranks)
                {
                    deck.Add(new Card(suit, rank, rankValue));
                    rankValue++;
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            for (int i = 0; i < 100; i++)
            {
                List<Card> shuffled = new List<Card>();
                while (deck.Count > 0)
                {
                    int randomIndex = rng.Next(0, deck.Count);
                    Card removed = deck[randomIndex];
                    deck.Remove(removed);
                    shuffled.Add(removed);
                }
                deck = shuffled;
            }
        }

        public Card Deal()
        {
            if (deck.Count > 0)
            {
                var card = deck[0];
                deck.RemoveAt(0);
                return card;
            }
            return null;
        }

        //This may be a useful function in many games.
        //It is used by our cheating dealer.
        public Card getCardWithValue(int pointValue)
        {
            foreach (Card card in deck)
            {
                if (card.getPointValue() == pointValue)
                {
                    deck.Remove(card);
                    return card;
                }
            }
            return null;
        }

        //Prints all of the Cards in the Deck.  Useful for debugging.
        public void printDeck()
        {
            foreach (Card card in deck)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine("Total Cards: " + deck.Count);
        }

        public int CardsRemaining() => deck.Count;
    }
}
