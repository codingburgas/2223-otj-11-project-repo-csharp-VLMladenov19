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
    public class UpdateUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("===============  Update  ===============");
            Console.WriteLine($"{"Type [B] to go back to Main Menu",36}\n");

            string oldUsername = InsertOldUsername();
            string newUsername = InsertNewUsername();
            string newPassword = InsertNewPassword();
            string newFName = InsertNewFirstName();
            string newLName = InsertNewLastName();
            string newPhone = InsertNewPhone();
            string newEmail = InsertNewEmail();

            UserService.UpdateUser(oldUsername, newUsername, newPassword, newFName, newLName, newPhone, newEmail);

            Console.WriteLine($"\n{"User Updated",26}");
            Console.WriteLine($"\n{"Press a key to go to Main Menu",35}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey();
            MainMenu.Print();
        }

        private static string InsertOldUsername()
        {
            Console.Write($"{"Username: ",20}");
            string? username = Console.ReadLine();

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

            int userId = UserService.GetUserIdByUsername(username);
            if (userId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"User does not exist",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print();
            }

            return username;
        }
        private static string InsertNewUsername()
        {
            Console.Write($"{"Username: ",20}");
            string? username = Console.ReadLine();

            if (username.ToUpper() == "B")
            {
                MainMenu.Print();
            }

            if (UserService.CheckUsername(username) != (int)ErrorCodes.None)
            {
                if (UserService.CheckUsername(username) == (int)ErrorCodes.NullArgument)
                {
                    Console.WriteLine($"\n{"Username is required",30}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckUsername(username) == (int)ErrorCodes.InvalidArgumentLength)
                {
                    Console.WriteLine($"\n{"Username must be from 4 to 12 characters"}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckUsername(username) == (int)ErrorCodes.ObjectTaken)
                {
                    Console.WriteLine($"\n{"Username already in use",31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
            }
            return username;
        }

        private static string InsertNewPassword()
        {
            Console.Write($"{"Password: ",20}");
            string? password = Console.ReadLine();

            if (UserService.CheckPassword(password) != (int)ErrorCodes.None)
            {
                if (UserService.CheckPassword(password) == (int)ErrorCodes.NullArgument)
                {
                    Console.WriteLine($"\n{"Password is required",30}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckPassword(password) == (int)ErrorCodes.InvalidArgumentLength)
                {
                    Console.WriteLine($"\n{"Password needs to be 4 to 12 characters",0}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckPassword(password) == (int)ErrorCodes.ArgumentHasSpaces)
                {
                    Console.WriteLine($"\n{"String has empty characters",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckPassword(password) == (int)ErrorCodes.ArgumentHasNoNumbers)
                {
                    Console.WriteLine($"\n{"Password must have a number",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckPassword(password) == (int)ErrorCodes.ArgumentHasSymbols)
                {
                    Console.WriteLine($"\n{"Password has special symbols",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
            }
            return password;
        }

        private static string InsertNewFirstName()
        {
            Console.Write($"{"First Name: ",22}");
            string? firstName = Console.ReadLine();

            if (UserService.CheckName(firstName) != (int)ErrorCodes.None)
            {
                if (UserService.CheckName(firstName) == (int)ErrorCodes.NullArgument)
                {
                    Console.WriteLine($"\n{"First Name is required",31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckName(firstName) == (int)ErrorCodes.ArgumentHasNumbers)
                {
                    Console.WriteLine($"\n{"First Name must not have numbers",36}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
            }
            return firstName;
        }

        private static string InsertNewLastName()
        {
            Console.Write($"{"Last Name: ",21}");
            string? lastName = Console.ReadLine();

            if (UserService.CheckName(lastName) != (int)ErrorCodes.None)
            {
                if (UserService.CheckName(lastName) == (int)ErrorCodes.NullArgument)
                {
                    Console.WriteLine($"\n{"Last Name is required",31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckName(lastName) == (int)ErrorCodes.ArgumentHasNumbers)
                {
                    Console.WriteLine($"\n{"Last Name must not have numbers",36}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
            }
            return lastName;
        }

        private static string InsertNewPhone()
        {
            Console.Write($"{"Phone: ",17}");
            string? phone = Console.ReadLine();

            if (UserService.CheckPhone(phone) != (int)ErrorCodes.None)
            {
                if (UserService.CheckPhone(phone) == (int)ErrorCodes.NullArgument)
                {
                    Console.WriteLine($"\n{"Phone is required",28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckPhone(phone) == (int)ErrorCodes.InvalidArgumentLength)
                {
                    Console.WriteLine($"\n{"Phone must 10 to 15 characters",35}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckPhone(phone) == (int)ErrorCodes.ArgumentHasLetters)
                {
                    Console.WriteLine($"\n{"Phone must not have letters",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
            }
            return phone;
        }

        private static string InsertNewEmail()
        {
            Console.Write($"{"Email: ",17}");
            string? email = Console.ReadLine();

            if (UserService.CheckEmail(email) != (int)ErrorCodes.None)
            {
                if (UserService.CheckEmail(email) == (int)ErrorCodes.NullArgument)
                {
                    Console.WriteLine($"\n{"Email is required",28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckEmail(email) == (int)ErrorCodes.EmailHasNoAtSign)
                {
                    Console.WriteLine($"\n{"Email is invalid",28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
                if (UserService.CheckEmail(email) == (int)ErrorCodes.EmailHasNoDomain)
                {
                    Console.WriteLine($"\n{"Email has no domain",29}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey();
                    Print();
                }
            }
            return email;
        }
    }
}