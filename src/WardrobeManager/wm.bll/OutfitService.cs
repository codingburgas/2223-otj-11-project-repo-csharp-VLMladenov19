using Microsoft.IdentityModel.Tokens;
using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;
using wm.util;

namespace wm.bll
{
    public class OutfitService
    {
        // Retrieve all outfits
        public static List<Outfit> GetAll()
        {
            using(var context = new WardrobeManagerContext())
            {
                OutfitRepository outfitRepository = new(context);

                List<Outfit> outfits = outfitRepository.GetAll().ToList();

                return outfits;
            }
        }

        // Retrieve all user's outfits
        public static List<Outfit> GetOutfitsByUserId(int userId)
        {
            List<Outfit> outfits = GetAll()
                .Where(c => c.UserId == userId)
                .ToList();

            return outfits;
        }

        // Retrieve an outfit
        public static Outfit? GetOutfit(string outfitName, int userId)
        {
            Outfit? outfit = GetOutfitsByUserId(userId)
                .FirstOrDefault(o => o.Name.ToUpper() == outfitName.ToUpper());

            return outfit;
        }

        // Retrieve an outfit's id
        public static int GetOutfitId(string name, int userId)
        {
            Outfit? clothe = GetOutfit(name, userId);

            if (clothe == null)
            {
                return (int)ErrorCodes.InvalidObject;
            }
            return clothe.Id;
        }

        // Add an outfit to the database
        public static void AddOutfit(string name, DateTime date, int userId)
        {
            using(var context = new WardrobeManagerContext())
            {
                OutfitRepository outfitRepository = new(context);

                Outfit outfit = new Outfit()
                {
                    Name = name,
                    Date = date,
                    UserId = userId
                };

                outfitRepository.AddRow(outfit);
            }
        }

        // Edit outfit's info
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

                    outfitRepository.UpdateRow(outfit);
                }
            }
        }

        // Delete an outfit
        public static void DeleteOutfit(int outfitId)
        {
            using(var context = new WardrobeManagerContext())
            {
                OutfitRepository outfitRepository = new(context);

                OutfitBridgeService.RemoveAllByOutfitId(outfitId);

                Outfit outfit = outfitRepository.GetAll().FirstOrDefault(c => c.Id == outfitId);
                outfitRepository.DeleteRow(outfit);
            }
        }

        // Delete all outfits of an user
        public static void DeleteUsersOutfits(int userId)
        {
            List<Outfit> outfits = GetAll()
                    .Where(c => c.UserId == userId)
                    .ToList();

            if(!outfits.IsNullOrEmpty())
            {
                foreach(var c in outfits)
                {
                    DeleteOutfit(c.Id);
                }
            }
        }
    }
}
