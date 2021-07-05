using DungeonGame.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Monsters
{
    class Boss : Monster
    {
        public Boss()
        {
            Level = 3 * Dungeon.dungeonLevel;
            MaxHealth = 40 + 10 * Level;
            Health = MaxHealth;
            Attack = NumberGenerator.RandomNumber(5, 9) + 2.5 * Level;
            Defence = 7 + 2 * Level;
            XP = NumberGenerator.RandomNumber(30, 70);
        }
    }
}
