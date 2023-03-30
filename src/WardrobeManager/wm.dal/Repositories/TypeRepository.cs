using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;

namespace wm.dal.Repositories
{
    public class TypeRepository
    {
        public static List<Models.Type> GetAllTypes()
        {
            using (var context = new WardrobeManagerContext())
            {
                List<Models.Type> list = context.Types
                    .ToList();

                return list;
            }
        }
    }
}
