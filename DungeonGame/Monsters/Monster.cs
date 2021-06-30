using System;
using DungeonGame.Hero;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Helpers;

namespace DungeonGame.Monsters
{
    class Monster : Hero.Stats
    {
        public string Name { get; set; }
        public override int  Level { get; set; }
        public override double Health { get; set; }
        public override double Attack { get; set; }
        public override double Defence { get; set; }
        public override int XP{ get; set; }
        public override double MaxHealth { get; set; }

        public Monster()
        {
            Level = Dungeon.dungeonLevel;
            MaxHealth = 40 + 10 * Level;
            Health = MaxHealth;
            Attack = 7 + 2.5 * Level;
            Defence = 5 + 2 * Level;
            XP = NumberGenerator.RandomNumber(30, 50);
        }
        

        internal void ApplyBurning(int round)
        {
            while (round <= round + 3)
            {
                Health -= 0.1 * MaxHealth;
                break;
            }
        }

    }
}
