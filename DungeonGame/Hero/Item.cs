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
        public string Type { get; set; }  // Acceptable only Healing Potion, Weapon, Armour.
        public double IncreaseStat { get; set; }
        public bool IsEquiped { get; set; }

        static List<IItem> items = new List<IItem>();

        //public static Hero Hero { get; set; }

        public Item( string type, double incr) 
        {
            this.Type = type;
            this.IncreaseStat = incr;
            this.IsEquiped = false;
            
            
        }

        public  void Equip()
        {

            Console.WriteLine("Would you like to eqip it? Equiping it will replace your last item. Not equiping it will throw it away. (Y/N)");
            string choice = Console.ReadLine( );
  
            switch (choice.ToLower())
            {
                case "n":
                    break;

                case "y": 
                    if(IsEquiped == true)
                    {
                        Unequip();
                        Use();
                    }
                    else
                    {
                        Use();
                    }
                    break;

            }

        }

        public void Unequip()
        {
            foreach (var item in items)
            {
                if (Type == "Weapon" && IsEquiped)
                {
                    Dungeon.hero.Attack -= IncreaseStat;
                    IsEquiped = false;
                    break;
                }
                else if (IsEquiped)
                {
                    Dungeon.hero.Defence -= IncreaseStat;
                    IsEquiped = false;
                    break;
                }
                
            }
        }
        public void Use()
        {
            if (Type == "Weapon")
            {
                Dungeon.hero.Attack += IncreaseStat;
                IsEquiped = true;
            }
            else if (Type == "Healing Potion")
            {
                Dungeon.hero.Health = Dungeon.hero.MaxHealth;
                //ItemCount--;
            }
            else
            {
                Dungeon.hero.Defence += IncreaseStat;
                IsEquiped = true;
            }
        }
        
        public static void FindATresure()
        {
            int atribut = NumberGenerator.RandomNumber(5,11);
            int chance = NumberGenerator.RandomNumber(0, 100);
            if (chance <= 50 )
            {
                items.Add(new Item("Healing Potion",0));
                Console.WriteLine($"You have found a HealingPotion");
                foreach (var item in items)
                {
                    if (item.Type == "Healing Potion")
                    {
                        item.Equip();
                        break;
                    }
                    break;
                }
                //this.Type = "Healing Potion";
                //ItemCount++;
                //Equip();

            }
            else if (chance >= 75)
            {
                items.Add(new Item("Armour", atribut));
                Console.WriteLine($"You have found a Chestplate! \n");
                foreach (var item in items)
                {
                    if (item.Type == "Armour")
                    {
                        item.Equip();
                        break;
                    }
                    break;
                }
                //this.Type = "Armour";
                //Console.WriteLine($"Stats: +{IncreaseStat} Defence \n");
                //Equip();

            }
            else
            {
                items.Add(new Item("Weapon", atribut));
                Console.WriteLine("You have found a new sword!\n");
                //Console.WriteLine($"Stats:\n+{IncreaseStat}");
                foreach (var item in items)
                {
                    if (item.Type == "Weapon")
                    {
                        item.Use();                       
                        break;
                    }
                    break;
                }

                
            }
         

        }
    }
}
