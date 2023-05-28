using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;

namespace wm.bll
{
    public class ColorBridgeService
    {
        // Retrieve all clothing's colors
        public static List<ClotheColor> GetAll()
        {
            using(var context = new WardrobeManagerContext())
            {
                ClotheColorRepository colorBridgeRepository = new(context);

                List<ClotheColor> clothesColors = colorBridgeRepository.GetAll().ToList();

                return clothesColors;
            }
        }

        // Add a color to clothing
        public static void AddRow(int userId, string clotheName, string colorName)
        {
            using(var context = new WardrobeManagerContext())
            {
                ClotheColorRepository colorBridgeRepository = new(context);

                int clotheId = ClotheService.GetClotheId(clotheName, userId);
                int colorId = ColorService.GetColorId(colorName);

                ClotheColor clothesColor = new ClotheColor()
                {
                    ClotheId = clotheId,
                    ColorId = colorId
                };

                if(!RowExists(clothesColor))
                {
                    colorBridgeRepository.AddRow(clothesColor);
                }
            }
        }

        // Remove all colors of a clothing
        public static void RemoveAllByClotheId(int clotheId)
        {
            using(var context = new WardrobeManagerContext())
            {
                ClotheColorRepository colorBridgeRepository = new(context);

                List<ClotheColor> bridgeList = colorBridgeRepository.GetAllByClotheId(clotheId).ToList();

                foreach(var c in bridgeList)
                {
                    colorBridgeRepository.DeleteRow(c);
                }
            }
        }

        // Check if color is already added to a clothing
        public static bool RowExists(ClotheColor clothesColor)
        {
            using(var context = new WardrobeManagerContext())
            {
                ClotheColorRepository colorBridgeRepository = new(context);

                List<ClotheColor> list = colorBridgeRepository.GetAll().ToList();
                bool flag = list
                    .Any(c => c.ClotheId == clothesColor.ClotheId && c.ColorId == clothesColor.ColorId);

                return flag;
            }
        }
    }
}
