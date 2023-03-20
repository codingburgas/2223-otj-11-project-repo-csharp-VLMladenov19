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
        public static Clothe GetClotheById(int clotheId)
        {
            Clothe clothe = ClotheRepository.GetAllClothes().FirstOrDefault(c => c.Id == clotheId);

            return clothe;
        }

        public static int GetClotheIdByNameAndUserID(string name, int userId)
        {
            var clotheId = GetClothesByUserId(userId).FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());

            if(clotheId == null)
            {
                return -1;
            }
            return clotheId.Id;
        }

        public static List<Clothe> GetClothesByUserId(int userId)
        {
            var clothes = ClotheRepository.GetAllClothes()
                .Where(c => c.UserId == userId)
                .ToList();

            return clothes;
        }

        public static void AddClothing(string name, int userId, int typeId)
        {
            var clothe = new Clothe(name, userId, typeId);

            ClotheRepository.AddClothe(clothe);
        }

        public static int GetClothingId(string name, int userId)
        {
            var clothing = GetClothesByUserId(userId).FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());

            if(clothing == null)
            {
                return -1;
            }
            return clothing.Id;
        }

        public static void RemoveClothing(int clothingId)
        {
            ColorBridgeRepository.RemoveAllByClotheId(clothingId);
            OutfitBridgeRepository.RemoveAllByClotheId(clothingId);
            ClotheRepository.RemoveClothing(clothingId);
        }

        public static void RemoveClotingByUserId(int userId)
        {
            var clothing = ClotheRepository.GetAllClothes()
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
    }
}
