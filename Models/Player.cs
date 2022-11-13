using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyOne_Game.Models
{
    public abstract class Player
    {
        public List<Card> Hand { get; set; }

        public string Name { get; set; }

        public bool HasKnocked { get; set; }

 
        public abstract void Turn(Game game);

        public Player()
        {
            Hand = new List<Card>();
            HasKnocked = false;
        }

        public Player(string name) : this()
        {
            Name = name;
        }

     
        public void DrawFromDeck(Game game)
        {
            Hand.Add(game.Deck.DrawCard());
        }

      
        public void DrawFromTable(Game game)
        {
            Hand.Add(game.Table[game.Table.Count - 1]);
            game.Table.RemoveAt(game.Table.Count - 1);
        }

  
        public void DropCard(Game game, int index)
        {
            game.Table.Add(Hand[index]);
            Hand.RemoveAt(index);
        }
    }
}
