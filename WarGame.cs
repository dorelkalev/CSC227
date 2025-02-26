using System;
using System.Collections.Generic;

namespace WarCardGame
{
    internal class WarGame
    {
        private Deck deck;
        private Player player1;
        private Player player2;

        public WarGame()
        {
            deck = new Deck();
            player1 = new Player("Player 1");
            player2 = new Player("Player 2");
            DealCards();
        }

        public void DealCards()
        {
            while (deck.CardsRemaining() > 0)
            {
                player1.AddCard(deck.Deal());
                player2.AddCard(deck.Deal());
            }
        }

        public void PlayGame()
        {
            int round = 1;
            while (player1.CardsRemaining() > 0 && player2.CardsRemaining() > 0)
            {
                Console.WriteLine("Round " + round);
                Console.WriteLine("Player 1 has " + player1.CardsRemaining() + " cards");
                Console.WriteLine("Player 2 has " + player2.CardsRemaining() + " cards");

                PlayRound();

                round++;
                if (player1.CardsRemaining() == 0 || player2.CardsRemaining() == 0)
                {
                    break; //End the game if one player has no cards left.
                }

                Console.WriteLine("Press Enter to continue to the next round.");
                Console.ReadLine();
            }

            //Check for game end condition
            if (player1.CardsRemaining() == 0)
            {
                Console.WriteLine("Player 2 wins the game!");
            }
            else
            {
                Console.WriteLine("Player 1 wins the game!");
            }
        }

        public void PlayRound()
        {
            Card player1Card = player1.PlayCard();
            Card player2Card = player2.PlayCard();

            //Check if either player has run out of cards
            if (player1Card == null || player2Card == null)
            {
                Console.WriteLine("One or both players have no cards left to play. The game ends!");
                return; //End the game if no cards left
            }

            Console.WriteLine(player1.GetName() + " plays: " + player1Card);
            Console.WriteLine(player2.GetName() + " plays: " + player2Card);

            if (player1Card.getPointValue() > player2Card.getPointValue())
            {
                Console.WriteLine("Player 1 wins this round!");
                player1.AddCard(player1Card);
                player1.AddCard(player2Card);
            }
            else if (player2Card.getPointValue() > player1Card.getPointValue())
            {
                Console.WriteLine("Player 2 wins this round!");
                player2.AddCard(player1Card);
                player2.AddCard(player2Card);
            }
            else
            {
                Console.WriteLine("It's a tie! A war begins!");
                War(player1Card, player2Card);
            }
        }

        public void War(Card player1Card, Card player2Card)
        {
            List<Card> player1WarPile = new List<Card>();
            List<Card> player2WarPile = new List<Card>();

            player1WarPile.Add(player1Card);
            player2WarPile.Add(player2Card);

            while (true)
            {
                if (player1.CardsRemaining() < 4 || player2.CardsRemaining() < 4)
                {
                    Console.WriteLine("A player does not have enough cards to continue the war. The game ends!");
                    return;
                }

                Console.WriteLine("Players place three cards face down and one card face up...");
                for (int i = 0; i < 3; i++)
                {
                    Card player1CardToAdd = player1.PlayCard();
                    Card player2CardToAdd = player2.PlayCard();

                    if (player1CardToAdd == null || player2CardToAdd == null)
                    {
                        Console.WriteLine("A player ran out of cards during the war. The game ends!");
                        return;
                    }

                    player1WarPile.Add(player1.PlayCard());
                    player2WarPile.Add(player2.PlayCard());
                }

                player1WarPile.Add(player1.PlayCard());
                player2WarPile.Add(player2.PlayCard());

                Card player1WarCard = player1WarPile[0];
                Card player2WarCard = player2WarPile[0];

                Console.WriteLine("Player 1's war card: " + player1WarCard);
                Console.WriteLine("Player 2's war card: " + player2WarCard);

                if (player1WarCard.getPointValue() > player2WarCard.getPointValue())
                {
                    Console.WriteLine("Player 1 wins the war!");
                    while (player1WarPile.Count > 0)
                    {
                        player1.AddCard(player1WarPile[0]);
                        player1WarPile.RemoveAt(0);
                    }
                    while (player2WarPile.Count > 0)
                    {
                        player1.AddCard(player2WarPile[0]);
                        player2WarPile.RemoveAt(0);
                    }
                    break;
                }
                else if (player2WarCard.getPointValue() > player1WarCard.getPointValue())
                {
                    Console.WriteLine("Player 2 wins the war!");
                    while (player1WarPile.Count > 0)
                    {
                        player2.AddCard(player1WarPile[0]);
                        player1WarPile.RemoveAt(0);
                    }
                    while (player2WarPile.Count > 0)
                    {
                        player2.AddCard(player2WarPile[0]);
                        player2WarPile.RemoveAt(0);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Another tie in the war! Continuing the war...");
                }
            }
        }
    }
}
