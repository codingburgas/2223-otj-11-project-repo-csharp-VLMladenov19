using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class AddClothesToOutfitMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============  Add Clothe  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            int userId = UserLog.LoggedUser.Id;

            string outfitName = InsertOutfitName(userId);
            string clotheName = InsertClotheName(userId);

            OutfitBridgeService.AddRow(outfitName, clotheName, userId);

            Console.WriteLine($"\n{"Clothe Added",27}");
            Console.WriteLine($"{"Press [C] key to Add Clothes",35}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey(true).KeyChar);
            switch(input)
            {
                case 'C': AddClothesToOutfitMenu.Print(); break;
                default: OutfitsListMenu.Print(); break;
            }
        }

        private static string InsertOutfitName(int userId)
        {
            Console.Write($"{"Outfit: ",23}");
            var outfitName = Console.ReadLine();

            if(outfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
            }
            if(outfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            if(outfitId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Outfit not found",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return outfitName;
        }

        private static string InsertClotheName(int userId)
        {
            Console.Write($"{"Clothe: ",24}");
            var clotheName = Console.ReadLine();

            if(clotheName.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
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
                Console.WriteLine($"\n{"Clothe not found",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return clotheName;
        }
    }
}
