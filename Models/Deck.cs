using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyOne_Game.Models
{
    class Deck
    {
        public List<Card> Cards { get; set; }

        public int CardsLeft
        {
            get
            {
                return Cards.Count;
            }
        }

        public void Initialize()
        {
            foreach (Suits suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                for (int i = 1; i < 14; i++)
                {
                    Card c = new Card() { Rank = i, Suit = suit };
                    Cards.Add(c);
                }
            }
        }

        public void Shuffle(Random R)
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                int from = i;
                int to = R.Next(Cards.Count);
                Card c = Cards[to];
                Cards[to] = Cards[from];
                Cards[from] = c;

            }

        }


    }
}
