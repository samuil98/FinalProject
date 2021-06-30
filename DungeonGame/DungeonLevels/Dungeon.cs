using System;
using DungeonGame.Helpers;
using DungeonGame.DungeonLevels;
using DungeonGame.Monsters;

namespace DungeonGame
{
    class Dungeon
    {
        public static int battleCount;
        public static int dungeonLevel;
        public static Hero.Hero hero;
        static void Main(string[] args)
        {
            dungeonLevel = 1 + battleCount / 3 ;
            Dungeon.hero = new Hero.Hero();
            ChooseAWay();

            
        }
        public static void ChooseAWay()
        {
            again:
            Console.Clear();
            Console.WriteLine(" \\    \\       /    /");
            Console.WriteLine("  \\    \\     /    /");
            Console.WriteLine("   \\ L  \\   / R  /");
            Console.WriteLine("    \\	 \\_/    /");
            Console.WriteLine("     \\         / ");
            Console.WriteLine("      \\       / ");
            Console.WriteLine("       |   ^  |");
            Console.WriteLine("       |   ^  |");           
            Console.WriteLine("\nchoose a direction ( L or R):");
            
           // KeyReader.Pause();
            string direction = Console.ReadLine();
            Console.WriteLine(direction.Length + direction);
            int Chance = NumberGenerator.RandomNumber(0, 100);
            KeyReader.Pause();

            switch (direction)
            {
                case "L":
                    if (Chance <= 30)
                    {
                        Console.WriteLine("You find a treure!");
                        //FindATresure();
                    }
                    else
                    {
                        Console.WriteLine("You encounter a monster");
                        Hero.Hero hero = Dungeon.hero;
                        Monster monster = new Monster();
                        Battle battle = new Battle(hero, monster);
                        battle.StartBatle(monster);

                    }
                    break;
                case "R":
                    if (Chance >= 70)
                    {
                        //FindATresure();
                    }
                    else
                    {
                        Hero.Hero hero = Dungeon.hero;
                        Monster monster = new Monster();
                        Battle battle = new Battle(hero,monster);
                        battle.StartBatle(monster);
                    }
                    break;
                default:
                   // KeyReader.Error();
                    goto again;
                    
            }

           
        }
            

































    }
}
