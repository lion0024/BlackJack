using static System.Console;
using BlackJack;
using BlackjackApp;
using System;

namespace Blackjack
{
    class Program
    {
        // Continue or End確認
        bool ConfrimEndOrContinue(string message, char end, char con)
        {
            while (true)
            {
                Write($"{message} [{end}/{con}]");

                var key = ReadKey().KeyChar;
                WriteLine();
                if (key == end)
                    return true;
                if (key == con)
                    return false;
                WriteLine($"Invalid key. Please input {end} or {con}.");
            }
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            Deck deck = new Deck();
            do
            {
                var player = new Player(new Hand(), deck, "Player");
                var dealer = new Player(new Hand(), deck, "Dealer");
                var game = new Game(player, dealer);
                game.Run();
            } while (obj.ConfrimEndOrContinue("Continue or End ?", 'c', 'e'));
        }
    }
}