using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class MainMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("[O] Outfit  [C] Clothes  [T] Options   [E] Exit");
            while(true)
            {
                var input = Char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'O': OutfitsListMenu.Print(); break;
                    case 'C': ClothesListMenu.Print(); break;
                    case 'T': OptionsMenu.Print(); break;
                    case 'E': Environment.Exit(0); break;
                    default:
                        break;
                }
            }
        }
    }
}
