using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;

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
            var list = _context.Clothes.AsEnumerable();

            return list;
        }

        public void AddRow(Clothe clothe)
        {
            _context.Clothes.Add(clothe);
            _context.SaveChanges();
        }

        public void RemoveRow(int clotheId)
        {
            var clothe = _context.Clothes
                .FirstOrDefault(c => c.Id == clotheId);

            if(clothe != null)
            {
                _context.Clothes.Remove(clothe);

                _context.SaveChanges();
            }
        }

        public void EditRow(Clothe newClothe)
        {
            var oldClothe = _context.Clothes
                .FirstOrDefault(c => c.Id == newClothe.Id);

            if(oldClothe != null)
            {
                oldClothe.Name = newClothe.Name;
                oldClothe.TypeId = newClothe.TypeId;
            }

            _context.SaveChanges();
        }
    }
}
