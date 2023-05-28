using wm.dal.Models;
using wm.dal.Data;

namespace wm.dal.Repositories
{
    public class OutfitClotheRepository
    {
        private readonly WardrobeManagerContext _context;

        public OutfitClotheRepository(WardrobeManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<OutfitClothe> GetAll()
        {
            return _context.OutfitClothes;
        }

        public IEnumerable<OutfitClothe> GetAllByClotheId(int clotheId)
        {
            var list = _context.OutfitClothes
                .Where(c => c.ClotheId == clotheId);
            return list;
        }

        public IEnumerable<OutfitClothe> GetAllByOutfitId(int outfitId)
        {
            var list = _context.OutfitClothes
                .Where(c => c.OutfitId == outfitId);
            return list;
        }

        public void AddRow(OutfitClothe outfitsClothe)
        {
            if(outfitsClothe != null)
            {
                _context.OutfitClothes.Add(outfitsClothe);
                _context.SaveChanges();
            }
        }

        public void DeleteRow(OutfitClothe outfitsClothe)
        {
            if(outfitsClothe != null)
            {
                _context.OutfitClothes.Remove(outfitsClothe);
                _context.SaveChanges();
            }
        }
    }
}
