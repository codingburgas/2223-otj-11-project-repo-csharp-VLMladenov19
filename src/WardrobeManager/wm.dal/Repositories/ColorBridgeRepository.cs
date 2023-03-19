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

        public static void RemoveAllByClotheId(int clotheId)
        {
            var bridgeList = GetAllByClotheId(clotheId);
            foreach (var c in bridgeList)
            {
                RemoveRow(c);
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
    }
}
