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
                var clothing = context.Clothes.FirstOrDefault(c => c.Id == id);
                var colorsBridge = context.ClothesColors
                    .Where(i => i.ClotheId == id)
                    .ToList();
                foreach (var row in colorsBridge)
                {
                    context.ClothesColors.Remove(row);
                }

                context.Clothes.Remove(clothing);

                context.SaveChanges();
            }
        }
    }
}
