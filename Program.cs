﻿using BlackJack;
using BlackjackApp;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var player = new Player(new Hand(), deck, "Player");
            var dealer = new Player(new Hand(), deck, "Dealer");
            var game = new Game(player, dealer);
            game.Run();
        }
    }
}