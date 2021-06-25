using System;
using DungeonGame.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Player
{
    abstract class Stats
    {
        public abstract double Attack { get; set; }
        public abstract double Defence { get; set; }
        public abstract double AtackRate { get; set; }
        public abstract int Level { get; set; }
        public abstract double XP { get; set; }
        public abstract double Health { get; set; }
        public abstract double MaxHealth { get; set; }



        public void LevelUp()
        {
            Console.Clear();
            XP = 0;
            Level++;
            MaxHealth += 30;
            Health = MaxHealth;
            Attack += 5;


            Console.WriteLine("X────────────────────────────X");
            Box.Create($"You are now level {Level}.", 30);
            Console.WriteLine("X────────────────────────────X");
            KeyReader.Pause();
        }
    }
}
