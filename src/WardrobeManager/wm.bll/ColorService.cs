using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Models;
using wm.dal.Repositories;
using wm.util;

namespace wm.bll
{
    public class ColorService
    {
        public static List<Color> GetAll()
        {
            List<Color> colors = ColorRepository.GetAll();

            return colors;
        }

        public static int GetColorId(string colorName)
        {
            Color? color = ColorRepository.GetAll()
                .FirstOrDefault(c => c.Name.ToUpper() == colorName.ToUpper());

            if(color == null)
            {
                ErrorCodes error = ErrorCodes.InvalidObject;
                return (int)error;
            }
            return color.Id;
        }

        public static Color? GetColorById(int colorId)
        {
            Color? color = ColorRepository.GetAll().FirstOrDefault(c => c.Id == colorId);

            return color;
        }
    }
}
