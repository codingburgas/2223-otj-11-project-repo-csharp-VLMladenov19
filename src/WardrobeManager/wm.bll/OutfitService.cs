using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Repositories;

namespace wm.bll
{
    public class OutfitService
    {
        public static void RemoveOutfit(int outfitId)
        {
            OutfitBridgeRepository.RemoveAllByOutfitId(outfitId);
            OutfitRepository.RemoveOutfit(outfitId);
        }

        public static void RemoveOutfitByUserId(int userId)
        {
            var outfits = OutfitRepository.GetAllOutfits()
                    .Where(c => c.UserId == userId)
                    .ToList();

            if (!outfits.IsNullOrEmpty())
            {
                foreach (var c in outfits)
                {
                    RemoveOutfit(c.Id);
                }
            }
        }
    }
}
