using wm.util;

namespace wm.console
{
    internal class StartMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserLog.LoggedUser = null;

            Console.WriteLine("[R] Register   [L] Login   [E] Exit");
            while (true)
            {
                var input = Char.ToUpper(Console.ReadKey(true).KeyChar);

                switch (input)
                {
                    case 'R': RegisterUserMenu.Print(); break;
                    case 'L': LoginUserMenu.Print(); break;
                    case 'E': Environment.Exit(0); break;
                    default:
                        break;
                }
            }
        }
    }
}
