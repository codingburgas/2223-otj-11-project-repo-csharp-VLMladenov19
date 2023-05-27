using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;
using wm.dal.Repositories;
using wm.util;

namespace wm.bll
{
    public class ColorService
    {
        public static List<Color> GetAll()
        {
            using (var context = new WardrobeManagerContext())
            {
                ColorRepository colorRepository = new(context);

                List<Color> colors = colorRepository.GetAll().ToList();

                return colors;
            }
        }

        public static int GetColorId(string colorName)
        {
            using (var context = new WardrobeManagerContext())
            {
                ColorRepository colorRepository = new(context);

                Color? color = colorRepository.GetAll().FirstOrDefault(c => c.Name.ToUpper() == colorName.ToUpper());

                if(color == null)
                {
                    return (int)ErrorCodes.InvalidObject;
                }
                return color.Id;
            }
        }

        public static Color? GetColorById(int colorId)
        {
            using (var context = new WardrobeManagerContext())
            {
                ColorRepository colorRepository = new(context);

                Color? color = colorRepository.GetAll().FirstOrDefault(c => c.Id == colorId);

                return color;
            }
        }
    }
}
