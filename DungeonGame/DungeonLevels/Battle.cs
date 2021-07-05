using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Hero;
using DungeonGame.Monsters;
using static DungeonGame.Helpers.KeyReader;
using DungeonGame.Helpers;


namespace DungeonGame.DungeonLevels
{
    class Battle
    {
        public static int round = 1;
 
        public Hero.Hero Hero { get; set; }
        public Monster Monster{ get; set;}

        public Battle(Hero.Hero hero,Monster monster)
        {
            Console.WriteLine("You encountered a monster!");
            Console.ReadLine();
            hero = Dungeon.hero;
            this.Hero = hero;
            this.Monster = monster;
        }

        public void AttackHero(Monster monster)
        {           
            double damage = monster.Attack - 0.3 * Hero.Defence;
            if(damage <= 0)
            {
                Console.WriteLine("You blocked the attack! ");
                return;
            }
            Hero.Health -= damage;           
            Console.WriteLine("You took {0} damage. ", damage.ToString("F"));
        }
        internal void MakeAMove( Monster monster)
        {
            Console.Clear();
            Console.WriteLine("   \n MAKE A MOVE   ");
            Console.WriteLine("X─────────────────────X");
            Console.WriteLine("| A for Attack        |");
            Console.WriteLine("| F for Fire ball     |");
            Console.WriteLine("| L for Lightnig bolt |");
            Console.WriteLine("X─────────────────────X");
            round = 1;            
            monster = this.Monster;

        again:
            Console.WriteLine("HERO HP:" + Hero.Health.ToString("F"));
            Console.WriteLine("MONSTER HP:" + monster.Health.ToString("F"));
            Hero.ApplyBurning(monster);
            Console.WriteLine( "Round: "+ round + "  Dungeon: "+ Dungeon.dungeonLevel + " Battle: "+ Dungeon.battleCount);
            string key = Console.ReadLine();          
           

            switch (key.ToLower())
            {
                case "a":
                    Hero.AttackAnEnemy(monster);
                    AttackHero(monster);
                    round++;
                    break;
                case "f":
                    if (Hero.cooldownFB > 0)
                    {
                         Console.WriteLine("This skill is not ready yet");           
                         Continue();
                         goto again;
                    }
                    Hero.FireBall(monster);
                    AttackHero(monster);
                    round++;
                    break;
                case "l":
                    if (Hero.cooldownLB > 0)
                    {
                        Console.WriteLine("This skill is not ready yet");
                        Continue();
                        break;
                    }
                    else
                    {
                        Hero.LightningBolt(monster);
                        round++;
                        break;
                    }
                default:
                    goto again;                    
            }

            KeyReader.Pause();
            Hero.cooldownFB--;
            Hero.cooldownLB--;
        }
        public void StartBatle(Monster monster)
        {

            if (Dungeon.battleCount == 3)
            {
                monster.Level = 3 * Dungeon.dungeonLevel;                       //Doesn't increase stats.
                Console.WriteLine("THIS IS A BOSS MONSTER!");
                Pause();
            }

            while (monster.Health > 0)
            {
                MakeAMove(monster);
                if (Hero.Health <= 0)
                {
                    Console.WriteLine("Your hero is dead \n GAME OVER");
                    Pause();
                    break;
                }
                if (monster.Health <= 0)
                {
                    Console.WriteLine("The Monster is defeated. Press Enter to continue.");
                    Dungeon.battleCount++;
                    Hero.XP += monster.XP;
                    Pause();
                }
            }            

            if (Hero.XP >= Hero.MaxXp)
            {
                Hero.LevelUp();
            }
            
            if (Dungeon.battleCount == 4)
            {
                Dungeon.dungeonLevel++;
                Dungeon.battleCount = 0;
            }
        }
    }
}
