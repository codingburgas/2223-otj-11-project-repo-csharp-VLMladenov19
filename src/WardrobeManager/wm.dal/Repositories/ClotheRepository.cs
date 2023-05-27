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

        public void RemoveRow(Clothe clothe)
        {
            if(clothe != null)
            {
                _context.Clothes.Remove(clothe);
                _context.SaveChanges();
            }
        }
    }
}
