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
        static void Main(string[] args)
        {         
            dungeonLevel = 1 ;
            Dungeon.hero = new Hero.Hero();
            ChooseAWay();            
        }
        public static void ChooseAWay()
        {
        again:
            int room = NumberGenerator.RandomNumber(0, 5);
        again2:
            if (room == 1)
            {
                Console.Clear();
                Console.WriteLine(" \\    \\       /    /");
                Console.WriteLine("  \\    \\     /    /");
                Console.WriteLine("   \\ L  \\   / R  /");
                Console.WriteLine("    \\	 \\_/    /");
                Console.WriteLine("     \\         / ");
                Console.WriteLine("      \\       / ");
                Console.WriteLine("       |   ^  |");
                Console.WriteLine("       |   ^  |");
                Console.WriteLine("\nchoose a direction ( L or R):\n Press S for stats, Q for exit.");
            }else if(room == 2)
            {
                Console.Clear();
                Console.WriteLine(" _____________________");
                Console.WriteLine("    L             R   ");
                Console.WriteLine(" _______       _______");
                Console.WriteLine("       |   ^  |  ");
                Console.WriteLine("       |   ^  |   ");
                Console.WriteLine("\nchoose a direction ( L or R):\n Press S for stats, Q for exit.");
            }
            else if (room == 3)
            {
                Console.Clear();
                Console.WriteLine("       |   F  |   ");
                Console.WriteLine(" ______|      |_______");
                Console.WriteLine("    L             R   ");
                Console.WriteLine(" _______       _______");
                Console.WriteLine("       |   ^  |  ");
                Console.WriteLine("       |   ^  |   ");
                Console.WriteLine("\nchoose a direction ( L, R or F):\n Press S for stats, Q for exit.");
            }
            else if (room == 4)
            {
                Console.Clear();
                Console.WriteLine("       |   F  |   ");
                Console.WriteLine("       |      |_______");
                Console.WriteLine("       |          R   ");
                Console.WriteLine("       |       _______");
                Console.WriteLine("       |   ^  |  ");
                Console.WriteLine("       |   ^  |   ");
                Console.WriteLine("\nchoose a direction (R or F):\n Press S for stats, Q for exit.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("       |   F  |   ");
                Console.WriteLine(" ______|      |");
                Console.WriteLine("    L         |   ");
                Console.WriteLine(" _______      |");
                Console.WriteLine("       |   ^  |  ");
                Console.WriteLine("       |   ^  |   ");
                Console.WriteLine("\nchoose a direction ( L or F):\n Press S for stats, Q for exit.");
            }


            string direction = Console.ReadLine();

            int chance = NumberGenerator.RandomNumber(0, 100);

            switch (direction.ToLower())
            {
                case ("l" or "r" or "f"):
                    if (chance <= 50)
                    {
                        Item.FindATresure();
                        room++;
                        goto again;
                    }
                    else if (chance <= 75)
                    {
                        Hero.Hero hero = Dungeon.hero;
                        Monster monster = new Monster();
                        Battle battle = new Battle(hero, monster);
                        battle.StartBatle(monster);
                        if (hero.XP >= hero.MaxXp)
                        {
                            hero.LevelUp();
                        }
                    }
                    else
                    {
                        room++;
                        goto again;
                    }

                    room++;
                    goto again;

                case "s":
                    Console.Clear();
                    Console.WriteLine(                         
                        $"Hero:    {hero.Name}\n" +
                        $"Level:   {hero.Level}\n" +
                        $"XP:      {hero.XP}/{hero.MaxXp}\n" +      
                        $"HP:      {hero.Health.ToString("F")}/{hero.MaxHealth}\n" +
                        $"Attack:  {hero.Attack}\n" +
                        $"Defence: {hero.Defence}\n");                      
                    Console.ReadLine();
                    room++;
                    goto again;
                
                case "q":
                    break;
                
                default:                   
                    goto again2;
                    
            }

           
        }
            

































    }
}
