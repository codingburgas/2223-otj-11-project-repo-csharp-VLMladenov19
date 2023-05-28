using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.dal.Models;
using wm.util;

namespace wm.console
{
    internal class LoginUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("===============  Log In  ===============");
            Console.WriteLine($"{"Type [B] to go back to Main Menu", 36}\n");

            string username = InsertUsername();
            string password = InsertPassword();

            if(!UserService.VerifyUser(username, password))
            {
                Console.WriteLine($"\n{"Wrong Username or Password", 33}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            User? loggedUser = UserService.GetUserByUsername(username);
            UserLog.LoggedUser = loggedUser;

            Console.WriteLine($"\n{"User Logged In", 27}");
            Console.WriteLine($"\n{"Press a key to go to Main Menu", 36}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey(true);
            MainMenu.Print();
        }

        private static string InsertUsername()
        {
            Console.Write($"{"Username: ", 20}");
            var username = Console.ReadLine();

            if(username.ToUpper() == "B")
            {
                StartMenu.Print();
            }
            if(username.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Username is required", 30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return username;
        }

        private static string InsertPassword()
        {
            Console.Write($"{"Password: ", 20}");
            string? password = string.Empty;

            // Algorith to print stars("*") for password instead of letters 
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Handle Backspace key
                if(key.Key == ConsoleKey.Backspace)
                {
                    if(password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                // Ignore any non-character and Backspace key inputs
                else if(!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();

            if(password.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Password is required", 30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }
            return password;
        }
    }
}
