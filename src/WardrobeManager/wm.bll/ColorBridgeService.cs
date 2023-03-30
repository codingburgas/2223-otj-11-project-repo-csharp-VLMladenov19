using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.bll
{
    public class ColorBridgeService
    {
        public static List<ClothesColor> GetAll()
        {
            List<ClothesColor> clothesColors = ColorBridgeRepository.GetAll();

            return clothesColors;
        }

        public static void AddRow(int userId, string clotheName, string colorName)
        {
            int clotheId = ClotheService.GetClotheId(clotheName, userId);
            int colorId = ColorService.GetColorId(colorName);

            ClothesColor clothesColor = new ClothesColor(clotheId, colorId);

            if (!RowExists(clothesColor))
            {
                ColorBridgeRepository.AddRows(clothesColor);
            }
        }

        public static void RemoveAllByClotheId(int clotheId)
        {
            List<ClothesColor> bridgeList = ColorBridgeRepository.GetAllByClotheId(clotheId);

            foreach (var c in bridgeList)
            {
                ColorBridgeRepository.RemoveRow(c);
            }
        }

        public static bool RowExists(ClothesColor clothesColor)
        {
            List<ClothesColor> list = ColorBridgeRepository.GetAll();
            bool flag = list
                .Any(c => c.ClotheId == clothesColor.ClotheId && c.ColorId == clothesColor.ColorId);

            return flag;
        }
    }
}
