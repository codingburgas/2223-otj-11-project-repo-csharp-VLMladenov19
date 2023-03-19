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
        public static List<OutfitsClothe> GetAllByClotheId(int id)
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.OutfitsClothes
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

        public static void RemoveRow(OutfitsClothe outfitsClothe)
        {
            using (var context = new WardrobeManagerContext())
            {
                if (outfitsClothe != null)
                {
                    context.OutfitsClothes.Remove(outfitsClothe);

                    context.SaveChanges();
                }
            }
        }
    }
}
