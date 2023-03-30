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
        public static List<Clothe> GetAll()
        {
            List<Clothe> clothes = ClotheRepository.GetAllClothes();

            return clothes;
        }

        public static Clothe? GetClothe(string clotheName, int userId)
        {
            Clothe? clothe = ClotheService.GetClothesByUserId(userId)
                .FirstOrDefault(c => c.Name.ToUpper() == clotheName.ToUpper());

            return clothe;
        }

        public static Clothe? GetClotheById(int clotheId)
        {
            Clothe? clothe = GetAll()
                .FirstOrDefault(c => c.Id == clotheId);

            return clothe;
        }

        public static List<Clothe> GetClothesByUserId(int userId)
        {
            List<Clothe> clothes = GetAll()
                .Where(c => c.UserId == userId)
                .ToList();

            return clothes;
        }

        public static int GetClotheId(string name, int userId)
        {
            Clothe? clothe = GetClothesByUserId(userId)
                .FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());

            if (clothe == null)
            {
                return -1;
            }
            return clothe.Id;
        }

        public static void AddClothe(string name, int userId, int typeId)
        {
            Clothe clothe = new Clothe(name, userId, typeId);

            ClotheRepository.AddClothe(clothe);
        }

        public static void RemoveClothe(int clotheId)
        {
            ColorBridgeService.RemoveAllByClotheId(clotheId);
            OutfitBridgeService.RemoveAllByClotheId(clotheId);
            ClotheRepository.RemoveClothe(clotheId);
        }

        public static void RemoveUserClothes(int userId)
        {
            List<Clothe> clothe = GetAll()
                    .Where(c => c.UserId == userId)
                    .ToList();

            if (!clothe.IsNullOrEmpty())
            {
                foreach (var c in clothe)
                {
                    RemoveClothe(c.Id);
                }
            }
        }

        public static void RemoveColorFromClothe(string clotheName, int colorId, int userId)
        {
            int clotheId = GetClotheId(clotheName, userId);
            ClothesColor? clotheColor = ColorBridgeRepository.GetAllByClotheId(clotheId).FirstOrDefault(c => c.ColorId == colorId);

            if (clotheColor != null)
            {
                ColorBridgeRepository.RemoveRow(clotheColor);
            }
        }

        public static void EditClothe(string oldClotheName, string newClotheName, int userId, int typeId)
        {
            Clothe? clothe = GetClotheById(GetClotheId(oldClotheName, userId));

            if(clothe != null)
            {
                clothe.Name = newClotheName;
                clothe.TypeId = typeId;

                ClotheRepository.EditClothe(clothe);
                ColorBridgeService.RemoveAllByClotheId(clothe.Id);
            }
        }
    }
}
