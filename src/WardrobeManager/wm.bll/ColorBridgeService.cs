using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.bll
{
    public class ColorBridgeService
    {
        public static List<ClothesColor> GetAll()
        {
            using (var context = new WardrobeManagerContext())
            {
                ColorBridgeRepository colorBridgeRepository = new(context);

                List<ClothesColor> clothesColors = colorBridgeRepository.GetAll().ToList();

                return clothesColors;
            }
        }

        public static void AddRow(int userId, string clotheName, string colorName)
        {
            using (var context = new WardrobeManagerContext())
            {
                ColorBridgeRepository colorBridgeRepository = new(context);

                int clotheId = ClotheService.GetClotheId(clotheName, userId);
                int colorId = ColorService.GetColorId(colorName);

                ClothesColor clothesColor = new ClothesColor(clotheId, colorId);

                if (!RowExists(clothesColor))
                {
                    colorBridgeRepository.AddRows(clothesColor);
                }
            }
        }

        public static void RemoveAllByClotheId(int clotheId)
        {
            using (var context = new WardrobeManagerContext())
            {
                ColorBridgeRepository colorBridgeRepository = new(context);

                List<ClothesColor> bridgeList = colorBridgeRepository.GetAllByClotheId(clotheId).ToList();

                foreach (var c in bridgeList)
                {
                    colorBridgeRepository.RemoveRow(c);
                }
            }
        }

        public static bool RowExists(ClothesColor clothesColor)
        {
            using (var context = new WardrobeManagerContext())
            {
                ColorBridgeRepository colorBridgeRepository = new(context);

                List<ClothesColor> list = colorBridgeRepository.GetAll().ToList();
                bool flag = list
                    .Any(c => c.ClotheId == clothesColor.ClotheId && c.ColorId == clothesColor.ColorId);

                return flag;
            }
        }
    }
}
