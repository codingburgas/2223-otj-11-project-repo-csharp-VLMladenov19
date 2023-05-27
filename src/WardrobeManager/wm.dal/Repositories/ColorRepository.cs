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

        private readonly WardrobeManagerContext _context;

        public ColorRepository(WardrobeManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<Color> GetAll()
        {
            return _context.Colors;
        }
    }
}
