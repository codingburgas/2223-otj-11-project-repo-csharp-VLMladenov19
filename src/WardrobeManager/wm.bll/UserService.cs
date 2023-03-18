﻿using Microsoft.Identity.Client;
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
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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
        public static void RegisterUser(string username, string password, string fName, string lName, string phone, string email) 
        {
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

        public static int CheckUsername(string username)
        {
            if(username.IsNullOrEmpty())
            {
                return 1;
            }
            if(username.Length < 4 || username.Length > 12)
            {
                return 2;
            }
            if(UserService.GetUserIdByUsername(username) != -1)
            {
                return 3;
            }
            return 0;
        }

        public static int CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return 1;
            }

            if (password.Length < 4 || password.Length > 12)
            {
                return 2;
            }

            if (password.Where(c => Char.IsWhiteSpace(c)).Any())
            {
                return 3;
            }

            if (!password.Any(c => Char.IsDigit(c)))
            {
                return 4;
            }

            string specialCharacters = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            if (password.Any(c => specialCharacters.Any(x => x == c)))
            {
                return 5;
            }

            return 0;
        }
        public static int CheckName(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return 1;
            }
            if (name.Any(c => Char.IsDigit(c)))
            {
                return 2;
            }
            return 0;
        }

        public static int CheckPhone(string phone)
        {
            if (phone.IsNullOrEmpty())
            {
                return 1;
            }
            if (phone.Length < 10 || phone.Length > 15)
            {
                return 2;
            }
            if (phone.Any(c => Char.IsLetter(c)))
            {
                return 3;
            }
            return 0;
        }

        public static int CheckEmail(string email)
        {
            if (email.IsNullOrEmpty())
            {
                return 1;
            }
            if (!email.Any(c => c == '@') || email.Count(c => c == '@') > 1)
            {
                return 2;
            }
            if (email.Substring(email.IndexOf('@')).Length < 4)
            {
                return 3;
            }
            return 0;
        }
    }
}
