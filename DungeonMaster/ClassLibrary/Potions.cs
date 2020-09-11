using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Potions
    {
        public static void UsePotion(Player player)
        {
            if (player.Life < player.MaxLife - 15)
            {
                player.Life += 15;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("{0} used a potion!", player.Name);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("You cant do that right now.");
            }
        }
    }
}
