using System;
using DungeonGame.Helpers;
using DungeonGame.DungeonLevels;
using DungeonGame.Monsters;
using System.Collections.Generic;
using DungeonGame.Hero;

namespace DungeonGame
{
    class Dungeon
    {
        public static int battleCount;
        public static int dungeonLevel;
        public static Hero.Hero hero;
        //static List<IItem> items = new List<IItem>();
        static void Main(string[] args)
        {
           
            //items.Add(new Item("Healing potion", hero.MaxHealth - hero.Health));
            //items.Add(new Item("Weapon", 5));
            //items.Add(new Item("Armor", 5));

            dungeonLevel = 1 ;
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
            Console.WriteLine("\nchoose a direction ( L or R):\n Press Q for exit");
            Box.Create("for stats pres S",20);
            
           // KeyReader.Pause();
            string direction = Console.ReadLine();
            Console.WriteLine(direction.Length + direction);
            int Chance = NumberGenerator.RandomNumber(0, 100);
            

            switch (direction)
            {
                case "L":
                    if (Chance <= 30)
                    {
                        Console.WriteLine("You find a treure!");
                        Item.FindATresure();
                    }
                    else
                    {
                        Console.WriteLine("You encounter a monster");
                        Hero.Hero hero = Dungeon.hero;
                        Monster monster = new Monster();
                        Battle battle = new Battle(hero, monster);
                        battle.StartBatle(monster);

                    }
                    goto again;
                case "R":
                    if (Chance >= 70)
                    {
                        Item.FindATresure();
                    }
                    else
                    {
                        Hero.Hero hero = Dungeon.hero;
                        Monster monster = new Monster();
                        Battle battle = new Battle(hero,monster);
                        battle.StartBatle(monster);
                    }
                    goto again;
                case "Q":
                    break;
                default:
                   // KeyReader.Error();
                    goto again;
                    
            }

           
        }
            

































    }
}
