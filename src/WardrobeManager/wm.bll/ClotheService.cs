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
    public class ClotheService
    {
        public static Clothe? GetClotheById(int clotheId)
        {
            Clothe? clothe = ClotheRepository.GetAllClothes()
                .FirstOrDefault(c => c.Id == clotheId);

            return clothe;
        }

        public static List<Clothe> GetClothesByUserId(int userId)
        {
            List<Clothe> clothes = ClotheRepository.GetAllClothes()
                .Where(c => c.UserId == userId)
                .ToList();

            return clothes;
        }

        public static void AddClothing(string name, int userId, int typeId)
        {
            Clothe clothe = new Clothe(name, userId, typeId);

            ClotheRepository.AddClothe(clothe);
        }

        public static int GetClothingId(string name, int userId)
        {
            Clothe? clothing = GetClothesByUserId(userId)
                .FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());

            if(clothing == null)
            {
                return -1;
            }
            return clothing.Id;
        }

        public static void RemoveClothing(int clothingId)
        {
            ColorBridgeService.RemoveAllByClotheId(clothingId);
            OutfitBridgeRepository.RemoveAllByClotheId(clothingId);
            ClotheRepository.RemoveClothing(clothingId);
        }

        public static void RemoveUserClothes(int userId)
        {
            List<Clothe> clothing = ClotheRepository.GetAllClothes()
                    .Where(c => c.UserId == userId)
                    .ToList();

            if (!clothing.IsNullOrEmpty())
            {
                foreach (var c in clothing)
                {
                    RemoveClothing(c.Id);
                }
            }
        }

        public static void EditClothing(string oldClothingName, string newClothingName, int userId, int typeId)
        {
            Clothe? clothing = GetClotheById(GetClothingId(oldClothingName, userId));

            if(clothing != null)
            {
                clothing.Name = newClothingName;
                clothing.TypeId = typeId;

                ClotheRepository.EditClothing(clothing);
                ColorBridgeService.RemoveAllByClotheId(clothing.Id);
            }
        }

        public static void RemoveColorFromClothing(string clothingName, int colorId, int userId)
        {
            int clothingId = GetClothingId(clothingName, userId);
            ClothesColor? clotheColor = ColorBridgeRepository.GetAllByClotheId(clothingId).FirstOrDefault(c => c.ColorId == colorId);

            if (clotheColor != null)
            {
                ColorBridgeRepository.RemoveRow(clotheColor);
            }
        }
    }
}
