using wm.dal.Models;
using wm.dal.Data;

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
