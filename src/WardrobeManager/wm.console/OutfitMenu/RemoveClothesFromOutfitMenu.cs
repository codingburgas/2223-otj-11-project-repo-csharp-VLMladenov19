using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.console.ClotheMenu;
using wm.util;

namespace wm.console.OutfitMenu
{
    public class RemoveClothesFromOutfitMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============ Remove Clothes ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            if (OutfitService.GetOutfitsByUserId(userId).IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"User has no outfits",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                OutfitsListMenu.Print(userId);
            }

            string outfitName = InsertName(userId);
            string clotheName = InsertClothe(userId);

            var clotheId = ClotheService.GetClotheId(clotheName, userId);
            OutfitService.RemoveClotheFromOutfit(outfitName, clotheId, userId);

            Console.WriteLine($"\n{"Clothe Removed",29}");
            Console.WriteLine($"{"Press a key to back to Outfits List",38}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey();
            OutfitsListMenu.Print(userId);
        }

        private static string InsertName(int userId)
        {
            Console.Write($"{"Outfit: ",23}");
            var outfitName = Console.ReadLine();

            if (outfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (outfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Outfit name is required",31}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            if (outfitId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Outfit name is wrong or clothe does not exist",42}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return outfitName;
        }

        private static string InsertClothe(int userId)
        {
            Console.Write($"{"Clothe: ",24}");
            var clotheName = Console.ReadLine();

            if (clotheName.ToUpper() == "B")
            {
                ClothesListMenu.Print(userId);
            }
            if (clotheName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Clothe is required",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            int clotheId = ClotheService.GetClotheId(clotheName, userId);
            if (clotheId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Clothe not found",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return clotheName;
        }
    }
}
