using System;
using Newtonsoft.Json;

namespace ChildrensGame.Core
{
    [Serializable]
    [JsonObject]
    public class GameManifest
    {
        [JsonProperty("id")]
        public long Id
        {
            get;
            set;
        }

        [JsonProperty("childrenCount")]
        public int ChildrenCount
        {
            get;
            set;
        }

        [JsonProperty("eliminateEach")]
        public int EliminateEach
        {
            get;
            set;
        }
    }
}
