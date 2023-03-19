using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;

namespace wm.dal.Repositories
{
    public class UserRepository
    {
        public static void InsertUser(User user)
        {
            using (var context = new WardrobeManagerContext())
            {
                context.Add(user);

                context.SaveChanges();
            }
        }

        public static void UpdateUser(string username, User newUserInfo)
        {
            using (var context = new WardrobeManagerContext())
            {
                var user = context
                    .Users
                    .FirstOrDefault(x => x.Username == username);

                if (user != null)
                {
                    user.Username = newUserInfo.Username;
                    user.Password = newUserInfo.Password;
                    user.Salt = newUserInfo.Salt;
                    user.FirstName = newUserInfo.FirstName;
                    user.LastName = newUserInfo.LastName;
                    user.Phone = newUserInfo.Phone;
                    user.Email = newUserInfo.Email;
                }

                context.SaveChanges();
            }
        }

        public static void DeleteUser(int id)
        {
            using (var context = new WardrobeManagerContext())
            {
                var user = GetUserById(id);

                if (user != null)
                {
                    context.Users.Remove(user);

                    context.SaveChanges();
                }
            }
        }

        public static List<User> GetAllUsers()
        {
            using (var context = new WardrobeManagerContext())
            {
                var users = context
                    .Users
                    .ToList();

                return users;
            }
        }

        public static User GetUserById(int id)
        {
            using (var context = new WardrobeManagerContext())
            {
                var user = context
                    .Users
                    .Where(u => u.Id == id)
                    .FirstOrDefault();
                return user;
            }
        }

        public static User GetUserByUsername(string username)
        {
            using (var context = new WardrobeManagerContext())
            {
                var user = context
                    .Users
                    .FirstOrDefault(u => u.Username == username);
                return user;
            }
        }
    }
}
