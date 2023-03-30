using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.bll
{
    public class OutfitService
    {
        public static List<Outfit> GetAll()
        {
            List<Outfit> outfits = OutfitRepository.GetAllOutfits();

            return outfits;
        }

        public static Outfit? GetOutfit(string outfitName, int userId)
        {
            Outfit? outfit = OutfitService.GetOutfitsByUserId(userId)
                .FirstOrDefault(o => o.Name.ToUpper() == outfitName.ToUpper());

            return outfit;
        }

        public static void RemoveOutfit(int outfitId)
        {
            OutfitBridgeService.RemoveAllByOutfitId(outfitId);
            OutfitRepository.RemoveOutfit(outfitId);
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
        public static void AddOutfit(string name, DateTime date, int userId)
        {
            Outfit outfit = new Outfit(name, date, userId);

            OutfitRepository.AddOutfit(outfit);
        }

        public static int GetOutfitId(string name, int userId)
        {
            Outfit? clothe = GetOutfitsByUserId(userId)
                .FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());

            if (clothe == null)
            {
                return -1;
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

        public static void EditOutfit(string oldName, string newName, DateTime newDate, int userId)
        {
            Outfit? outfit = GetOutfit(oldName, userId);

            if(outfit != null)
            {
                outfit.Name = newName;
                outfit.Date = newDate;

                OutfitRepository.EditOutfit(outfit);
                OutfitBridgeService.RemoveAllByOutfitId(outfit.Id);
            }
        }

        public static void RemoveClotheFromOutfit(string outfitName, int clotheId, int userId)
        {
            int outfitId = GetOutfitId(outfitName, userId);
            OutfitsClothe? outfitClothe = OutfitBridgeRepository.GetOutfitClothes(outfitId)
                .FirstOrDefault(c => c.ClotheId == clotheId);

            if (outfitClothe != null)
            {
                OutfitBridgeRepository.RemoveRow(outfitClothe);
            }
        }
    }
}
