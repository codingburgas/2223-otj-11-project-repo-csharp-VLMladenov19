using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class DeleteUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("===============  Delete  ===============");
            Console.WriteLine($"{"Type [B] to go back to Main Menu",36}\n");
            Console.WriteLine($"{"Delete this account?",30}\n");
            Console.WriteLine($"{"[Y] Yes",24}");
            Console.WriteLine($"{"[N] No",23}");

            var input = Char.ToUpper(Console.ReadKey(true).KeyChar);
            switch (input)
            {
                case 'Y': UserService.DeleteUser(UserLog.LoggedUser.Id); break;
                case 'N': SettingsMenu.Print(); break;
            }

            Console.WriteLine($"\n{"User Deleted",26}");
            Console.WriteLine($"\n{"Press a key to back to Main Menu",36}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey(true);
            StartMenu.Print();
        }
    }
}
