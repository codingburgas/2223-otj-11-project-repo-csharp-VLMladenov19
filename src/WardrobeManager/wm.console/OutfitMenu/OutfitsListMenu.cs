﻿using wm.bll;
using wm.util;

namespace wm.console
{
    internal class OutfitsListMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============  Outfits List  ============");
            Console.WriteLine();

            int userId = UserLog.LoggedUser.Id;

            PrintOutfitList(userId);

            Console.WriteLine($"\n{"Press [P] key to See Clothes of Outfit", 38}");
            Console.WriteLine($"{"Press [A] key to Create new Outfit", 37}");
            Console.WriteLine($"{"Press [E] key to Edit an Outfit", 36}");
            Console.WriteLine($"{"Press [D] key to Delete an Outfit", 37}\n");
            Console.WriteLine($"{"Press [C] key to Add Clothes", 35}");
            Console.WriteLine($"{"Press [R] key to Remove Clothes", 36}\n");
            Console.WriteLine($"{"Press any other key to go back", 36}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey(true).KeyChar);

            switch(input)
            {
                case 'P': PrintClothesByOutfitMenu.Print(); break;
                case 'A': AddOutfitMenu.Print(); break;
                case 'E': EditOutfitMenu.Print(); break;
                case 'D': RemoveOutfitMenu.Print(); break;
                case 'C': AddClothesToOutfitMenu.Print(); break;
                case 'R': RemoveClothesFromOutfitMenu.Print(); break;
                default: MainMenu.Print(); break;
            }
        }

        private static void PrintOutfitList(int userId)
        {
            var outfits = OutfitService.GetOutfitsByUserId(userId);

            foreach(var outfit in outfits)
            {
                var date = (outfit.Date).ToString("dd.MM.yyyy");
                Console.WriteLine($"{outfit.Name,18} : {date}");
            }
        }
    }
}
