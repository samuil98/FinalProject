using System;
using DungeonGame.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Hero
{
    abstract class Stats
    {
        public abstract double Attack { get; set; }
        public abstract double Defence { get; set; }
        public abstract int Level { get; set; }
        public abstract int XP { get; set; }
        public abstract double Health { get; set; }
        public abstract double MaxHealth { get; set; }

    }
}
