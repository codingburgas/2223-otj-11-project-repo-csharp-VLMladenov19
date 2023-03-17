using Microsoft.Identity.Client;
using System;
using wm.dal.Models;
using wm.dal;
using wm.dal.Data;
using System.Security;

namespace wm.bll
{
    public class UserService
    {
        public static bool VerifyUser(string Username, string Password)
        {
            bool VerifyUser = false;

            var user = UserRepository.GetAllUsers()
                .FirstOrDefault(user => user.Username == Username);

            if (user != null)
            {
                Password += user.Salt;
                if(user.Password == Password)
                {
                    VerifyUser = true;
                }
            }

            return VerifyUser;
        }
        public static void RegisterUser(string Username, string Password, string FName, string LName, int Phone, string Email) 
        {
            var user = new User(Username, Password, FName, LName, Phone, Email);

            if (user != null) 
            {
                UserRepository.InsertUser(user);
            }
        }

        public static void UpdateUser(string username, string newUsername, string newPassword, string newFName, string newLName, int newPhone, string newEmail)
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
            return user.Id;
        }
    }
}
