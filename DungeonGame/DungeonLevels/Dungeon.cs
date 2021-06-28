using System;
using DungeonGame.Helpers;

namespace DungeonGame
{
    class Dungeon
    {
        public static int battleCount;
        public static int dungeonLevel;
        static void Main(string[] args)
        {
            dungeonLevel = 1 + battleCount / 3 ;
            var hero = new Hero.Hero();

        }
        public void ChooseAWay()
        {
            Console.Clear();
            Console.WriteLine(" \\    \\       /    /");
            Console.WriteLine("  \\    \\     /    /");
            Console.WriteLine("   \\ L  \\   / R  /");
            Console.WriteLine("    \\	 \\_/    /");
            Console.WriteLine("     \\          / ");
            Console.WriteLine("      \\        / ");
            Console.WriteLine("        |   ^   |");
            Console.WriteLine("        |   ^   |");           
            Console.WriteLine("\nchoose a direction ( <- or ->):");

            ConsoleKeyInfo direction = KeyReader.Pause();
            int Chance = NumberGenerator.RandomNumber(0, 100);

            switch(direction.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (Chance <= 30)
                    {
                        
                    }
                    else
                    {
                        
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Chance >= 70)
                    {

                    }
                    else
                    {

                    }
                    break;
                default:
                    KeyReader.Error();
                    break;
            }
           
        }
            

































    }
}
