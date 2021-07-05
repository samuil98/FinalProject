using System;
using DungeonGame.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Hero
{
    class Item : IItem
    {
        public string Type { get; set; }  // Acceptable only Healing Potion, Damage Potion, Piece of armour.
        public double IncreaseStat { get; set; }

        static List<Item> items = new List<Item>();


        public Item( string type, double incr) 
        {
            this.Type = type;
            this.IncreaseStat = incr;
            
            
        }

        public void Use()
        {
            if (Type == "Damage Potion")
            {
                Dungeon.hero.Attack += IncreaseStat;
            }
            else if(Type == "Piece of armour")
            {
                Dungeon.hero.Defence += IncreaseStat;
            }
        }
        
        public static void FindATresure()
        {
            int atribut = NumberGenerator.RandomNumber(1,3);
            int luck = NumberGenerator.RandomNumber(0, 100);


            if (luck <= 40 )
            {
                Dungeon.hero.Health = Dungeon.hero.MaxHealth;

            }
            else if (luck <= 70)
            {
                items.Add(new Item("Piece of armour", atribut));
                Console.WriteLine($"You have found a Piece of armour! \n");
                Console.WriteLine($"Defence \n+{atribut}");
                Console.ReadLine();


                foreach (var item in items)
                {
                    if (item.Type == "Piece of armour")
                    {
                        item.Use();
                        
                    }
                    break;
                }

            }
            else
            {
                items.Add(new Item("Damage Potion", atribut));
                Console.WriteLine("You have found a Damage Potion!\n");
                Console.WriteLine($"Damage +{atribut}");
                Console.ReadLine();
                foreach (var item in items)
                {
                    if (item.Type == "Damage Potion")
                    {
                        item.Use();                       
                       
                    }
                    break;
                }

                
            }     
            


        }
    }
}
