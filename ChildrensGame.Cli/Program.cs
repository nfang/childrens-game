﻿using System;
using ChildrensGame.Core;

namespace ChildrensGame.Cli
{
    class Program
    {
        static Logger logger = Logger.GetInstance();

        static async void RunAsync()
        {
            using (var engine = Engine.GetInstance())
            {
                var game = await engine.CreateGameAsync();
                logger.Write("engine", string.Format("Game created: [{0}]", game.Id));

                logger.Write(string.Format("game[{0}]", game.Id), 
                    string.Format("Started\n{0}", game.ToString()));

                var result = game.Play();

                logger.Write(string.Format("game[{0}]", game.Id),
                    string.Format("Result:\n{0}", result.ToString()));

                await engine.SendResultAsync(result);
                logger.Write("app", "Exit");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                RunAsync();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                logger.Write("app", ex.Message, "error");
            }
        }
    }
}
