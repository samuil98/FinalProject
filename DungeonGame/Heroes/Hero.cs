using System;
using DungeonGame.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Hero
{
    class Hero : Stats
    {
        internal int cooldownLB = 0;
        internal int cooldownFB = 0;
        public string Name { get; set; }
        public override double Attack { get; set; }
        public override double Defence { get; set; }
        public override int Level { get; set; }
        public override int XP { get; set ; }
        public int MaxXp { get; set; }
        public override double Health { get; set; }
        public override double MaxHealth { get; set; }

        public Hero()
        {
            Console.WriteLine("Enter Hero Name:");
            this.Name = Console.ReadLine();
            this.Attack = 10;
            this.Defence = 15;
            this.Health = MaxHealth;
            this.Level = 1;
            this.MaxXp = 100;
        }


        internal void AttackAnEnemy(Monsters.Monster monster)
        {
            double damage = Attack;
            monster.Health -= damage;
                
        }

        internal void FireBall (Monsters.Monster monster)
        {
            cooldownFB = DungeonLevels.Battle.round + 3;
            double damage = Attack * 1.2;
            monster.Health -= damage;
            monster.ApplyBurning(3);
           
        }
        internal void LightningBolt(Monsters.Monster monster)
        {
            cooldownLB = DungeonLevels.Battle.round + 3;
            double damage = Attack * 1.5;
            monster.Health -= damage;           
        }

        public void LevelUp()
        {
            Console.Clear();
            XP = 0;
            Level++;
            MaxHealth += 30;
            Health = MaxHealth;
            Attack += 5;
            MaxXp += 50;


            Console.WriteLine("X────────────────────────────X");
            Box.Create($"You are now level {Level}.", 30);
            Console.WriteLine("X────────────────────────────X");
            KeyReader.Pause();
        }

    }

}

