using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;

namespace wm.console
{
    public class MainMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("[R] Register   [L] Login   [B] Back");
            while(true)
            {
                var input = Char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'R': RegisterMenu.Print(); break;
                    case 'L': Console.WriteLine("Log"); break;
                    case 'B': Environment.Exit(0); break;
                    default:
                        break;
                }
            }
        }
    }
}
