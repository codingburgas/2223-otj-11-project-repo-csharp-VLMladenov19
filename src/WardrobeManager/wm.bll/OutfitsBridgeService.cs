using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.bll
{
    public class OutfitsBridgeService
    {
        public static bool RowExists(OutfitsClothe outfitsClothe)
        {
            var list = OutfitBridgeRepository.GetAll();
            bool flag = list.Any(o => o.OutfitId == outfitsClothe.OutfitId && o.ClotheId == outfitsClothe.ClotheId);;

            return flag;
        }

        public static void AddRow(string outfitName, string clothingName, int userId)
        {
            var outfit = OutfitService.GetOutfitsByUserId(userId)
                .FirstOrDefault(o => o.Name.ToUpper() == outfitName.ToUpper());
            var clothing = ClotheService.GetClothesByUserId(userId)
                .FirstOrDefault(c => c.Name.ToUpper() == clothingName.ToUpper());

            if (outfit != null && clothing != null)
            {
                var outfitClothing = new OutfitsClothe(outfit.Id, clothing.Id);

                if(RowExists(outfitClothing))
                {
                    return;
                }
                else
                {
                    OutfitBridgeRepository.AddRow(outfitClothing);
                }
            }
        }
    }
}
