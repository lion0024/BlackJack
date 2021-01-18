using System;
using Blackjack;
using static System.Console;

namespace BlackjackApp
{
    class Game
    {
        Player Player { get; }
        Player Dealer { get; }

        public Game(Player player, Player dealer)
        {
            Player = player;
            Dealer = dealer;
        }

        public void Run()
        {
            WriteLine("<< Welcome to Blackjack!! >>\n");

            // プレイヤー最初のドロー
            Player.Take();
            Player.Take();
            Player.ShowHand();
            WriteLine();

            // ディーラー最初のドロー 
            Dealer.Take();
            Dealer.Take(faceUp: false);  // 2枚目は裏向き
            WriteLine();

            // ユーザーのターン
            WriteLine($"<< {Player.Name} turn! >>");
            while (ConfrimHitOrStand("Hit or Stand?", 'h', 's'))
            {
                Player.Take();
                Player.ShowHand();
                if (Player.IsBust)
                {
                    WriteLine($"{Player.Name} have over 21, {Player.Name} bust!");
                    WriteLine();
                    Lost();
                    return;
                }
            }
            WriteLine();

            // ディーラーのターン
            WriteLine($"<< {Dealer.Name} turn! >>");
            while (Dealer.Score < 17)
            {
                Dealer.Take();
            }
            Dealer.ShowHand();
            if (Dealer.IsBust)
            {
                WriteLine($"{Dealer.Name} have over 21, {Dealer.Name} bust!");
                WriteLine();
                Won();
            }
            WriteLine();

            // 判定
            WriteLine("<< Result >>");
            Player.ShowHand();
            Dealer.ShowHand();
            if (Player.Score > Dealer.Score)
                Won();
            else if (Dealer.Score > Player.Score)
                Lost();
            else
                Drawn();
        }

        // ヒット・スタンド確認
        bool ConfrimHitOrStand(string message, char hit, char stand)
        {
            while (true)
            {
                Write($"{message} [{hit}/{stand}]");

                var key = ReadKey().KeyChar;
                WriteLine();
                if (key == hit)
                    return true;
                if (key == stand)
                    return false;
                WriteLine($"Invalid key. Please input {hit} or {stand}.");
            }
        }

        // 勝ち
        void Won()
        {
            WriteLine($"{Player.Name} won. Congraturation!");
        }

        // 負け
        void Lost()
        {
            WriteLine($"{Player.Name} lost.");
        }

        // 引き分け
        void Drawn()
        {
            WriteLine("This game was drawn...");
        }
    }
}