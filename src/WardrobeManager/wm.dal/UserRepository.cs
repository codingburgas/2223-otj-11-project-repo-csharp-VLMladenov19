using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;

namespace wm.dal
{
    public class UserRepository
    {
        public static void InsertUser(User user)
        {
            using (var context = new WardrobeManagerContext())
            {
                context.Add<User>(user);

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

        public static User GetUserById(int id)
        {
            using (var context = new WardrobeManagerContext())
            {
                var user = context.Users
                    .Where(u => u.Id == id)
                    .FirstOrDefault();
                return user;
            }
        }

        public static User GetUserByUsername(string username)
        {
            using (var context = new WardrobeManagerContext())
            {
                var user = context.Users
                    .Where(u => u.Username == username)
                    .FirstOrDefault();
                return user;
            }
        }
    }
}
