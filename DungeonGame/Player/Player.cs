using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Player
{
    class Player
    {
        public string Name { get; set; }


        public Player(string name, string gender)
        {
            this.Name = name;
        }
    }
}
