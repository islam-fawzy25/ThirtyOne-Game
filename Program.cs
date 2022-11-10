using System;
using ThirtyOne_Game.Models;

namespace ThirtyOne_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initial test
            Deck deck = new Deck();
            deck.Initialize();
            Random randomNumber = new Random();
            deck.Shuffle(randomNumber);
            Card card = deck.DrawCard();

        }
    }
}
