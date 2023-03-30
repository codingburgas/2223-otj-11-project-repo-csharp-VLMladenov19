using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.console.ClotheMenu;

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
            string clothingName = InsertColor(userId);

            var clothingId = ClotheService.GetClothingId(clothingName, userId);
            OutfitService.RemoveClothingFromOutfit(outfitName, clothingId, userId);

            Console.WriteLine($"\n{"Clothing Removed",29}");
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
            if (OutfitService.GetOutfitId(outfitName, userId) == -1)
            {
                Console.WriteLine($"\n{"Outfit name is wrong or clothe does not exist",42}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return outfitName;
        }

        private static string InsertColor(int userId)
        {
            Console.Write($"{"Clothing: ",24}");
            var clothingName = Console.ReadLine();

            if (clothingName.ToUpper() == "B")
            {
                ClothesListMenu.Print(userId);
            }
            if (clothingName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Clothing is required",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }
            if (ClotheService.GetClotheIdByNameAndUserID(clothingName, userId) == -1)
            {
                Console.WriteLine($"\n{"Clothing not found",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return clothingName;
        }
    }
}
