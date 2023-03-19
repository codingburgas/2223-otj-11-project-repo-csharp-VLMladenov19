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
        public static List<Clothe> GetAllClothes()
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.Clothes
                    .ToList();

                return list;
            }
        }

        public static void AddClothe(Clothe clothe)
        {
            using (var context = new WardrobeManagerContext())
            {
                context.Clothes.Add(clothe);

                context.SaveChanges();
            }
        }

        public static void RemoveClothing(int id)
        {
            using (var context = new WardrobeManagerContext())
            {
                var clothing = context.Clothes
                    .FirstOrDefault(c => c.Id == id);

                if(clothing != null)
                {
                    ColorBridgeRepository.RemoveAllByUserId(id);
                    OutfitBridgeRepository.RemoveAllByUserId(id);

                    context.Clothes.Remove(clothing);

                    context.SaveChanges();
                }
            }
        }
    }
}
