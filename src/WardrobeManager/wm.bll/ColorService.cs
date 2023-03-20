using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.bll
{
    public class ColorService
    {
        public static int GetColorIdByName(string colorName)
        {
            var color = ColorRepository.GetAll().FirstOrDefault(c => c.Name.ToUpper() == colorName.ToUpper());

            if(color == null)
            {
                return -1;
            }
            return color.Id;
        }

        public static Color GetColorById(int colorId)
        {
            Color color = ColorRepository.GetAll().FirstOrDefault(c => c.Id == colorId);

            return color;
        }
    }
}
