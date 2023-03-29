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
        public static void AddOutfit(string name, DateTime date, int userId)
        {
            var outfit = new Outfit(name, date, userId);

            OutfitRepository.AddOutfit(outfit);
        }

        public static void AddClothing(string outfitName, string clothingName, int userId)
        {
            var outfit = GetOutfitsByUserId(userId)
                .FirstOrDefault(o => o.Name.ToUpper() == outfitName.ToUpper());
            var clothing = ClotheService.GetClothesByUserId(userId)
                .FirstOrDefault(c => c.Name.ToUpper() == clothingName.ToUpper());
            
            if(outfit != null && clothing != null)
            {
                var outfitClothing = new OutfitsClothe(outfit.Id, clothing.Id);
                OutfitBridgeRepository.AddRow(outfitClothing);
            }
        }

        public static int GetOutfitId(string name, int userId)
        {
            var clothing = GetOutfitsByUserId(userId).FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());

            if (clothing == null)
            {
                return -1;
            }
            return clothing.Id;
        }

        public static List<Outfit> GetOutfitsByUserId(int userId)
        {
            var outfits = OutfitRepository.GetAllOutfits()
                .Where(c => c.UserId == userId)
                .ToList();

            return outfits;
        }
    }
}
