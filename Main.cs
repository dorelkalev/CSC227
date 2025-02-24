using System;

namespace WarGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the War Card Game!");
            War_Game game = new War_Game();
            game.PlayGame();
        }
    }
}
