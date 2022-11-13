using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyOne_Game.Models
{
    public static class CardListExtensions
    {
        public static int CalculateScore(this IEnumerable<Card> cards)
        {
            return cards.GroupBy(c => c.Suit)
                .OrderByDescending(group => group.Sum(c => c.Value))
            .First()
                .Sum(c => c.Value);

        }

        public static string ToListString(this IEnumerable<Card> cards)
        {
            return string.Join(",", cards);
        }

    }
}
