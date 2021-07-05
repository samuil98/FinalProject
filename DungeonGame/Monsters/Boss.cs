using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Monsters
{
    class Boss : Monster
    {
        public Boss():base()
        {
            Attack = 1.5 * base.Attack;
            MaxHealth =1.5 * base.MaxHealth;
            Health = this.MaxHealth;
            Defence = 1.5 * base.Defence;
            XP = 2 * base.XP;
        }
    }
}
