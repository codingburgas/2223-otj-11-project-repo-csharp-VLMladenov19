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
        public static List<OutfitsClothe> GetAll()
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.OutfitsClothes
                    .ToList();

                return list;
            }
        }

        public static List<OutfitsClothe> GetAllByClotheId(int clotheId)
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.OutfitsClothes
                    .Where(c => c.ClotheId == clotheId)
                    .ToList();

                return list;
            }
        }

        public static List<OutfitsClothe> GetOutfitClothes(int outfitId)
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.OutfitsClothes
                    .Where(c => c.OutfitId == outfitId)
                    .ToList();

                return list;
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

        public static void AddRow(OutfitsClothe outfitsClothe)
        {
            using (var context = new WardrobeManagerContext())
            {
                context.OutfitsClothes.Add(outfitsClothe);

                context.SaveChanges();
            }
        }
    }
}
