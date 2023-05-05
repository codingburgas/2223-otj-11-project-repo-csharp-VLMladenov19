using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;

namespace wm.dal.Repositories
{
    public class OutfitBridgeRepository
    {
        private readonly WardrobeManagerContext _context;

        public OutfitBridgeRepository(WardrobeManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<OutfitsClothe> GetAll()
        {
            var list = _context.OutfitsClothes
                .ToList();

            return list;
        }

        public IEnumerable<OutfitsClothe> GetAllByClotheId(int clotheId)
        {
            var list = _context.OutfitsClothes
                .Where(c => c.ClotheId == clotheId)
                .ToList();

            return list;
        }

        public IEnumerable<OutfitsClothe> GetOutfitsClothes(int outfitId)
        {
            var list = _context.OutfitsClothes
                .Where(c => c.OutfitId == outfitId)
                .ToList();

            return list;
        }

        public void AddRow(OutfitsClothe outfitsClothe)
        {
            _context.OutfitsClothes.Add(outfitsClothe);

            _context.SaveChanges();
        }

        public void RemoveRow(OutfitsClothe outfitsClothe)
        {
            if (outfitsClothe != null)
            {
                _context.OutfitsClothes.Remove(outfitsClothe);

                _context.SaveChanges();
            }
        }
    }
}
