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
        private readonly WardrobeManagerContext _context;

        public TypeRepository(WardrobeManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.Type> GetAll()
        {
            List<Models.Type> list = _context.Types
                .ToList();

            return list;
        }
    }
}
