﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyOne_Game.Models
{
   
        public class ComputerPlayer : Player
        {
            private Random _randomNumberGenerator;

            public ComputerPlayer(string name) : base(name)
            {
                _randomNumberGenerator = new Random();
            }

            public ComputerPlayer()
            {
                _randomNumberGenerator = new Random();
            }

            public override void Turn(Game game)
            {
                //First, decide on action: Draw from deck, draw from table, knock
                if (Hand.CalculateScore() > 25 && !game.Players.Any(p => p.HasKnocked) &&
                    _randomNumberGenerator.Next(3) == 1)
                {
                    Console.WriteLine($"{Name} knocks on the table");
                    //Knock
                    HasKnocked = true;
                }
                else
                {
                    //Decide if I should draw from table or from deck
                    if (game.Table.Any() && game.Table.Last().Value >= 10 && _randomNumberGenerator.Next(2) == 1)
                    {
                        Console.WriteLine($"{Name} draws a card from the table");
                        DrawFromTable(game);
                    }
                    else
                    {
                        Console.WriteLine($"{Name} draws a card from the deck");
                        DrawFromDeck(game);
                    }

                    //Drop card that'll give highest score
                    List<Tuple<Card, int>> lst = new List<Tuple<Card, int>>();
                    foreach (var card in Hand)
                    {
                        lst.Add(new Tuple<Card, int>(card, Hand.Except(new Card[] { card }).CalculateScore()));
                    }

                    int index = Hand.IndexOf(lst.OrderByDescending(l => l.Item2).First().Item1);
                    Console.WriteLine($"{Name} drops {Hand[index].ToString()}");
                    DropCard(game, index);
                }
            }
        }

    }

