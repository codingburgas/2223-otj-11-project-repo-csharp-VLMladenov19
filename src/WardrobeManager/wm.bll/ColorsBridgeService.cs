using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.bll
{
    public class ColorsBridgeService
    {
        public static void AddRow(int userId, string clotheName, string colorName)
        {
            var clotheId = ClotheService.GetClotheIdByNameAndUserID(clotheName, userId);
            var colorId = ColorService.GetColorIdByName(colorName);

            ClothesColor clothesColor = new ClothesColor(clotheId, colorId);
            ColorBridgeRepository.AddRows(clothesColor);
        }
    }
}
