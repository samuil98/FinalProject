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
        public string Gender { get; set; }

        public Player()
        {
            this.Name = "null";
            this.Gender = "null";
        }

        public Player(string name, string gender)
        {
            this.Name = name;
            this.Gender = gender;
        }
    }
}
