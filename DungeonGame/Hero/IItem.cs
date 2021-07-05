using System;
using DungeonGame.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Hero
{
    interface IItem
    {
        public string Type { get; set; }
        public double IncreaseStat { get; set; }
        public bool IsEquiped { get; set; }
    

        abstract void Use();
        
        
            
        



    }
}
