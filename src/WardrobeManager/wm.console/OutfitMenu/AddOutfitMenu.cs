﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.console.ClotheMenu;

namespace wm.console.OutfitMenu
{
    public class AddOutfitMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============   Add Outfit   ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            string name = InsertName(userId);
            var date = DateTime.Today;

            OutfitService.AddOutfit(name, date, userId);

            Console.WriteLine($"\n{"Outfit Added",26}");
            Console.WriteLine($"\n{"Press [A] key to Add new Outfits",36}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'A')
                AddOutfitMenu.Print(userId);
            else
                OutfitsListMenu.Print(userId);
        }

        private static string InsertName(int userId)
        {
            Console.Write($"{"Name: ",22}");
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
            if (OutfitService.GetOutfitId(name, userId) != -1)
            {
                Console.WriteLine($"\n{"Name already in use",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return name;
        }
    }
}
