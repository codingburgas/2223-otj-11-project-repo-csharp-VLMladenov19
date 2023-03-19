using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.console.UserMenu;

namespace wm.console
{
    public class MainMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("[R] Register   [L] Login   [U] Update   [D] Delete   [B] Back");
            while(true)
            {
                var input = Char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'R': RegisterUserMenu.Print(); break;
                    case 'L': LoginUserMenu.Print(); break;
                    case 'U': UpdateUserMenu.Print(); break;
                    case 'D': DeleteUserMenu.Print(); break;
                    case 'B': Environment.Exit(0); break;
                    default:
                        break;
                }
            }
        }
    }
}
