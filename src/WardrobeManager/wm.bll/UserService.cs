using Microsoft.Identity.Client;
using System;
using wm.dal.Models;
using wm.dal.Data;
using System.Security;
using System.Net.NetworkInformation;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using wm.dal.Repositories;
using wm.util;

namespace wm.bll
{
    public class UserService
    {
        public static int GetUserIdByUsername(string username)
        {
            using (var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                User user = userRepository.GetUserByUsername(username);

                if (user == null)
                {
                    return (int)ErrorCodes.InvalidObject;
                }
                return user.Id;
            }
        }

        public static User? GetUserByUsername(string username)
        {
            using (var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                User? user = userRepository.GetAll()
                .FirstOrDefault(user => user.Username == username);

                return user;
            }
        }

        public static void RegisterUser(string username, string password, string fName, string lName, string phone, string email)
        {
            using (var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                User user = new User(username, password, fName, lName, phone, email);

                user.Salt = GenerateSalt();
                string saltedPassword = user.Password + user.Salt;
                user.Password = HashPassword(saltedPassword);

                if (user != null)
                {
                    userRepository.InsertRow(user);
                }
            }
        }

        public static void DeleteUser(int userId)
        {
            using (var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                ClotheService.RemoveUserClothes(userId);
                OutfitService.RemoveUserOutfits(userId);

                User user = userRepository.GetUserById(userId);
                userRepository.DeleteRow(user);
            }
        }

        public static void UpdateUser(User user, string username, string password, string firstName, string lastName, string phone, string email)
        {
            using (var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                if (user != null)
                {
                    user.Username = username;

                    user.Salt = GenerateSalt();
                    string saltedPassword = password + user.Salt;
                    user.Password = HashPassword(saltedPassword);

                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.Phone = phone;
                    user.Email = email;

                    userRepository.UpdateRow(user);
                }
            }
        }

        public static bool VerifyUser(string Username, string Password)
        {
            using (var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                bool verifyUser = false;

                User? user = userRepository.GetUserByUsername(Username);

                if (user != null)
                {
                    string saltedPassword = Password + user.Salt;
                    string hashedPass = HashPassword(saltedPassword);

                    if (user.Password == hashedPass)
                    {
                        verifyUser = true;
                    }
                }

                return verifyUser;
            }
        }

        public static string GenerateSalt()
        {
            Random rnd = new Random();

            byte[] rndBytes = new byte[16];
            rnd.NextBytes(rndBytes);

            string salt = Convert.ToHexString(rndBytes);

            return salt;
        }

        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            byte[] passBytes = Encoding.Default.GetBytes(password);

            string hashedPass = Convert.ToHexString(hash.ComputeHash(passBytes));

            return hashedPass;
        }

        public static int CheckUsername(string username)
        {
            if(username.IsNullOrEmpty())
            {
                return (int)ErrorCodes.NullArgument;
            }
            if(username.Length < 4 || username.Length > 12)
            {
                return (int)ErrorCodes.InvalidArgumentLength;
            }
            if(UserService.GetUserIdByUsername(username) != (int)ErrorCodes.InvalidObject)
            {
                return (int)ErrorCodes.ObjectTaken;
            }
            return (int)ErrorCodes.None;
        }

        public static int CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return (int)ErrorCodes.NullArgument;
            }

            if (password.Length < 4 || password.Length > 12)
            {
                return (int)ErrorCodes.InvalidArgumentLength;
            }

            if (password.Where(c => Char.IsWhiteSpace(c)).Any())
            {
                return (int)ErrorCodes.ArgumentHasSpaces;
            }

            if (!password.Any(c => Char.IsDigit(c)))
            {
                return (int)ErrorCodes.ArgumentHasNoNumbers;
            }

            string specialCharacters = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            if (password.Any(c => specialCharacters.Any(x => x == c)))
            {
                return (int)ErrorCodes.ArgumentHasSymbols;
            }

            return (int)ErrorCodes.None;
        }
        public static int CheckName(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return (int)ErrorCodes.NullArgument;
            }
            if (name.Any(c => Char.IsDigit(c)))
            {
                return (int)ErrorCodes.ArgumentHasNumbers;
            }
            return (int)ErrorCodes.None;
        }

        public static int CheckPhone(string phone)
        {
            if (phone.IsNullOrEmpty())
            {
                return (int)ErrorCodes.NullArgument;
            }
            if (phone.Length < 10 || phone.Length > 15)
            {
                return (int)ErrorCodes.InvalidArgumentLength;
            }
            if (phone.Any(c => Char.IsLetter(c)))
            {
                return (int)ErrorCodes.ArgumentHasLetters;
            }
            return (int)ErrorCodes.None;
        }

        public static int CheckEmail(string email)
        {
            if (email.IsNullOrEmpty())
            {
                return (int)ErrorCodes.NullArgument;
            }
            if (!email.Any(c => c == '@') || email.Count(c => c == '@') > 1)
            {
                return (int)ErrorCodes.EmailHasNoAtSign;
            }
            if (email.Substring(email.IndexOf('@')).Length < 4)
            {
                return (int)ErrorCodes.EmailHasNoDomain;
            }
            return (int)ErrorCodes.None;
        }
    }
}
