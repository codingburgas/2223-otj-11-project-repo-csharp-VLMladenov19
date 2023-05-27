using wm.bll;
using wm.util;

namespace wm.console
{
    internal class EditUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("===============   Edit   ===============");
            Console.WriteLine($"{"Type [B] to go back to Main Menu",36}\n");

            string newUsername = InsertNewUsername();
            string newPassword = InsertNewPassword();
            string newFName = InsertNewFirstName();
            string newLName = InsertNewLastName();
            string newPhone = InsertNewPhone();
            string newEmail = InsertNewEmail();

            UserService.UpdateUser(UserLog.LoggedUser.Username, newUsername, newPassword, newFName, newLName, newPhone, newEmail);

            Console.WriteLine($"\n{"User Updated",26}");
            Console.WriteLine($"\n{"Press a key to go to Main Menu",35}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey(true);
            MainMenu.Print();
        }

        private static string InsertNewUsername()
        {
            Console.Write($"{"Username: ",20}");
            string? username = Console.ReadLine();

            if(username.ToUpper() == "B")
            {
                SettingsMenu.Print();
            }

            switch (UserService.CheckUsername(username))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Username is required",30}");
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
                default: break;
            }
            return username;
        }

        private static string InsertNewPassword()
        {
            Console.Write($"{"Password: ",20}");
            string? password = string.Empty;

            // Algorith to print stars("*") for password instead of letters 
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Ignore any non-character key inputs
                if (!char.IsControl(key.KeyChar))
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
                    Console.WriteLine($"\n{"Password is required",30}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.InvalidArgumentLength:
                    Console.WriteLine($"\n{"Password needs to be 4 to 12 characters",0}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasSpaces:
                    Console.WriteLine($"\n{"String has empty characters",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasNoNumbers:
                    Console.WriteLine($"\n{"Password must have a number",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasSymbols:
                    Console.WriteLine($"\n{"Password has special symbols",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                default: break;
            }
            return password;
        }

        private static string InsertNewFirstName()
        {
            Console.Write($"{"First Name: ",22}");
            string? firstName = Console.ReadLine();

            switch (UserService.CheckName(firstName))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"First Name is required",31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasNumbers:
                    Console.WriteLine($"\n{"First Name must not have numbers",36}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                default: break;
            }
            return firstName;
        }

        private static string InsertNewLastName()
        {
            Console.Write($"{"Last Name: ",21}");
            string? lastName = Console.ReadLine();

            switch (UserService.CheckName(lastName))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Last Name is required",31}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasNumbers:
                    Console.WriteLine($"\n{"Last Name must not have numbers",36}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                default: break;
            }
            return lastName;
        }

        private static string InsertNewPhone()
        {
            Console.Write($"{"Phone: ",17}");
            string? phone = Console.ReadLine();

            switch (UserService.CheckPhone(phone))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Phone is required",28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.InvalidArgumentLength:
                    Console.WriteLine($"\n{"Phone must 10 to 15 characters",35}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.ArgumentHasLetters:
                    Console.WriteLine($"\n{"Phone must not have letters",34}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                default: break;
            }
            return phone;
        }

        private static string InsertNewEmail()
        {
            Console.Write($"{"Email: ",17}");
            string? email = Console.ReadLine();

            switch (UserService.CheckEmail(email))
            {
                case (int)ErrorCodes.NullArgument:
                    Console.WriteLine($"\n{"Email is required",28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.EmailHasNoAtSign:
                    Console.WriteLine($"\n{"Email is invalid",28}");
                    Console.WriteLine($"\n========================================");
                    Console.ReadKey(true);
                    Print();
                    break;
                case (int)ErrorCodes.EmailHasNoDomain:
                    Console.WriteLine($"\n{"Email has no domain",29}");
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