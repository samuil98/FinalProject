using System;
using DungeonGame.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Player
{
    class Stats
    {
        public double Attack { get; set; }
        public double ArmorRate { get; set; }
        public int Level { get; set; }
        public double XP { get; set; }
        public double HP { get; set; }
        public double MaxHP { get; set; }

        public Stats()
        {
            this.Attack = 0;
            this.ArmorRate = 0;
            this.Level = 0;
            this.XP = 0;
            this.HP = 0;

        }

        public Stats(double attack, double armor, int level, double hp)
        {
            this.Attack = attack;
            this.ArmorRate = armor;
            this.Level = level;
            this.HP = hp;
            this.XP = XP;
            this.HP = hp;
        }

        public Stats(double attack, double armor, int level, double hp, double maxhp)
        {
            this.Attack = attack;
            this.ArmorRate = armor;
            this.Level = level;
            this.HP = hp;
            this.XP = XP;
            this.HP = hp;
            this.MaxHP = maxhp;
        }

        public void LevelUp()
        {
            Console.Clear();
            XP = 0;
            Level++;
            MaxHP += 10;
            Console.WriteLine("X────────────────────────────X");
            Box.Create($"You are now level {Level}.", 30);
            Console.WriteLine("X────────────────────────────X");
            KeyReader.Pause();
        }
    }
}
