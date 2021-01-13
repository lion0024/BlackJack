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
        // ＜検討＞Aの扱いを常に11にして21を超えた場合に
        // -10したほうがいいのか
        public int ComputeScore()
        {
            var sum = Cards.Sum(card => card.No > 10 ? 10 : card.No);
            if (ContainsAce && sum <= 11)
            {
                sum += 10;
            }
            return sum;
        }

        // エースが含まれているか
        private bool ContainsAce =>
            Cards.Any(card => card.No == 1);

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
