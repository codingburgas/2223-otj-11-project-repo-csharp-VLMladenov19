using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.util;

namespace wm.console
{
    internal class OptionsMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("[E] EditUser  [D] Delete User  [L] LogOut  [B] Back");
            while (true)
            {
                var input = Char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'E': UpdateUserMenu.Print(); break;
                    case 'D': DeleteUserMenu.Print(); break;
                    case 'L': UserLog.LoggedUser = null; StartMenu.Print(); break;
                    case 'B': MainMenu.Print(); break;
                    default:
                        break;
                }
            }
        }
    }
}
