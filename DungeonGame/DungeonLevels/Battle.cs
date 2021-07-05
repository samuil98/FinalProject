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
            Console.WriteLine("You begin a battle");
            hero = Dungeon.hero;
            this.Hero = hero;
            this.Monster = monster;
        }

        public void AttackHero(Monster monster)
        {           
            double damage = monster.Attack - 0.6*Hero.Defence;
            if(damage <= 0)
            {
                Console.WriteLine("You had blocked the attack");
                return;
            }
            Hero.Health -= damage;           
            Console.WriteLine("You had taken {0} damage. ", damage);
        }
        internal void MakeAMove( Monster monster)
        {
            Console.Clear();
            Console.WriteLine("   \n MAKE A MOVE");
            Console.WriteLine(" _____________________");
            //Console.WriteLine("| Choose your move    |");
            Console.WriteLine("| A for Attack        |");
            Console.WriteLine("| F for Fire ball     |");
            Console.WriteLine("| L for Lightnig bolt |");
            Console.WriteLine("|_____________________|");
            round = 1;

            
            monster = this.Monster;
        again:
            Console.WriteLine("Hero:" + Hero.Health);
            Console.WriteLine("MONSTER:" + monster.Health);
            
            Console.WriteLine( "RND"+round + " DL"+Dungeon.dungeonLevel + " BC"+ Dungeon.battleCount);
            string key = Console.ReadLine();
            
           

            switch (key.ToLower())
            {
                case "a":
                    Hero.AttackAnEnemy(monster);
                    AttackHero(monster);
                    Console.WriteLine("Hero:" + Hero.Health);
                    Console.WriteLine("MONSTER:" + monster.Health);
                   // Hero.ApplyBurning(monster);
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
                    Console.WriteLine("HERO:" + Hero.Health);
                    Console.WriteLine("MONSTER:" + monster.Health);
                    Hero.ApplyBurning(monster);
                    round++;
                    break;
                case "l":
                    if (Hero.cooldownLB > 0)
                    {
                        Console.WriteLine("This skill is not ready yet");                       
                        Continue();
                        break;
                    }
                    Hero.LightningBolt(monster);
                    Console.WriteLine("HERO:" + Hero.Health);
                    Console.WriteLine("MONSTER:" + monster.Health);
                    Hero.ApplyBurning(monster);
                    round++;
                    break;
                default:
                    //Error();
                    goto again;                    
            }
            KeyReader.Pause();
            Hero.cooldownFB--;
            Hero.cooldownLB--;
        }
        public void StartBatle(Monster monster)
        {

            if(Dungeon.battleCount == 3)
            {
                monster = new Boss();
            }
            while (monster.Health > 0)
            {
                MakeAMove(monster);
                if (Hero.Health <= 0)
                {
                    Console.WriteLine("your hero is dead \n GAME OVER");
                    Pause();
                    return;
                }
            }
            
            Hero.XP += monster.XP;
            Dungeon.battleCount++ ;
            monster = null;
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
