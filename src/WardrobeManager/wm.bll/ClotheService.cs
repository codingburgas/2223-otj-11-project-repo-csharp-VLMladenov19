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
    }
}
