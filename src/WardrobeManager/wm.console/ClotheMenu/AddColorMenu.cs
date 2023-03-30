﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;

namespace wm.console.ClotheMenu
{
    public class AddColorMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============   Add Colors   ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            string clotheName = InsertClotheName(userId);
            string colorName = InsertColorName(userId);

            ColorBridgeService.AddRow(userId, clotheName, colorName);

            Console.WriteLine($"\n{"Color Added",25}");
            Console.WriteLine($"{"Press [C] key to Add more Colors",36}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            switch (input)
            {
                case 'C': AddColorMenu.Print(userId); break;
                default: ClothesListMenu.Print(userId); break;
            }
        }

        private static string InsertClotheName(int userId)
        {
            Console.Write($"{"Clothe name: ",25}");
            var clotheName = Console.ReadLine();

            if (clotheName.ToUpper() == "B")
            {
                ClothesListMenu.Print(userId);
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
                Console.WriteLine($"\n{"Clothe not found",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return clotheName;
        }

        private static string InsertColorName(int userId)
        {
            Console.Write($"{"Color name: ",24}");
            var colorName = Console.ReadLine();

            if (colorName.ToUpper() == "B")
            {
                MainMenu.Print();
            }
            if (colorName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Color is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }
            if (ColorService.GetColorId(colorName) == -1)
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
