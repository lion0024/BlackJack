using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    class Hand
    {
        // 内部的にカードのリストとして保持する
        private IList<Card> Cards { get; }

        public Hand() => Cards = new List<Card>();

        // カードを一枚加える
        public void Add(Card card) => Cards.Add(card);

        // 点数を計算する
        public int ComputeScore()
        {
            int sum = Cards.Sum(card => card.No > 10 ? 10 : card.No);
            int AceCount = ContainsAce;
            sum += AceCount * 10;
            while (AceCount-- > 0 && sum > 21)
            {
                sum -= 10;
            }
            return sum;
        }

        // エースが含まれているか
        private int ContainsAce => Cards.Count(card => card.No == 1);

        // 手札の内容表示
        public override string ToString() =>
            string.Join(' ', Cards.Select(card => card.ToString()));

        public void FaceUpAll()
        {
            foreach(var card in Cards)
            {
                card.FaceUp = true;
            }
        }
    }
}
