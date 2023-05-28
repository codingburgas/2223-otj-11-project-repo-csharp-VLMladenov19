using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;

namespace wm.bll
{
    public class OutfitBridgeService
    {
        // Retrieve all outfit's clothes
        public static List<OutfitClothe> GetAll()
        {
            using(var context = new WardrobeManagerContext())
            {
                OutfitClotheRepository outfitBridgeRepository = new(context);

                List<OutfitClothe> outfitsClothes = outfitBridgeRepository.GetAll().ToList();

                return outfitsClothes;
            }
        }

        // Retrieve all clothes of an outfit
        public static List<OutfitClothe> GetOutfitClothes(int outfitId)
        {
            using(var context = new WardrobeManagerContext())
            {
                OutfitClotheRepository outfitBridgeRepository = new(context);

                List<OutfitClothe> list = outfitBridgeRepository.GetAllByOutfitId(outfitId).ToList();

                return list;
            }
        }

        // Add a clothing to an outfit
        public static void AddRow(string outfitName, string clotheName, int userId)
        {
            using(var context = new WardrobeManagerContext())
            {
                OutfitClotheRepository outfitBridgeRepository = new(context);

                var outfit = OutfitService.GetOutfit(outfitName, userId);
                var clothe = ClotheService.GetClothe(clotheName, userId);

                if(outfit != null && clothe != null)
                {
                    OutfitClothe outfitClothe = new OutfitClothe()
                    {
                        OutfitId = outfit.Id,
                        ClotheId = clothe.Id,
                    };

                    if(!RowExists(outfitClothe))
                    {
                        outfitBridgeRepository.AddRow(outfitClothe);
                    }
                }
            }
        }

        // Remove all by clothing
        public static void RemoveAllByClotheId(int clotheId)
        {
            using(var context = new WardrobeManagerContext())
            {
                OutfitClotheRepository outfitBridgeRepository = new(context);

                List<OutfitClothe> bridgeList = outfitBridgeRepository.GetAllByClotheId(clotheId).ToList();

                foreach(var c in bridgeList)
                {
                    outfitBridgeRepository.DeleteRow(c);
                }
            }
        }

        // Remove all by outfit
        public static void RemoveAllByOutfitId(int outfitId)
        {
            using(var context = new WardrobeManagerContext())
            {
                OutfitClotheRepository outfitBridgeRepository = new(context);

                List<OutfitClothe> bridgeList = outfitBridgeRepository.GetAllByOutfitId(outfitId).ToList();

                foreach(var c in bridgeList)
                {
                    outfitBridgeRepository.DeleteRow(c);
                }
            }
        }

        // Remove a clothing from an outfit
        public static void RemoveClotheFromOutfit(string outfitName, int clotheId, int userId)
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitClotheRepository outfitBridgeRepository = new(context);

                int outfitId = OutfitService.GetOutfitId(outfitName, userId);
                OutfitClothe? outfitClothe = outfitBridgeRepository.GetAllByOutfitId(outfitId)
                    .FirstOrDefault(c => c.ClotheId == clotheId);

                if (outfitClothe != null)
                {
                    outfitBridgeRepository.DeleteRow(outfitClothe);
                }
            }
        }

        // Check if clothing is already added to an outfit
        public static bool RowExists(OutfitClothe outfitsClothe)
        {
            List<OutfitClothe> list = GetAll();
            bool flag = list
                .Any(o => o.OutfitId == outfitsClothe.OutfitId && o.ClotheId == outfitsClothe.ClotheId);

            return flag;
        }
    }
}
