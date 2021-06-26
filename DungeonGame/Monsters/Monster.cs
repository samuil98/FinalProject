﻿using System;
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
        public override double XP{ get; set; }
        public override double MaxHealth { get; set; }

        public Monster()
        {
            Level = Dungeon.dungeonLevel;
            MaxHealth = 40 * Level;
            Health = MaxHealth;
            Attack = 7 * Level;
            Defence = 5 * Level;
            XP = NumberGenerator.RandomNumber(30, 50);
        }
        

        public void ApplyBurning(int round)
        {
            while (round <= round + 3)
            {
                Health -= 0.1 * MaxHealth;
            }
        }
        public void ApplyStun(int round)
        {
            while (round <= round + 1)
            {
                //Make monster not attack for a round.            
            }
        }
    }
}
