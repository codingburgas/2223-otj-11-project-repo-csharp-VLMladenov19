using Azure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;

namespace wm.dal.Repositories
{
    public class ColorBridgeRepository
    {
        private readonly WardrobeManagerContext _context;

        public ColorBridgeRepository(WardrobeManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<ClothesColor> GetAll()
        {
            var list = _context.ClothesColors
                .ToList();

            return list;
        }
        public IEnumerable<ClothesColor> GetAllByClotheId(int id)
        {
            var list = _context.ClothesColors
                .Where(c => c.ClotheId == id)
                .ToList();

            return list;
        }

        public void AddRows(ClothesColor clothesColor)
        {
            if (clothesColor != null)
            {
                _context.ClothesColors.Add(clothesColor);

                _context.SaveChanges();
            }
        }

        public void RemoveRow(ClothesColor clothesColor)
        {
            if(clothesColor != null)
            {
                _context.ClothesColors.Remove(clothesColor);

                _context.SaveChanges();
            }
        }
    }
}
