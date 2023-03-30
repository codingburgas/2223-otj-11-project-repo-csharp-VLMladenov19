﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.console.ClotheMenu;

namespace wm.console.OutfitMenu
{
    public class AddClothesToOutfitMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============  Add Clothe  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            string outfitName = InsertOutfitName(userId);
            string clotheName = InsertClotheName(userId);

            OutfitBridgeService.AddRow(outfitName, clotheName, userId);

            Console.WriteLine($"\n{"Clothe Added",27}");
            Console.WriteLine($"{"Press [C] key to Add Clothes",35}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            switch(input)
            {
                case 'C': AddClothesToOutfitMenu.Print(userId); break;
                default: OutfitsListMenu.Print(userId); break;
            }
        }

        private static string InsertOutfitName(int userId)
        {
            Console.Write($"{"Outfit: ",23}");
            var outfitName = Console.ReadLine();

            if (outfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (outfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }
            if (OutfitService.GetOutfitId(outfitName, userId) == -1)
            {
                Console.WriteLine($"\n{"Outfit not found",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return outfitName;
        }

        private static string InsertClotheName(int userId)
        {
            Console.Write($"{"Clothe: ",24}");
            var clotheName = Console.ReadLine();

            if (clotheName.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (clotheName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }
            if (ClotheService.GetClotheId(clotheName, userId) == -1)
            {
                Console.WriteLine($"\n{"Clothe not found",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return clotheName;
        }
    }
}
