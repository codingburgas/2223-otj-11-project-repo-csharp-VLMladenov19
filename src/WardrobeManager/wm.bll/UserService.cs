using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;
using System.Text;
using wm.util;

namespace wm.bll
{
    public class UserService
    {

        // Retrieve a user
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

        // Retrieva a user's id
        public static int GetUserIdByUsername(string username)
        {
            using(var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                User user = userRepository.GetUserByUsername(username);

                if(user == null)
                {
                    return (int)ErrorCodes.InvalidObject;
                }
                return user.Id;
            }
        }

        // Retrieva a user
        public static User? GetUserById(int userId)
        {
            using(var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                User user = userRepository.GetUserById(userId);

                return user;
            }
        }

        // Add user to database
        public static void RegisterUser(string username, string password, string fName, string lName, string phone, string email)
        {
            using(var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                User user = new User()
                {
                    Username = username,
                    Password = password,
                    FirstName = fName,
                    LastName = lName,
                    Phone = phone,
                    Email = email
                };

                user.Salt = GenerateSalt();
                string saltedPassword = user.Password + user.Salt;
                user.Password = HashPassword(saltedPassword);

                if(user != null)
                {
                    userRepository.AddRow(user);
                }
            }
        }

        // Edit user's info
        public static void UpdateUser(string oldUsername, string newUsername, string newPassword, string newFName, string newLName, string newPhone, string newEmail)
        {
            using(var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                User user = userRepository.GetUserByUsername(oldUsername);

                if(user != null)
                {
                    user.Username = newUsername;

                    user.Salt = GenerateSalt();
                    string saltedPassword = newPassword + user.Salt;
                    user.Password = HashPassword(saltedPassword);

                    user.FirstName = newFName;
                    user.LastName = newLName;
                    user.Phone = newPhone;
                    user.Email = newEmail;

                    userRepository.UpdateRow(user);
                }
            }
        }

        // Delete user
        public static void DeleteUser(int userId)
        {
            using(var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                ClotheService.RemoveUsersClothes(userId);
                OutfitService.DeleteUsersOutfits(userId);

                User user = userRepository.GetUserById(userId);
                userRepository.DeleteRow(user);
            }
        }

        // Verify that user exists
        public static bool VerifyUser(string Username, string Password)
        {
            using(var context = new WardrobeManagerContext())
            {
                UserRepository userRepository = new(context);

                User? user = userRepository.GetUserByUsername(Username);

                if(user != null)
                {
                    string saltedPassword = Password + user.Salt;
                    string hashedPass = HashPassword(saltedPassword);

                    if(user.Password == hashedPass)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        // Generate salt for user
        public static string GenerateSalt()
        {
            Random rnd = new Random();

            byte[] rndBytes = new byte[16];
            rnd.NextBytes(rndBytes);

            string salt = Convert.ToHexString(rndBytes);

            return salt;
        }

        // Hash password with SHA256
        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            byte[] passBytes = Encoding.Default.GetBytes(password);

            string hashedPass = Convert.ToHexString(hash.ComputeHash(passBytes));

            return hashedPass;
        }

        // Check username's viability
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

        // Check password's viability
        public static int CheckPassword(string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                return (int)ErrorCodes.NullArgument;
            }

            if(password.Length < 4 || password.Length > 12)
            {
                return (int)ErrorCodes.InvalidArgumentLength;
            }

            if(password.Where(c => Char.IsWhiteSpace(c)).Any())
            {
                return (int)ErrorCodes.ArgumentHasSpaces;
            }

            if(!password.Any(c => Char.IsDigit(c)))
            {
                return (int)ErrorCodes.ArgumentHasNoNumbers;
            }

            string specialCharacters = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            if(password.Any(c => specialCharacters.Any(x => x == c)))
            {
                return (int)ErrorCodes.ArgumentHasSymbols;
            }

            return (int)ErrorCodes.None;
        }

        // Check name's viability
        public static int CheckName(string name)
        {
            if(name.IsNullOrEmpty())
            {
                return (int)ErrorCodes.NullArgument;
            }
            if(name.Any(c => Char.IsDigit(c)))
            {
                return (int)ErrorCodes.ArgumentHasNumbers;
            }
            return (int)ErrorCodes.None;
        }

        // Check phone's viability
        public static int CheckPhone(string phone)
        {
            if(phone.IsNullOrEmpty())
            {
                return (int)ErrorCodes.NullArgument;
            }
            if(phone.Length < 10 || phone.Length > 15)
            {
                return (int)ErrorCodes.InvalidArgumentLength;
            }
            if(phone.Any(c => Char.IsLetter(c)))
            {
                return (int)ErrorCodes.ArgumentHasLetters;
            }
            return (int)ErrorCodes.None;
        }

        // Check email's viability
        public static int CheckEmail(string email)
        {
            if(email.IsNullOrEmpty())
            {
                return (int)ErrorCodes.NullArgument;
            }
            if(!email.Any(c => c == '@') || email.Count(c => c == '@') > 1)
            {
                return (int)ErrorCodes.EmailHasNoAtSign;
            }
            if(email.Substring(email.IndexOf('@')).Length < 4)
            {
                return (int)ErrorCodes.EmailHasNoDomain;
            }
            return (int)ErrorCodes.None;
        }
    }
}
