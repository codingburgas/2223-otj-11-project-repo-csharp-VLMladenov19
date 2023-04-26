using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;
using wm.dal.Repositories;
using wm.util;

namespace wm.bll
{
    public class OutfitService
    {
        public static List<Outfit> GetAll()
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitRepository outfitRepository = new(context);

                List<Outfit> outfits = outfitRepository.GetAllOutfits().ToList();

                return outfits;
            }
        }

        public static Outfit? GetOutfit(string outfitName, int userId)
        {
            Outfit? outfit = OutfitService.GetOutfitsByUserId(userId)
                .FirstOrDefault(o => o.Name.ToUpper() == outfitName.ToUpper());

            return outfit;
        }

        public static int GetOutfitId(string name, int userId)
        {
            Outfit? clothe = GetOutfitsByUserId(userId)
                .FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());

            if (clothe == null)
            {
                return (int)ErrorCodes.InvalidObject;
            }
            return clothe.Id;
        }

        public static List<Outfit> GetOutfitsByUserId(int userId)
        {
            List<Outfit> outfits = OutfitService.GetAll()
                .Where(c => c.UserId == userId)
                .ToList();

            return outfits;
        }

        public static void AddOutfit(string name, DateTime date, int userId)
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitRepository outfitRepository = new(context);

                Outfit outfit = new Outfit(name, date, userId);

                outfitRepository.AddOutfit(outfit);
            }
        }

        public static void RemoveOutfit(int outfitId)
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitRepository outfitRepository = new(context);

                OutfitBridgeService.RemoveAllByOutfitId(outfitId);
                outfitRepository.RemoveOutfit(outfitId);
            }
        }

        public static void RemoveUserOutfits(int userId)
        {
            List<Outfit> outfits = GetAll()
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

        public static void RemoveClotheFromOutfit(string outfitName, int clotheId, int userId)
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitBridgeRepository outfitBridgeRepository = new(context);

                int outfitId = GetOutfitId(outfitName, userId);
                OutfitsClothe? outfitClothe = outfitBridgeRepository.GetOutfitClothes(outfitId)
                    .FirstOrDefault(c => c.ClotheId == clotheId);

                if (outfitClothe != null)
                {
                    outfitBridgeRepository.RemoveRow(outfitClothe);
                }
            }
        }

        public static void EditOutfit(string oldName, string newName, DateTime newDate, int userId)
        {
            using (var context = new WardrobeManagerContext())
            {
                OutfitRepository outfitRepository = new(context);

                Outfit? outfit = GetOutfit(oldName, userId);

                if (outfit != null)
                {
                    outfit.Name = newName;
                    outfit.Date = newDate;

                    outfitRepository.EditOutfit(outfit);
                    OutfitBridgeService.RemoveAllByOutfitId(outfit.Id);
                }
            }
        }
    }
}
