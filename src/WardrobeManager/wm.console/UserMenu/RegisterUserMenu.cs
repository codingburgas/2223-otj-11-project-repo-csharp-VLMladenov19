using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.util;

namespace wm.console.UserMenu
{
    public class RegisterUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("=============== Register ===============");
            Console.WriteLine($"{"Type [B] to go back to Main Menu",36}\n");

            string username = InsertUsername();
            string password = InsertPassword();
            string fName = InsertFirstName();
            string lName = InsertLastName();
            string phone = InsertPhone();
            string email = InsertEmail();

            UserService.RegisterUser(username, password, fName, lName, phone, email);

            Console.WriteLine($"\n{"User Registered",28}");
            Console.WriteLine($"\n{"Press a key to back to Main Menu",36}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey();
            MainMenu.Print();
        }

        private static string InsertUsername()
        {
            Console.Write($"{"Username: ",20}");
            string? username = Console.ReadLine();

            if (username.ToUpper() == "B")
            {
                MainMenu.Print();
            }

            switch(UserService.CheckUsername(username))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Username is required",30}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.InvalidArgumentLength:
                    Console.WriteLine($"\n{"Username must be from 4 to 12 characters"}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.ObjectTaken:
                    Console.WriteLine($"\n{"Username already in use",31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return username;
        }

        private static string InsertPassword()
        {
            Console.Write($"{"Password: ",20}");
            string? password = Console.ReadLine();

            switch(UserService.CheckPassword(password))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Password is required",30}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.InvalidArgumentLength:
                    Console.WriteLine($"\n{"Password needs to be 4 to 12 characters",0}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasSpaces:
                    Console.WriteLine($"\n{"String has empty characters",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasNoNumbers:
                    Console.WriteLine($"\n{"Password must have a number",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasSymbols:
                    Console.WriteLine($"\n{"Password has special symbols",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return password;
        }

        private static string InsertFirstName()
        {
            Console.Write($"{"First Name: ",22}");
            string? firstName = Console.ReadLine();

            switch(UserService.CheckName(firstName))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"First Name is required",31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasNumbers:
                    Console.WriteLine($"\n{"First Name must not have numbers",36}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return firstName;
        }

        private static string InsertLastName()
        {
            Console.Write($"{"Last Name: ",21}");
            string? lastName = Console.ReadLine();

            switch (UserService.CheckName(lastName))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Last Name is required",31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasNumbers:
                    Console.WriteLine($"\n{"Last Name must not have numbers",36}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return lastName;
        }

        private static string InsertPhone()
        {
            Console.Write($"{"Phone: ",17}");
            string? phone = Console.ReadLine();

            switch(UserService.CheckPhone(phone))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Phone is required",28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.InvalidArgumentLength:
                    Console.WriteLine($"\n{"Phone must 10 to 15 characters",35}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasLetters:
                    Console.WriteLine($"\n{"Phone must not have letters",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return phone;
        }

        private static string InsertEmail()
        {
            Console.Write($"{"Email: ",17}");
            string? email = Console.ReadLine();
            
            switch(UserService.CheckEmail(email))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Email is required",28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.EmailHasNoAtSign:
                    Console.WriteLine($"\n{"Email is invalid",28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                case (int)ErrorCodes.EmailHasNoDomain:
                    Console.WriteLine($"\n{"Email has no domain",29}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return email;
        }
    }
}
