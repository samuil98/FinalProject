using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Heroes
{
    interface IItem
    {
        public int Attack { get; set; }
        public int Armor { get; set; }

        void Equip()
        {

        }
        void Use()
        {
            
        }
    }
}
