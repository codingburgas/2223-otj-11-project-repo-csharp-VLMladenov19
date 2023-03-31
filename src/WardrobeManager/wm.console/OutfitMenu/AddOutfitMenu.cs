using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.console.ClotheMenu;
using wm.util;

namespace wm.console.OutfitMenu
{
    public class AddOutfitMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============   Add Outfit   ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            string outfitName = InsertOutfitName(userId);

            Console.WriteLine($"\n{"Date syntax: DD.MM.YYYY",32}");
            var outfitDate = InsertOutfitDate(userId);

            OutfitService.AddOutfit(outfitName, outfitDate, userId);

            Console.WriteLine($"\n{"Outfit Added",26}");
            Console.WriteLine($"\n{"Press [A] key to Add new Outfits",36}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            switch(input)
            {
                case 'A': AddOutfitMenu.Print(userId); break;
                default: OutfitsListMenu.Print(userId); break;
            }
        }

        private static string InsertOutfitName(int userId)
        {
            Console.Write($"{"Name: ",22}");
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

            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            if (outfitId != (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Name already in use",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return outfitName;
        }

        private static DateTime InsertOutfitDate(int userId)
        {
            Console.Write($"{"Date: ",22}");
            var outfitDate = Console.ReadLine();

            if (outfitDate.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (outfitDate.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Date is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            DateTime parsedDate = DateTime.Parse(outfitDate);
            if (parsedDate < DateTime.Now)
            {
                Console.WriteLine($"\n{"Date has already passed",32}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return parsedDate;
        }
    }
}
