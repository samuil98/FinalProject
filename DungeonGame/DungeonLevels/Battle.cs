using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Hero;
using DungeonGame.Monsters;
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
            Console.WriteLine("You took {0} damage. \nPress ENTER to continue.", damage.ToString("F"));
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
            monster = this.Monster;

        again:
            Console.WriteLine("HERO HP:" + Hero.Health.ToString("F"));
            Console.WriteLine("MONSTER HP:" + monster.Health.ToString("F"));
            Console.WriteLine( "Round: "+ Battle.round + "  Dungeon: "+ Dungeon.dungeonLevel + " Battle: "+ Dungeon.battleCount);
            string key = Console.ReadLine();          
           

            switch (key.ToLower())
            {
                case "a":
                    Hero.AttackAnEnemy(monster);
                    Hero.ApplyBurning(monster);
                    AttackHero(monster);
                    break;
                case "f":
                    if (Hero.cooldownFB > 0)
                    {
                        Console.WriteLine("This skill is not ready yet.\nPress Enter to continue...");
                        Console.ReadLine();
                        goto again;
                    }
                    else
                    {
                        Hero.FireBall(monster);
                        AttackHero(monster);
                    }
                    break;
                case "l":
                    if (Hero.cooldownLB > 0)
                    {
                        Console.WriteLine("This skill is not ready yet. \nPress Enter to continue...");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Hero.LightningBolt(monster);
                        break;
                    }
                default:
                    goto again;                    
            }

            Console.ReadLine();
            Hero.cooldownFB--;
            Hero.cooldownLB--;
        }
        public void StartBatle(Monster monster)
        {
            round = 1;
            if (Dungeon.battleCount == 3)
            {               
                Console.WriteLine("THIS IS A BOSS MONSTER!");
                Console.ReadLine();
                Boss boss = new Boss();               
                monster.Level = boss.Level;
                monster.MaxHealth = boss.MaxHealth;
                monster.Health = boss.Health;
                monster.Attack = boss.Attack;
                monster.Defence = boss.Defence;
                monster.XP = boss.XP; 
            }

            while (monster.Health > 0)
            {
                MakeAMove(monster);
                round++;
                if (Hero.Health <= 0)
                {
                    Console.WriteLine("Your hero is dead \n GAME OVER");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                if (monster.Health <= 0)
                {
                    Console.WriteLine($"The Monster is defeated! You received +{monster.XP} XP.\n\n Press Enter to continue...");
                    Dungeon.battleCount++;
                    Hero.XP += monster.XP;
                    Console.ReadLine();
                    break;
                }
            }            


            
            if (Dungeon.battleCount == 4)
            {
                Dungeon.dungeonLevel++;
                Dungeon.battleCount = 0;
            }
        }
    }
}
