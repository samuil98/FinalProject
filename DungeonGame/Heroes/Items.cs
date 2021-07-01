using System;
using DungeonGame.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Heroes
{
    class Items : IItem
    {
        public string Type { get; set; }  // Acceptable only Healing Potion, Weapon, Armour.
        public int IncreaseStat { get; set; }
        public bool isEquiped { get; set; }

        public int ItemCount = 0;

        public Hero.Hero Hero { get; set; }

        public Items( string type, int incr) 
        {
            this.Type = type;
            this.IncreaseStat = incr;
            this.isEquiped = false;
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
                    if(isEquiped == true)
                    {
                        Unequip();
                        Equip();
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
            if (Type == "Weapon")
            {
                Hero.Attack -= IncreaseStat;
                isEquiped = false;
            }
            else
            {
                Hero.Defence -= IncreaseStat;
                isEquiped = false;
            }
        }
        public void Use()
        {
            if (Type == "Weapon")
            {
                Hero.Attack += IncreaseStat;
                isEquiped = true;
            }
            else if (Type == "Healing Potion")
            {
                Hero.Health = Hero.MaxHealth;
                ItemCount--;
               
            }
            else
            {
                Hero.Defence += IncreaseStat;
                isEquiped = true;
            }
        }

        void FindATresure()
        {
            int chance = NumberGenerator.RandomNumber(0, 100);
            if (chance <= 50 )
            {
                Console.WriteLine($"You have found a HealingPotion");
                this.Type = "Healing Potion";
                ItemCount++;
                Equip();

            }
            else if (chance >= 75)
            {

                Console.WriteLine($"You have found a Chestplate!");
                this.Type = "Armour";
                Console.WriteLine($"Stats: +{IncreaseStat} Defence \n");
                Equip();

            }
            else
            {

                Console.WriteLine("You have found a new chestplate!\n");
                Console.WriteLine($"Stats:\n+{IncreaseStat}");
                Equip();
            }
         

        }
    }
}
