using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class RemoveColorMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============  Remove Color  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            int userId = UserLog.LoggedUser.Id;

            if(ClotheService.GetClothesByUserId(userId).IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"User has no clothes",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                ClothesListMenu.Print();
            }

            string clotheName = InsertName(userId);
            int colorId = InsertColor(userId);

            ClotheService.RemoveColorFromClothe(clotheName, colorId, userId);

            Console.WriteLine($"\n{"Color Removed",27}");
            Console.WriteLine($"{"Press a key to back to Clothes List",38}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey(true);
            ClothesListMenu.Print();
        }

        private static string InsertName(int userId)
        {
            Console.Write($"{"Name: ",22}");
            var clotheName = Console.ReadLine();

            if(clotheName.ToUpper() == "B")
            {
                ClothesListMenu.Print();
            }
            if(clotheName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int clotheId = ClotheService.GetClotheId(clotheName, userId);
            if(clotheId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Name is wrong or clothe does not exist",39}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return clotheName;
        }

        private static int InsertColor(int userId)
        {
            Console.Write($"{"Color: ",22}");
            var colorName = Console.ReadLine();

            if(colorName.ToUpper() == "B")
            {
                ClothesListMenu.Print();
            }
            if(colorName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Color is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int colorId = ColorService.GetColorId(colorName);
            if(colorId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Color not found",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return colorId;
        }
    }
}
