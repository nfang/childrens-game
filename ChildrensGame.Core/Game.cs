using System;
using System.Collections.Generic;

namespace ChildrensGame.Core
{
    public class Game
    {
        private Queue<int> children;

        private void GenerateSequence(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Invalid: size must be larger than 0");
            }

            var sequence = new int[size];

            for (int i = 0; i < size; i++)
            {
                sequence[i] = i;
            }

            this.children = new Queue<int>(sequence);
        }

        public Game(GameManifest manifest)
        {
            this.Id = manifest.Id;
            this.GenerateSequence(manifest.ChildrenCount);
            this.Seed = manifest.EliminateEach;
        }

        public Queue<int> Children
        {
            get { return children; }
        }

        public long Id
        {
            get; private set;
        }

        public int Seed
        {
            get; private set;
        }

        public GameResult Play()
        {
            if (children == null)
            {
                throw new ArgumentNullException("children");
            }

            if (this.Seed <= 0)
            {
                throw new ArgumentException("Invalid: seed must be larger than 0");
            }

            var eliminationSequence = new Queue<int>();
            int winner = 0;

            var cursor = 0;
            while (children.Count > 0)
            {
                if (cursor == (this.Seed - 1))
                {
                    cursor = -1;
                    eliminationSequence.Enqueue(children.Dequeue());
                }
                else if (children.Count == 1)
                {
                    winner = children.Dequeue();
                }
                else
                {
                    children.Enqueue(children.Dequeue());
                }

                cursor++;
            }

            return new GameResult()
            {
                Id = this.Id,
                Winner = winner,
                EliminationOrder = eliminationSequence.ToArray()
            };
        }

        public override string ToString()
        {
            return string.Format("\nId={0}\nChildrenCount={1}\nSeed={2}\n",
                                 this.Id, this.Children.Count, this.Seed);
        }
    }
}
