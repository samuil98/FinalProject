using System;
using DungeonGame.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Heroes
{
    interface IItem
    {
        public string Type { get; set; }
        public int IncreaseStat { get; set; }
        public bool isEquiped { get; set; }

        public static int ItemCount;

        abstract void Equip();
        
        abstract void Use();
        

        abstract void Unequip();
        
        
            
        



    }
}
