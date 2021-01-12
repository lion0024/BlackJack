using System;
using BlackJack;
using BlackjackApp;
using static System.Console;

namespace Blackjack
{
    class Player
    {
        private Hand Hand { get; }
        private Deck Deck { get; }

        // 名前
        public string Name { get; }

        // 得点
        public int Score => Hand.ComputeScore();

        // バストしているか？
        public bool IsBust => Score > 21;

        public Player(Hand hand, Deck deck, string name)
        {
            try
            {
                Hand = hand;
                Deck = deck;
                Name = name;
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine("Terminating application unexpextedly...");
                Environment.FailFast(string.Format("Out of Memory: {0}", e.Message));
            }
            
        }

        // カードを1枚引く
        public void Take(bool faceUp = true)
        {
            // 山札の有無確認
            if (Deck.IsEmpty())
            {
                var card = Deck.Pop();
                card.FaceUp = faceUp;
                ShowTookCard(card);
                Hand.Add(card);
            }
            else
            {
                WriteLine("<< The deck is exhausted. >> ");
                WriteLine("To close, press any key.");
                ReadKey(intercept: true);
                Environment.Exit(0);
            }
            
        }

        // カードの表示
        private void ShowTookCard(Card card) =>
            WriteLine($"[{Name}] => {card}");

        // 手札を表示する
        public void ShowHand()
        {
            Hand.FaceUpAll();
            WriteLine($"[{Name}] => Hand: {Hand}");
            WriteLine($"[{Name}] => Score: {Score}");
        }
    }
}