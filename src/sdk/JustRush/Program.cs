﻿using MagCore.Sdk.Helper;
using MagCore.Sdk.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JustRush
{
    class Program
    {
        static Player self = null;
        static Map map = null;
        static Game game = null;
        static void Main(string[] args)
        {
            string input = string.Empty;

            ServerHelper.Initialize("http://localhost:6000/");

            map = MapHelper.GetMap("RectSmall");
            game = new Game(map.Rows.Count, map.Rows[0].Count);

            Console.WriteLine("Enter nickname:");
            input = Console.ReadLine();
            string name = input.Trim();

            Console.WriteLine("Enter color(0~9):");
            input = Console.ReadLine();
            int color = Int32.Parse(input);

            self = PlayerHelper.CreatePlayer(name, color);

            string gameId = string.Empty;
            Console.WriteLine("1: Create a new game");
            Console.WriteLine("2: Join a game");
            input = Console.ReadLine();
            if (input == "1")
                gameId = GameHelper.CreateGame("RectSmall");
            else
            {
                Console.WriteLine("Input game id:");
                gameId = Console.ReadLine();
            }

            game.Id = gameId;

            if (!GameHelper.JoinGame(gameId, self.Id))
                Console.WriteLine("Join game fail.");
            else
                Console.WriteLine("Join game Ok.");

            PlayerHelper.GetPlayer(ref self);
            Console.WriteLine("Self info updated.");

            GameHelper.GetGame(gameId, ref game);

            RushAttack();
        }

        static void RushAttack()
        {
            //Task.Factory.StartNew(() => {
            //    while (true)
            //    {
            //        PlayerHelper.GetPlayer(ref self);

            //        Thread.Sleep(3000);
            //    }
            //});

            Task.Factory.StartNew(() => {
                while (true)
                {
                    GameHelper.GetGame(game.Id, ref game);

                    Thread.Sleep(500);
                }
            });

            while (true)
            {
                if (game.State == 1)
                {
                    foreach (var row in game.Rows)
                    {
                        foreach (var cell in row.Cells)
                        {
                            if (cell.Type != 0 && cell.State != 1
                                && cell.OwnerIndex == self.Index) //means this cell is self's
                            {
                                var siblings = cell.GetSiblings();
                                foreach (var pos in siblings)
                                {
                                    var target = game.Locate(pos.X, pos.Y);
                                    if (target != null && target.Type != 0 && target.State != 1
                                        && target.OwnerIndex != self.Index)
                                    {
                                        MapHelper.Attack(game.Id, self.Id, pos.X, pos.Y);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (game.State > 1)
                {
                    Console.WriteLine("Game over");
                    break;
                }

                Thread.Sleep(1000);
            }
        }
    }
}