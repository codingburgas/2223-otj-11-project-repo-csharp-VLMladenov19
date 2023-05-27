using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class EditOutfitMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============   Edit Outfit  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            int userId = UserLog.LoggedUser.Id;

            string oldOutfitName = InsertOldOutfitName(userId);
            string newOutfitName = InsertNewOutfitName(userId);

            Console.WriteLine($"\n{"Date syntax: DD.MM.YYYY",32}");
            DateTime newOutfitDate = InsertNewDate(userId);

            OutfitService.EditOutfit(oldOutfitName, newOutfitName, newOutfitDate, userId);

            Console.WriteLine($"\n{"Outfit Eddited",27}");
            Console.WriteLine($"\n{"Press [E] key to Edit another Outfit",38}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey(true).KeyChar);
            switch (input)
            {
                case 'E': EditOutfitMenu.Print(); break;
                default: OutfitsListMenu.Print(); break;
            }
        }

        private static string InsertOldOutfitName(int userId)
        {
            Console.Write($"{"Old Name: ",24}");
            var oldOutfitName = Console.ReadLine();

            if(oldOutfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
            }
            if(oldOutfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int outfitId = OutfitService.GetOutfitId(oldOutfitName, userId);
            if(outfitId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Outfit not found",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return oldOutfitName;
        }

        private static string InsertNewOutfitName(int userId)
        {
            Console.Write($"{"New Name: ",24}");
            var newOutfitName = Console.ReadLine();

            if(newOutfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
            }
            if(newOutfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int outfitId = OutfitService.GetOutfitId(newOutfitName, userId);
            if(outfitId != (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Name already in use",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return newOutfitName;
        }

        private static DateTime InsertNewDate(int userId)
        {
            Console.Write($"{"Date: ",22}");
            var outfitDate = Console.ReadLine();

            if(outfitDate.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
            }
            if(outfitDate.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Date is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            DateTime parsedDate;
            if(!DateTime.TryParseExact(outfitDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                Console.WriteLine($"\n{"Date is invalid",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }
            if(parsedDate < DateTime.Now)
            {
                Console.WriteLine($"\n{"Date has already passed",32}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return parsedDate;
        }
    }
}
