using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.dal.Repositories;

namespace wm.console.ClotheMenu
{
    public class RemoveColorMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============  Remove Color  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            if (ClotheService.GetClothesByUserId(userId).IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"User has no clothes",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                ClothesListMenu.Print(userId);
            }

            string clothingName = InsertName(userId);
            string colorName = InsertColor(userId);
            var colorId = ColorService.GetColorIdByName(colorName);

            ClotheService.RemoveColorFromClothing(clothingName, colorId, userId);

            Console.WriteLine($"\n{"Color Removed",27}");
            Console.WriteLine($"{"Press a key to back to Clothes List",38}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey();
            ClothesListMenu.Print(userId);
        }

        private static string InsertName(int userId)
        {
            Console.Write($"{"Name: ",22}");
            var name = Console.ReadLine();

            if (name.ToUpper() == "B")
            {
                ClothesListMenu.Print(userId);
            }
            if (name.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            int clothingId = ClotheService.GetClothingId(name, userId);
            if (clothingId == -1)
            {
                Console.WriteLine($"\n{"Name is wrong or clothe does not exist",39}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return name;
        }

        private static string InsertColor(int userId)
        {
            Console.Write($"{"Color: ",22}");
            var colorName = Console.ReadLine();

            if (colorName.ToUpper() == "B")
            {
                ClothesListMenu.Print(userId);
            }
            if (colorName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Color is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }
            if (ColorService.GetColorIdByName(colorName) == -1)
            {
                Console.WriteLine($"\n{"Color not found",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return colorName;
        }
    }
}
