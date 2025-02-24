using System;

namespace WarCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the War Card Game!");
            WarGame game = new WarGame();
            game.PlayGame();
        }
    }
}
