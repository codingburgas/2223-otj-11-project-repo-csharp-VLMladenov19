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
    public class EditOutfitMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============   Edit Outfit  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            string oldOutfitName = InsertOldOutfitName(userId);
            string newOutfitName = InsertNewOutfitName(userId);

            Console.WriteLine($"\n{"Date syntax: DD.MM.YYYY",32}");
            DateTime newOutfitDate = InsertNewDate(userId);

            OutfitService.EditOutfit(oldOutfitName, newOutfitName, newOutfitDate, userId);

            Console.WriteLine($"\n{"Outfit Eddited",27}");
            Console.WriteLine($"\n{"Press [E] key to Edit another Outfit",38}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            switch (input)
            {
                case 'E': EditOutfitMenu.Print(userId); break;
                default: OutfitsListMenu.Print(userId); break;
            }
        }

        private static string InsertOldOutfitName(int userId)
        {
            Console.Write($"{"Old Name: ",24}");
            var oldOutfitName = Console.ReadLine();

            if (oldOutfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (oldOutfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            int outfitId = OutfitService.GetOutfitId(oldOutfitName, userId);
            ErrorCodes error = ErrorCodes.InvalidObject;
            if (outfitId == (int)error)
            {
                Console.WriteLine($"\n{"Outfit not found",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return oldOutfitName;
        }

        private static string InsertNewOutfitName(int userId)
        {
            Console.Write($"{"New Name: ",24}");
            var newOutfitName = Console.ReadLine();

            if (newOutfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (newOutfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            int outfitId = OutfitService.GetOutfitId(newOutfitName, userId);
            ErrorCodes error = ErrorCodes.InvalidObject;
            if (outfitId != (int)error)
            {
                Console.WriteLine($"\n{"Name already in use",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return newOutfitName;
        }

        private static DateTime InsertNewDate(int userId)
        {
            Console.Write($"{"Date: ",22}");
            var newDate = Console.ReadLine();

            if (newDate.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (newDate.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Date is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            DateTime parsedNewDate = DateTime.Parse(newDate);
            if (parsedNewDate <= DateTime.Now)
            {
                Console.WriteLine($"\n{"Date has already passed",32}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return parsedNewDate;
        }
    }
}
