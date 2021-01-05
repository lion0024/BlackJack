using System;
using System.Collections.Generic;

namespace BlackJack
{
    enum Suit { diamond, club, heart, spade }

    class Card
    {
        // トランプの数値
        public int No { get; }

        // マーク
        public Suit Suit { get; }

        // 絵柄
        public string Rank =>
            No == 1 ? "A" :
            No == 11 ? "J" :
            No == 12 ? "Q" :
            No == 13 ? "K" :
            No.ToString();


        // 表か裏か
        public bool FaceUp { get; set; }

        public Card(Suit suit, int no)
        {
            if (no < 1 || 13 < no)
                throw new ArgumentOutOfRangeException(nameof(no));
            this.No = no;
            this.Suit = suit;
        }

        // カード表示用
        public override string ToString()
        {
            var suit = FaceUp ? Suit.ToString() : "???????";
            var rank = FaceUp ? Rank : "??";
            return $"[{suit,7}|{rank,2}]";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
        }
    }
}
