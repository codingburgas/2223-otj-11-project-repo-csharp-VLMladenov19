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
            return _context.Outfits;
        }

        public void AddRow(Outfit outfit)
        {
            if(outfit != null)
            {
                _context.Outfits.Add(outfit);
                _context.SaveChanges();
            }
        }

        public void UpdateRow(Outfit outfit)
        {
            if(outfit != null)
            {
                _context.Outfits.Update(outfit);
                _context.SaveChanges();
            }
        }

        public void RemoveRow(Outfit outfit)
        {
            if(outfit != null)
            {
                _context.Outfits.Remove(outfit);
                _context.SaveChanges();
            }
        }
    }
}
