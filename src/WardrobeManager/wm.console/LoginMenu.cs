using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;

namespace wm.console
{
    public class LoginMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("===============  Log In  ===============");
            Console.WriteLine($"{"Type [B] to go back to Main Menu", 36}\n");

            string username = InsertUsername();
            string password = InsertPassword();

            bool verification = UserService.VerifyUser(username, password);

            if (verification == false)
            {
                Console.WriteLine($"\n{"Wrong Username or Password",33}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print();
            }

            Console.WriteLine($"\n{"User Logged In",27}");
            Console.WriteLine("========================================");
            Console.ReadKey();
            MainMenu.Print();
        }

        private static string InsertUsername()
        {
            Console.Write($"{"Username: ",20}");
            var username = Console.ReadLine();

            if (username.ToUpper() == "B")
            {
                MainMenu.Print();
            }

            if (username.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Username is required",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print();
            }

            return username;
        }

        private static string InsertPassword()
        {
            Console.Write($"{"Password: ",20}");
            var password = Console.ReadLine();
            if(password.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Password is required",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print();
            }
            return password;
        }
    }
}
