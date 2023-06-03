using wm.bll;
using wm.dal.Models;
using wm.util;

namespace wm.console
{
    internal class RegisterUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("=============== Register ===============");
            Console.WriteLine($"{"Type [B] to go back to Main Menu", 36}\n");

            string username = InsertUsername();
            string password = InsertPassword();
            string fName = InsertFirstName();
            string lName = InsertLastName();
            string email = InsertEmail();

            UserService.RegisterUser(username, password, fName, lName, email);

            User? loggedUser = UserService.GetUserByUsername(username);
            UserLog.LoggedUser = loggedUser;

            Console.WriteLine($"\n{"User Registered", 28}");
            Console.WriteLine($"\n{"Press a key to go to Main Menu", 36}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey(true);
            MainMenu.Print();
        }

        private static string InsertUsername()
        {
            Console.Write($"{"Username: ", 20}");
            string? username = Console.ReadLine();

            if(username.ToUpper() == "B")
            {
                StartMenu.Print();
            }
 
            switch(UserService.CheckUsername(username))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Username is required", 30}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.InvalidArgumentLength:
                    Console.WriteLine($"\n{"Username must be from 4 to 12 characters"}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ObjectTaken:
                    Console.WriteLine($"\n{"Username already in use", 31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                default: break;
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

            switch (UserService.CheckPassword(password))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Password is required", 30}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.InvalidArgumentLength:
                    Console.WriteLine($"\n{"Password needs to be 4 to 12 characters", 0}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasSpaces:
                    Console.WriteLine($"\n{"String has empty characters", 34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasNoNumbers:
                    Console.WriteLine($"\n{"Password must have a number", 34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasSymbols:
                    Console.WriteLine($"\n{"Password has special symbols", 34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                default: break;
            }
            return password;
        }

        private static string InsertFirstName()
        {
            Console.Write($"{"First Name: ", 22}");
            string? firstName = Console.ReadLine();

            switch(UserService.CheckName(firstName))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"First Name is required", 31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasNumbers:
                    Console.WriteLine($"\n{"First Name must not have numbers", 36}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                default: break;
            }
            return firstName;
        }

        private static string InsertLastName()
        {
            Console.Write($"{"Last Name: ", 21}");
            string? lastName = Console.ReadLine();

            switch (UserService.CheckName(lastName))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Last Name is required", 31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasNumbers:
                    Console.WriteLine($"\n{"Last Name must not have numbers", 36}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                default: break;
            }
            return lastName;
        }

        private static string InsertEmail()
        {
            Console.Write($"{"Email: ", 17}");
            string? email = Console.ReadLine();
            
            switch(UserService.CheckEmail(email))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Email is required", 28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.EmailHasNoAtSign:
                    Console.WriteLine($"\n{"Email is invalid", 28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.EmailHasNoDomain:
                    Console.WriteLine($"\n{"Email has no domain", 29}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                default: break;
            }
            return email;
        }
    }
}
