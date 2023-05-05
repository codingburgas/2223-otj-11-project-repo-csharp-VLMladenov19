using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.bll
{
    public class OutfitBridgeService
    {
        public static List<OutfitsClothe> GetAll()
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitBridgeRepository outfitBridgeRepository = new(context);

                List<OutfitsClothe> outfitsClothes = outfitBridgeRepository.GetAll().ToList();

                return outfitsClothes;
            }
        }

        public static IEnumerable<OutfitsClothe> GetOutfitClothes(int outfitId)
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitBridgeRepository outfitBridgeRepository = new(context);

                List<OutfitsClothe> list = outfitBridgeRepository.GetOutfitsClothes(outfitId).ToList();

                return list;
            }
        }

        public static void AddRow(string outfitName, string clotheName, int userId)
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitBridgeRepository outfitBridgeRepository = new(context);

                var outfit = OutfitService.GetOutfit(outfitName, userId);
                var clothe = ClotheService.GetClothe(clotheName, userId);

                if (outfit != null && clothe != null)
                {
                    OutfitsClothe outfitClothe = new OutfitsClothe(outfit.Id, clothe.Id);

                    if (!RowExists(outfitClothe))
                    {
                        outfitBridgeRepository.AddRow(outfitClothe);
                    }
                }
            }
        }

        public static void RemoveAllByClotheId(int clotheId)
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitBridgeRepository outfitBridgeRepository = new(context);

                List<OutfitsClothe> bridgeList = outfitBridgeRepository.GetAllByClotheId(clotheId).ToList();

                foreach (var c in bridgeList)
                {
                    outfitBridgeRepository.RemoveRow(c);
                }
            }
        }

        public static void RemoveAllByOutfitId(int outfitId)
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitBridgeRepository outfitBridgeRepository = new(context);

                List<OutfitsClothe> bridgeList = outfitBridgeRepository.GetOutfitsClothes(outfitId).ToList();

                foreach (var c in bridgeList)
                {
                    outfitBridgeRepository.RemoveRow(c);
                }
            }
        }

        public static bool RowExists(OutfitsClothe outfitsClothe)
        {
            List<OutfitsClothe> list = GetAll();
            bool flag = list
                .Any(o => o.OutfitId == outfitsClothe.OutfitId && o.ClotheId == outfitsClothe.ClotheId);

            return flag;
        }
    }
}
