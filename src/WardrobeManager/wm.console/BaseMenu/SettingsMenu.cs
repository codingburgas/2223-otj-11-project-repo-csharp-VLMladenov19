using wm.util;

namespace wm.console
{
    internal class SettingsMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("[E] Edit User   [D] Delete User   [L] Log Out   [B] Back");
            while (true)
            {
                var input = Char.ToUpper(Console.ReadKey(true).KeyChar);

                switch (input)
                {
                    case 'E': EditUserMenu.Print(); break;
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
