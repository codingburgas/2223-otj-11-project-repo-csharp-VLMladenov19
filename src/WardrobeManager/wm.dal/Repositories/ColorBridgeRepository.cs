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
        public static List<ClothesColor> GetAll()
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.ClothesColors
                    .ToList();

                return list;
            }
        }
        public static List<ClothesColor> GetAllByClotheId(int id)
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.ClothesColors
                    .Where(c => c.ClotheId == id)
                    .ToList();

                return list;
            }
        }

        public static void RemoveRow(ClothesColor clothesColor)
        {
            using (var context = new WardrobeManagerContext())
            {
                if(clothesColor != null)
                {
                    context.ClothesColors.Remove(clothesColor);

                    context.SaveChanges();
                }
            }
        }

        public static void AddRows(ClothesColor clothesColor)
        {
            using (var context = new WardrobeManagerContext())
            {
                if(clothesColor != null)
                {
                    context.ClothesColors.Add(clothesColor);

                    context.SaveChanges();
                }
            }
        }
    }
}
