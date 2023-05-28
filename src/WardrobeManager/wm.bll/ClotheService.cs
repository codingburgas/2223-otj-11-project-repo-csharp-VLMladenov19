using Microsoft.IdentityModel.Tokens;
using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;
using wm.util;

namespace wm.bll
{
    public class ClotheService
    {
        // Retrieve all clothes
        public static List<Clothe> GetAll()
        {
            using(var context = new WardrobeManagerContext())
            {
                var clotheRepository = new ClotheRepository(context);

                List<Clothe> clothes = clotheRepository.GetAll().ToList();

                return clothes;
            }
        }

        // Retrieve a clothing by name and user
        public static Clothe? GetClothe(string clotheName, int userId)
        {
            Clothe? clothe = GetClothesByUserId(userId)
                .FirstOrDefault(c => c.Name.ToUpper() == clotheName.ToUpper());

            return clothe;
        }

        // Retrieve clothing by id
        public static Clothe? GetClotheById(int clotheId)
        {
            Clothe? clothe = GetAll()
                .FirstOrDefault(c => c.Id == clotheId);

            return clothe;
        }

        // Retrieve all of user's clothes
        public static List<Clothe> GetClothesByUserId(int userId)
        {
            List<Clothe> clothes = GetAll()
                .Where(c => c.UserId == userId)
                .ToList();

            return clothes;
        }

        // Retrieve id of clothing by name and userId
        public static int GetClotheId(string name, int userId)
        {
            Clothe? clothe = GetClothesByUserId(userId)
                .FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());

            if(clothe == null)
            {
                return (int)ErrorCodes.InvalidObject;
            }
            return clothe.Id;
        }

        // Add clothing to the database
        public static void AddClothe(string name, int userId, int typeId)
        {
            using(var context = new WardrobeManagerContext())
            {
                var clotheRepository = new ClotheRepository(context);

                Clothe clothe = new Clothe()
                {
                    Name = name,
                    UserId = userId,
                    TypeId = typeId
                };

                clotheRepository.AddRow(clothe);
            }
        }

        // Edit a clothing's info
        public static void EditClothe(string oldClotheName, string newClotheName, int typeId, int userId)
        {
            using (var context = new WardrobeManagerContext())
            {
                var clotheRepository = new ClotheRepository(context);
                Clothe? clothe = GetClotheById(GetClotheId(oldClotheName, userId));

                if (clothe != null)
                {
                    clothe.Name = newClotheName;
                    clothe.TypeId = typeId;

                    clotheRepository.UpdateRow(clothe);
                }
            }
        }

        // Delete a clothing
        public static void DeleteClothe(int clotheId)
        {
            using(var context = new WardrobeManagerContext())
            {
                var clotheRepository = new ClotheRepository(context);

                ColorBridgeService.RemoveAllByClotheId(clotheId);
                OutfitBridgeService.RemoveAllByClotheId(clotheId);

                Clothe clothe = clotheRepository.GetAll().FirstOrDefault(c => c.Id == clotheId);
                clotheRepository.DeleteRow(clothe);
            }
        }

        // Delete all of user's clothes
        public static void RemoveUsersClothes(int userId)
        {
            List<Clothe> clothe = GetAll()
                    .Where(c => c.UserId == userId)
                    .ToList();

            if(!clothe.IsNullOrEmpty())
            {
                foreach(var c in clothe)
                {
                    DeleteClothe(c.Id);
                }
            }
        }

        // Remove a color from a clothing
        public static void RemoveColorFromClothe(string clotheName, int colorId, int userId)
        {
            using(var context = new WardrobeManagerContext())
            {
                ClotheColorRepository colorBridgeRepository = new(context);

                int clotheId = GetClotheId(clotheName, userId);
                ClotheColor? clotheColor = colorBridgeRepository.GetAllByClotheId(clotheId).FirstOrDefault(c => c.ColorId == colorId);

                if(clotheColor != null)
                {
                    colorBridgeRepository.DeleteRow(clotheColor);
                }
            }
        }
    }
}
