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
        private readonly WardrobeManagerContext _context;

        public UserRepository(WardrobeManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context
                .Users
                .ToList();

            return users;
        }

        public User GetUserById(int id)
        {
            var user = _context
                .Users
                .Where(u => u.Id == id)
                .FirstOrDefault();
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = _context
                .Users
                .FirstOrDefault(u => u.Username == username);
            return user;
        }

        public void InsertRow(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public void DeleteRow(User user)
        {
            if (user != null)
            {
                _context.Users.Remove(user);

                _context.SaveChanges();
            }
        }

        public void UpdateRow(string username, User newUserInfo)
        {
            var user = _context
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

            _context.SaveChanges();
        }
    }
}
