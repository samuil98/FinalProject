using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Hero
{
    class Hero : Player.Stats
    {
        public static int round;
        public static int battleCount;
        public override double Attack { get; set; }
        public override double Defence { get; set; }
        public override double AtackRate { get; set; }
        public override int Level { get; set; }
        public override double XP { get; set ; }
        public override double Health { get; set; }
        public override double MaxHealth { get; set; }

        public Hero(double att,double def, double attrate, double hp)
        {
            this.Attack = att;
            this.Defence = def;
            this.AtackRate = attrate;
            this.Health = MaxHealth;
            this.Level = 1;
            this.XP = 0;
        }


        internal void CastAnAbility(char key, Monsters.Monster monster)
        {
            switch (key)
            {
                case 'f':
                    FireBall(monster);
                    break;
                case 'l':
                    LightningBolt(monster);
                    break;

            }
        }
        private void FireBall (Monsters.Monster monster)
        {
            int round = Hero.round;
            double demage = Attack * 1.2;
            monster.Health = monster.Health - demage;
            monster.ApplyBurning(round);
        }
        private void LightningBolt(Monsters.Monster monster)
        {
            int round = Hero.round;
            double damage = Attack * 1.5;
            monster.Health -= damage;
            monster.ApplyStun(round);
        }
       

        //public void StartBattle(Monsters.Monster monster)
        //{
        //    round = 0;
            
        //}
    }
}
