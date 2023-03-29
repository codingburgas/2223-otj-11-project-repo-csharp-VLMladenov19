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
            Console.WriteLine("============  Add Clothing  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            string outfitName = InsertOutfitName(userId);
            string clotheName = InsertClothingName(userId);

            OutfitsBridgeService.AddRow(outfitName, clotheName, userId);

            Console.WriteLine($"\n{"Clothing Added",27}");
            Console.WriteLine($"{"Press [C] key to Add Clothes",35}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'C')
                AddClothesToOutfitMenu.Print(userId);
            else
                OutfitsListMenu.Print(userId);
        }

        private static string InsertOutfitName(int userId)
        {
            Console.Write($"{"Outfit: ",23}");
            var name = Console.ReadLine();

            if (name.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (name.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }
            if (OutfitService.GetOutfitId(name, userId) == -1)
            {
                Console.WriteLine($"\n{"Outfit not found",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return name;
        }

        private static string InsertClothingName(int userId)
        {
            Console.Write($"{"Clothing: ",24}");
            var name = Console.ReadLine();

            if (name.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (name.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }
            if (ClotheService.GetClothingId(name, userId) == -1)
            {
                Console.WriteLine($"\n{"Clothing not found",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return name;
        }
    }
}