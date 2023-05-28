using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;
using wm.util;

namespace wm.bll
{
    public class ColorService
    {
        // Retrieve all colors
        public static List<Color> GetAll()
        {
            using(var context = new WardrobeManagerContext())
            {
                ColorRepository colorRepository = new(context);

                List<Color> colors = colorRepository.GetAll().ToList();

                return colors;
            }
        }

        // Retrieve a color's id
        public static int GetColorId(string colorName)
        {
            using(var context = new WardrobeManagerContext())
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
    }
}
