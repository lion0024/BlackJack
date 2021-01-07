﻿using BlackJack;
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
            Hand = hand;
            Deck = deck;
            Name = name;
        }

        // カードを1枚引く
        public void Take(bool faceUp = true)
        {
            var card = Deck.Pop();
            card.FaceUp = faceUp;
            ShowTookCard(card);
            Hand.Add(card);
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