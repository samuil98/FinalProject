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
            Level = 3 * Dungeon.dungeonLevel;
        }
    }
}
