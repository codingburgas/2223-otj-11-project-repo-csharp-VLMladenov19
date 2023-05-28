using wm.dal.Models;
using wm.dal.Data;

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
            return _context.Users;
        }

        public User GetUserById(int id)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User GetUserByUsername(string username)
        {
            User? user = _context.Users
                .FirstOrDefault(u => u.Username == username);
            return user;
        }

        public void AddRow(User user)
        {
            if(user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public void UpdateRow(User user)
        {
            if(user != null)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
        }

        public void DeleteRow(User user)
        {
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
