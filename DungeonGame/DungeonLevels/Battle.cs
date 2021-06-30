using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Hero;
using DungeonGame.Monsters;
using static DungeonGame.Helpers.KeyReader;


namespace DungeonGame.DungeonLevels
{
    class Battle
    {
        public static int round = 1;
 
        public Hero.Hero Hero { get; set; }
        public Monster Monster{ get; set;}

        public Battle(Hero.Hero hero,Monster monster)
        {
            hero = Dungeon.hero;
            this.Hero = hero;
            this.Monster = monster;
        }

        public void AttackHero(Monster monster)
        {
            
            double damage = monster.Attack;
            Hero.Health -= damage;
        }
        internal void MakeAMove( Monster monster)
        {

            again:
            monster = this.Monster;
            string key = Console.ReadLine();
            Continue();

            switch (key)
            {
                case "A":
                    Hero.AttackAnEnemy(monster);
                    AttackHero(monster);
                    break;
                case "F":
                    if (Hero.cooldownFB != 0)
                    {
                         Console.WriteLine("This skill is not ready yet");
                         Hero.cooldownFB--;
                         goto again;
                    }
                    Hero.FireBall(monster);
                    AttackHero(monster);
                    break;
                case "L":
                    if (Hero.cooldownLB != 0)
                    {
                        Console.WriteLine("This skill is not ready yet");
                        Hero.cooldownLB--;
                        break;
                    }
                    Hero.LightningBolt(monster);
                    break;
                default:
                    //Error();
                    goto again;

            }
            Console.WriteLine(Hero.Health);
            Console.WriteLine(monster.Health);
            round++ ;
        }
        public void StartBatle(Monster monster)
        {


            while (monster.Health > 0)
            {
                MakeAMove(monster);
            }
            Hero.XP += monster.XP;

            if (Hero.XP >= Hero.MaxXp)
            {
                Hero.LevelUp();
            }
            Dungeon.battleCount++ ;
        }
    }
}
