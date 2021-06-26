using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Hero;
using DungeonGame.Monsters;

namespace DungeonGame.DungeonLevels
{
    class Battle
    {
        public int round = 1;
 
        public Hero.Hero Hero { get; set; }
        public Monster Monster{ get; set;}

        void AttackHero(Monster monster)
        {
            
            double damage = monster.Attack;
            Hero.Health -= damage;
        }
        internal void MakeAMove(char key, Monster monster)
        {
            monster = this.Monster;
            switch (key)
            {
                case 'a':
                    Hero.AttackAnEnemy(monster);
                    AttackHero(monster);
                    break;
                case 'f':
                    Hero.FireBall(monster);
                    AttackHero(monster);
                    break;
                case 'l':
                    Hero.LightningBolt(monster);
                    break;

            }
            
        }
    }
}
