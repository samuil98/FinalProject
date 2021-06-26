using System;

namespace DungeonGame
{
    class Dungeon
    {
        public static int dungeonLevel;
        static void Main(string[] args)
        {
            dungeonLevel = 1 + Hero.Hero.battleCount / 3 ;
            var hero = new Hero.Hero();
        }
        
            

































    }
}
