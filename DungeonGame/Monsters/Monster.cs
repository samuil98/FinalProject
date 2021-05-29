using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Monsters
{
    abstract class Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Attak { get; set; }
        public int Defence { get; set; }
        public double AttakRate { get; set; }
        public int Experience { get; set; }
        
    }
}
