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

        public Battle()
        {

        }

        public void AttackHero(Monster monster)
        {
            
            double damage = monster.Attack;
            Hero.Health -= damage;
        }
        internal void MakeAMove( Monster monster)
        {
            monster = this.Monster;
            ConsoleKeyInfo key = Pause();

            switch (key.Key)
            {
                case ConsoleKey.A:
                    Hero.AttackAnEnemy(monster);
                    AttackHero(monster);
                    break;
                case ConsoleKey.F:
                    if (Hero.cooldownFB != 0)
                    {
                        Console.WriteLine("This skill is not ready yet");
                        Hero.cooldownFB--;
                        break;
                    }
                    Hero.FireBall(monster);
                    AttackHero(monster);
                    break;
                case ConsoleKey.L:
                    if (Hero.cooldownLB != 0)
                    {
                        Console.WriteLine("This skill is not ready yet");
                        Hero.cooldownLB--;
                        break;
                    }
                    Hero.LightningBolt(monster);
                    break;
                default:
                    Error();
                    break;
            }
            round++ ;
        }
        public void StartBatle()
        {
            //MakeAMove()

            Dungeon.battleCount++ ;
        }
    }
}
