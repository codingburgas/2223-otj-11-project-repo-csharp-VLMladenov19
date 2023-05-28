using wm.dal.Data;

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
            return _context.Types;
        }
    }
}
