using wm.dal.Models;
using wm.dal.Data;

namespace wm.dal.Repositories
{
    public class ClotheRepository
    {
        private readonly WardrobeManagerContext _context;

        public ClotheRepository(WardrobeManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<Clothe> GetAll()
        {
            return _context.Clothes;
        }

        public void AddRow(Clothe clothe)
        {
            if(clothe != null)
            {
                _context.Clothes.Add(clothe);
                _context.SaveChanges();
            }
        }

        public void UpdateRow(Clothe clothe)
        {
            if(clothe != null)
            {
                _context.Clothes.Update(clothe);
                _context.SaveChanges();
            }
        }

        public void DeleteRow(Clothe clothe)
        {
            if(clothe != null)
            {
                _context.Clothes.Remove(clothe);
                _context.SaveChanges();
            }
        }
    }
}
