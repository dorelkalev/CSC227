using System;
using System.Collections.Generic;

namespace WarGame
{
    internal class Player
    {
        private string name; 
        private List<Card> hand;

        public Player(string name)
        {
            this.name = name; 
            hand = new List<Card>();
        }

        public string GetName()
        {
            return name;
        }

        //Add a card to the player's hand
        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        //Play the top card from the hand
        public Card PlayCard()
        {
            //Check if the player has cards in hand and return the first card, or null if no cards are left
            if (hand.Count > 0)
            {
                Card card = hand[0]; //Get the first card
                hand.RemoveAt(0); //Remove it from the hand
                return card;
            }
            else
            {
                return null; //No cards left to play
            }
        }

        //Get the number of cards remaining in the player's hand
        public int CardsRemaining()
        {
            return hand.Count;
        }

        //Reset the player's hand (clear all cards)
        public void ResetHand()
        {
            hand.Clear();
        }
    }
}
