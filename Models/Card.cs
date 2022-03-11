using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyOne_Game.Models
{
    class Card
    {
        public Suits Suit { get; set; }



        public int Rank { get; set; }//1-13

        public int Value
        {
            get
            {
                return (Rank == 1) ? 11 :
                        (Rank >= 10 && Rank < 14) ? 10 : Rank;
            }
        }

        public override string ToString()
        {
            return Rank.ToString() + "of" + Suit.ToString();
        }



    }
}
