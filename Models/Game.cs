using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyOne_Game.Models
{
    public class Game
    {
        public Deck Deck { get; set; }
        public List<Card> Table { get; set; }
        public List<Player> Players { get; set; }
        public int CurrentTurn { get; set; }

        public GameState State { get; set; }
        public Player Winner { get; set; }
        public Player CurrentPlayer
        {
            get
            {
                return Players[CurrentTurn];

            }
        }



        private Random _random;

        public Game()
        {
            State = GameState.WaitingToStart;
            _random = new Random();
            Players = new List<Player>();

        }

        public Game(Random R, params Player[] Players) : this()
        {
            this.Players = Players.ToList();
            StartGame();
        }

        public void StartGame()
        {
            Deck = new Deck();
            Table = new List<Card>();

            Deck.Initialize();
            Deck.Shuffle(_random);
            Winner = null;
            CurrentTurn = 0;
            InitialDeal();
            State = GameState.InProgress;
        }

        private void InitialDeal()
        {
            //Deal
            foreach (var p in Players)
            {
                for (int i = 0; i < 3; i++) p.Hand.Add(Deck.DrawCard());
            }

            Table.Add(Deck.DrawCard());
        }

        public bool EvaluateIfGameOver(bool called)
        {
            var winPlayer = (called)
                ? Players.Where(p => p.Hand.Count == 3).OrderByDescending(p => p.Hand.CalculateScore())
                    .First() //The game has been called, highest score is the winner
                : Players.FirstOrDefault(p => p.Hand.Count == 3 && p.Hand.CalculateScore() == 31); //Game has not been called, but a player has 31 and wins.

            if (winPlayer != null)
            {
                Winner = winPlayer;
                State = GameState.GameOver;
                return true;
            }

            return false;
        }

        public bool NextTurn()
        {
            //Ask player to do their turn
            CurrentPlayer.Turn(this);

            if (EvaluateIfGameOver(false))
            {
                //Player won, report
                return true;
            }

            //Move to the next player
            CurrentTurn++;

            if (CurrentTurn >= Players.Count)
            {
                CurrentTurn = 0;
            }

            if (CurrentPlayer.HasKnocked)
            {
                //Next player had already knocked - let's evaluate the call
                EvaluateIfGameOver(true);
                //Game over!
                return true;
            }

            if (Deck.CardsLeft == 0)
            {
                //If there's no more cards in the deck, let's take those from the table
                Deck.Cards.AddRange(Table);
                Table.Clear();
            }

            if (CurrentPlayer is ComputerPlayer)
            {
                return NextTurn(); //If the next player is the computer, execute that turn right away.
            }

            return false;
        }

    }
}
