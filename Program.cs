using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Card
    {
        public string Mark { get; set; }

        // 1,トランプの数値
        public int No { get; set; }

        // 2,トランプの表示
        public string NoString
        {
            get
            {
                // 1,トランプの数値を使用して判定する
                switch (No)
                {
                    case 1:
                        return "A";
                    case 11:
                        return "J";
                    case 12:
                        return "Q";
                    case 13:
                        return "K";
                }

                return No.ToString();
            }
        }

        // 3,ブラックジャックの点
        public int Point
        {
            get
            {
                // 1,トランプの数値を利用して判定
                switch (No)
                {
                    case 11:
                        return 10;
                    case 12:
                        return 10;
                    case 13:
                        return 10;
                }

                return No;
            }
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
