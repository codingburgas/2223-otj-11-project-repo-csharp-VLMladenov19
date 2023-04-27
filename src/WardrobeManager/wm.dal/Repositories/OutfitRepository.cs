using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;

namespace wm.dal.Repositories
{
    public class OutfitRepository
    {

        private readonly WardrobeManagerContext _context;

        public OutfitRepository(WardrobeManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<Outfit> GetAll()
        {
            var list = _context.Outfits
                .ToList();

            return list;
        }

        public void AddRow(Outfit outfit)
        {
            _context.Outfits.Add(outfit);

            _context.SaveChanges();
        }

        public void RemoveRow(int outfitId)
        {
            var outfit = _context.Outfits
                .FirstOrDefault(c => c.Id == outfitId);

            if (outfit != null)
            {
                _context.Outfits.Remove(outfit);

                _context.SaveChanges();
            }
        }

        public void EditRow(Outfit newOutfit)
        {
            var oldOutfit = _context.Outfits
                .FirstOrDefault(c => c.Id == newOutfit.Id);

            if (oldOutfit != null)
            {
                oldOutfit.Name = newOutfit.Name;
                oldOutfit.Date = newOutfit.Date;
            }

            _context.SaveChanges();
        }
    }
}
