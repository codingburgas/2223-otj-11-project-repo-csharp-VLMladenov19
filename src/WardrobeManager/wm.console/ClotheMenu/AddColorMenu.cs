using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class AddColorMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============   Add Colors   ============");
            Console.WriteLine($"{"Type [B] to go back", 30}\n");

            int userId = UserLog.LoggedUser.Id;

            string clotheName = InsertClotheName(userId);
            string colorName = InsertColorName(userId);

            ColorBridgeService.AddRow(userId, clotheName, colorName);

            Console.WriteLine($"\n{"Color Added", 25}");
            Console.WriteLine($"{"Press [C] key to Add more Colors", 36}");
            Console.WriteLine($"{"or any other key to go back", 34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey(true).KeyChar);
            switch (input)
            {
                case 'C': AddColorMenu.Print(); break;
                default: ClothesListMenu.Print(); break;
            }
        }

        private static string InsertClotheName(int userId)
        {
            Console.Write($"{"Clothe name: ", 25}");
            var clotheName = Console.ReadLine();

            if(clotheName.ToUpper() == "B")
            {
                ClothesListMenu.Print();
            }
            if(clotheName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int clotheId = ClotheService.GetClotheId(clotheName, userId);
            if(clotheId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Clothe not found", 28}");
                Console.WriteLine($"\n============================= ===========");
                Console.ReadKey(true);
                Print();
            }

            return clotheName;
        }

        private static string InsertColorName(int userId)
        {
            Console.Write($"{"Color name: ", 24}");
            var colorName = Console.ReadLine();

            if(colorName.ToUpper() == "B")
            {
                MainMenu.Print();
            }
            if(colorName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Color is required", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int colorId = ColorService.GetColorId(colorName);
            if(colorId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Color not found", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return colorName;
        }
    }
}
