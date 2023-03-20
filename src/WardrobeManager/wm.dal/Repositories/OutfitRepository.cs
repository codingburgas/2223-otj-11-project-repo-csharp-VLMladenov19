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
        public static List<Outfit> GetAllOutfits()
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.Outfits
                    .ToList();

                return list;
            }
        }

        public static void RemoveOutfit(int outfitId)
        {
            using (var context = new WardrobeManagerContext())
            {
                var outfit = context.Outfits
                    .FirstOrDefault(c => c.Id == outfitId);

                if (outfit != null)
                {
                    context.Outfits.Remove(outfit);

                    context.SaveChanges();
                }
            }
        }
    }
}
