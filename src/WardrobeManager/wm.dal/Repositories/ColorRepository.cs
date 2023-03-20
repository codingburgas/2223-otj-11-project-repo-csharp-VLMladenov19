using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;

namespace wm.dal.Repositories
{
    public class ColorRepository
    {
        public static List<Color> GetAll()
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.Colors.ToList();

                return list;
            }
        }
    }
}
