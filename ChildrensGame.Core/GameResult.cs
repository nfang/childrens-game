using System;
using Newtonsoft.Json;

namespace ChildrensGame.Core
{
    [Serializable]
    [JsonObject]
    public class GameResult
    {
        [JsonProperty("id")]
        public long Id
        {
            get;
            set;
        }

        [JsonProperty("winner")]
        public int Winner
        {
            get;
            set;
        }

        [JsonProperty("eliminationOrder")]
        public int[] EliminationOrder
        {
            get;
            set;
        }

        public override string ToString()
        {
            var eliminationOrder = string.Format("[{0}]", string.Join(",", this.EliminationOrder));
            return string.Format("\nId={0}\nWinner={1}\nEliminationOrder={2}\n",
                                 Id, Winner, eliminationOrder);
        }
    }
}
