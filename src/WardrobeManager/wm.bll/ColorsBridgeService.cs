﻿using System;
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
        public static List<ClothesColor> GetAll()
        {
            var list = ColorBridgeRepository.GetAll();

            return list;
        }

        public static void AddRow(int userId, string clotheName, string colorName)
        {
            var clotheId = ClotheService.GetClotheIdByNameAndUserID(clotheName, userId);
            var colorId = ColorService.GetColorIdByName(colorName);

            ClothesColor clothesColor = new ClothesColor(clotheId, colorId);

            if(RowExists(clothesColor))
            {
                return;
            }
            else
            {
                ColorBridgeRepository.AddRows(clothesColor);
            }
        }

        public static bool RowExists(ClothesColor clothesColor)
        {
            var list = ColorBridgeRepository.GetAll();
            bool flag = list.Any(c => c.ClotheId == clothesColor.ClotheId && c.ColorId == clothesColor.ColorId);

            return flag;
        }
    }
}
