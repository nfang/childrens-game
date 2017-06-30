using System;

namespace ChildrensGame.Api.Models
{
    public class GameManifest
    {
        public long Id
        {
            get;
            set;
        }

        public int ChildrenCount
        {
            get;
            set;
        }

        public int EliminateEach
        {
            get;
            set;
        }
    }
}
