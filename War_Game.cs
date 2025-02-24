using System;

namespace WarGame
{
    internal class War_Game
    {
        private Deck deck;
        private Player player1;
        private Player player2;

        public War_Game()
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
                Console.WriteLine($"Round {round}");
                Console.WriteLine($"Player 1 has {player1.CardsRemaining()} cards");
                Console.WriteLine($"Player 2 has {player2.CardsRemaining()} cards");

                PlayRound();

                round++;
                Console.WriteLine("Press Enter to continue to the next round.");
                Console.ReadLine();
            }

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

            Console.WriteLine($"{player1.Name} plays: {player1Card}");
            Console.WriteLine($"{player2.Name} plays: {player2Card}");

            if (player1Card.GetRankValue() > player2Card.GetRankValue())
            {
                Console.WriteLine("Player 1 wins this round!");
                player1.AddCard(player1Card);
                player1.AddCard(player2Card);
            }
            else if (player2Card.GetRankValue() > player1Card.GetRankValue())
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
            Queue<Card> player1WarPile = new Queue<Card>();
            Queue<Card> player2WarPile = new Queue<Card>();

            player1WarPile.Enqueue(player1Card);
            player2WarPile.Enqueue(player2Card);

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
                    player1WarPile.Enqueue(player1.PlayCard());
                    player2WarPile.Enqueue(player2.PlayCard());
                }

                player1WarPile.Enqueue(player1.PlayCard());
                player2WarPile.Enqueue(player2.PlayCard());

                Card player1WarCard = player1WarPile.Peek();
                Card player2WarCard = player2WarPile.Peek();

                Console.WriteLine($"Player 1's war card: {player1WarCard}");
                Console.WriteLine($"Player 2's war card: {player2WarCard}");

                if (player1WarCard.GetRankValue() > player2WarCard.GetRankValue())
                {
                    Console.WriteLine("Player 1 wins the war!");
                    while (player1WarPile.Count > 0) player1.AddCard(player1WarPile.Dequeue());
                    while (player2WarPile.Count > 0) player1.AddCard(player2WarPile.Dequeue());
                    break;
                }
                else if (player2WarCard.GetRankValue() > player1WarCard.GetRankValue())
                {
                    Console.WriteLine("Player 2 wins the war!");
                    while (player1WarPile.Count > 0) player2.AddCard(player1WarPile.Dequeue());
                    while (player2WarPile.Count > 0) player2.AddCard(player2WarPile.Dequeue());
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
