using System;
using Newtonsoft.Json;

namespace ChildrensGame.Api.Models
{
    public class GameResult
    {
        public long Id
        {
            get;
            set;
        }

        public int Winner
        {
            get;
            set;
        }

        public int[] EliminationOrder
        {
            get;
            set;
        }
    }
}
