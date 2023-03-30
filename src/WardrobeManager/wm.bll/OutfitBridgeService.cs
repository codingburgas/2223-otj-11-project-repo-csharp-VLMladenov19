using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.bll
{
    public class OutfitBridgeService
    {
        public static List<OutfitsClothe> GetAll()
        {
            List<OutfitsClothe> outfitsClothes = OutfitBridgeRepository.GetAll();

            return outfitsClothes;
        }

        public static bool RowExists(OutfitsClothe outfitsClothe)
        {
            List<OutfitsClothe> list = GetAll();
            bool flag = list
                .Any(o => o.OutfitId == outfitsClothe.OutfitId && o.ClotheId == outfitsClothe.ClotheId);

            return flag;
        }

        public static void AddRow(string outfitName, string clotheName, int userId)
        {
            var outfit = OutfitService.GetOutfit(outfitName, userId);
            var clothe = ClotheService.GetClothe(clotheName, userId);

            if (outfit != null && clothe != null)
            {
                OutfitsClothe outfitClothe = new OutfitsClothe(outfit.Id, clothe.Id);

                if(!RowExists(outfitClothe))
                {
                    OutfitBridgeRepository.AddRow(outfitClothe);
                }
            }
        }

        public static void RemoveAllByClotheId(int clotheId)
        {
            var bridgeList = OutfitBridgeRepository.GetAllByClotheId(clotheId);
            foreach (var c in bridgeList)
            {
                OutfitBridgeRepository.RemoveRow(c);
            }
        }

        public static void RemoveAllByOutfitId(int outfitId)
        {
            var bridgeList = OutfitBridgeRepository.GetOutfitClothes(outfitId);
            foreach (var c in bridgeList)
            {
                OutfitBridgeRepository.RemoveRow(c);
            }
        }
    }
}
