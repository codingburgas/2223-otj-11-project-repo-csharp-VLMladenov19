﻿using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class RemoveClothesFromOutfitMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============ Remove Clothes ============");
            Console.WriteLine($"{"Type [B] to go back", 30}\n");

            int userId = UserLog.LoggedUser.Id;

            if(OutfitService.GetOutfitsByUserId(userId).IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"User has no outfits", 29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                OutfitsListMenu.Print();
            }

            string outfitName = InsertName(userId);
            string clotheName = InsertClothe(userId);

            var clotheId = ClotheService.GetClotheId(clotheName, userId);
            OutfitBridgeService.RemoveClotheFromOutfit(outfitName, clotheId, userId);

            Console.WriteLine($"\n{"Clothe Removed", 29}");
            Console.WriteLine($"{"Press a key to back to Outfits List", 38}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey(true);
            OutfitsListMenu.Print();
        }

        private static string InsertName(int userId)
        {
            Console.Write($"{"Outfit: ", 23}");
            var outfitName = Console.ReadLine();

            if(outfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
            }
            if(outfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Outfit name is required", 31}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            if(outfitId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Outfit name is wrong or clothe does not exist", 42}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return outfitName;
        }

        private static string InsertClothe(int userId)
        {
            Console.Write($"{"Clothe: ", 24}");
            var clotheName = Console.ReadLine();

            if(clotheName.ToUpper() == "B")
            {
                ClothesListMenu.Print();
            }
            if(clotheName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Clothe is required", 30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int clotheId = ClotheService.GetClotheId(clotheName, userId);
            if(clotheId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Clothe not found", 30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return clotheName;
        }
    }
}
