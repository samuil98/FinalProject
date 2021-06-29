using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Helpers
{
    public class KeyReader
    {
        public static ConsoleKeyInfo Pause()
        {
           return Console.ReadKey();
        }
        public static void Continue()
        {
            Console.WriteLine("[continue]");
            Console.ReadKey();
        }
        public static void Error()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" LOOKS LIKE YOU DID SOMETHING WRONG...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
