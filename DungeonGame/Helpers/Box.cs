using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class Box
    {
        public static void Create(string stuffinside, int boxwidth)
        {
            boxwidth -= stuffinside.Length;
            boxwidth -= 2;

            string spaces = "";
            while (boxwidth != 0)
            {
                spaces += " ";
                boxwidth--;
                continue;
            }

            Console.WriteLine($"│{stuffinside}{spaces}│");
        }
    }
}
