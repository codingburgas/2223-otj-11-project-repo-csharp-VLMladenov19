using wm.dal.Models;
using wm.dal.Data;

namespace wm.dal.Repositories
{
    public class ClotheColorRepository
    {
        private readonly WardrobeManagerContext _context;

        public ClotheColorRepository(WardrobeManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<ClotheColor> GetAll()
        {
            return _context.ClotheColors;
        }

        public IEnumerable<ClotheColor> GetAllByClotheId(int clotheId)
        {
            var list = _context.ClotheColors
                .Where(c => c.ClotheId == clotheId);
            return list;
        }

        public void AddRow(ClotheColor clothesColor)
        {
            if(clothesColor != null)
            {
                _context.ClotheColors.Add(clothesColor);
                _context.SaveChanges();
            }
        }

        public void DeleteRow(ClotheColor clothesColor)
        {
            if(clothesColor != null)
            {
                _context.ClotheColors.Remove(clothesColor);
                _context.SaveChanges();
            }
        }
    }
}
