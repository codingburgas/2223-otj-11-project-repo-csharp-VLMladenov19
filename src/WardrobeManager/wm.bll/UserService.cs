using Microsoft.Identity.Client;
using System;
using wm.dal.Models;
using wm.dal;
using wm.dal.Data;
using System.Security;
using System.Net.NetworkInformation;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace wm.bll
{
    public class UserService
    {
        public static bool VerifyUser(string Username, string Password)
        {
            bool verifyUser = false;

            var user = UserRepository.GetAllUsers()
                .FirstOrDefault(user => user.Username == Username);

            if (user != null)
            {
                var saltedPassword = Password + user.Salt;
                Password = HashPassword(saltedPassword);
                if(user.Password == Password)
                {
                    verifyUser = true;
                }
            }

            return verifyUser;
        }
        public static void RegisterUser() 
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            while (GetUserIdByUsername(username) != -1)
            {
                Console.WriteLine("Username already in use");
                Console.Write("Username: ");
                username = Console.ReadLine();
            }

            Console.Write("Password: ");
            string password = Console.ReadLine();
            while(!CheckPassword(password))
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
            }

            Console.Write("First Name: ");
            string fName = Console.ReadLine();
            while(fName.IsNullOrEmpty())
            {
                Console.WriteLine("Must input a First Name");
                Console.Write("First Name: ");
                fName = Console.ReadLine();
            }

            Console.Write("Last Name: ");
            string lName = Console.ReadLine();
            while (lName.IsNullOrEmpty())
            {
                Console.WriteLine("Must input a Last Name");
                Console.Write("Last Name: ");
                lName = Console.ReadLine();
            }

            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            while (phone.Length < 10 || phone.Length > 15 || phone.Any(c => Char.IsLetter(c)))
            {
                Console.WriteLine("Phone not valid");
                Console.Write("Phone: ");
                phone = Console.ReadLine();
            }

            Console.Write("Email: ");
            string email = Console.ReadLine();
            while(!email.Any(c => c == '@'))
            {
                Console.WriteLine("Email invalid");
                Console.Write("Email: ");
                email = Console.ReadLine();
            }

            var user = new User(username, password, fName, lName, phone, email);
            user.Salt = GenerateSalt();
            var saltedPassword = user.Password + user.Salt;
            user.Password = HashPassword(saltedPassword);

            if (user != null) 
            {
                UserRepository.InsertUser(user);
            }
        }

        public static void UpdateUser(string username, string newUsername, string newPassword, string newFName, string newLName, string newPhone, string newEmail)
        {
            var newUserInfo = new User(newUsername, newPassword, newFName, newLName, newPhone, newEmail);

            UserRepository.UpdateUser(username, newUserInfo);
        }

        public static void DeleteUser(int id)
        {
            UserRepository.DeleteUser(id);
        }

        public static int GetUserIdByUsername(string username)
        {
            var user = UserRepository.GetUserByUsername(username);
            if(user == null)
            {
                return -1;
            }
            return user.Id;
        }

        public static bool CheckPassword(string password)
        {
            bool verifyPassword = true;

            if(string.IsNullOrEmpty(password))
            {
                verifyPassword = false;
                Console.WriteLine("Password Required!");
                return verifyPassword;
            }

            if(password.Length < 4 || password.Length > 12)
            {
                verifyPassword = false;
                Console.WriteLine("Password needs to be 4 to 12 characters");
                return verifyPassword;
            }

            if(password.Where(c => Char.IsWhiteSpace(c)).Any()) 
            {
                verifyPassword = false;
                Console.WriteLine("String has empty characters");
                return verifyPassword;
            }

            if(!password.Any(c => Char.IsDigit(c)))
            {
                verifyPassword = false;
                Console.WriteLine("Password must have a number");
                return verifyPassword;
            }

            string specialCharacters = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            if(password.Any(c => specialCharacters.Any(x => x == c)))
            {
                verifyPassword= false;
                Console.WriteLine("Password must NOT include one of these characters - \"\\| !#$%&/()=?»«@£§€{}.-;'<>_,\"");
                return verifyPassword;
            }

            return verifyPassword;
        }

        public static string GenerateSalt()
        {
            var rnd = new Random();

            var rndBytes = new byte[16];
            rnd.NextBytes(rndBytes);

            return Convert.ToHexString(rndBytes);
        }

        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            var passBytes = Encoding.Default.GetBytes(password);

            var hashedPass = Convert.ToHexString(hash.ComputeHash(passBytes));

            return hashedPass;
        }
    }
}
