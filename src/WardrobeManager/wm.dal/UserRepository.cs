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
    }
}
