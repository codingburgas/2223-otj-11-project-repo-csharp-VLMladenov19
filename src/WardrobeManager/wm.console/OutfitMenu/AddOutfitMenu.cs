using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class AddOutfitMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============   Add Outfit   ============");
            Console.WriteLine($"{"Type [B] to go back", 30}\n");

            int userId = UserLog.LoggedUser.Id;

            string outfitName = InsertOutfitName(userId);

            Console.WriteLine($"\n{"Date syntax: DD.MM.YYYY", 32}");
            var outfitDate = InsertOutfitDate(userId);

            OutfitService.AddOutfit(outfitName, outfitDate, userId);

            Console.WriteLine($"\n{"Outfit Added", 26}");
            Console.WriteLine($"\n{"Press [A] key to Add new Outfits", 36}");
            Console.WriteLine($"{"or any other key to go back", 34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey(true).KeyChar);
            switch(input)
            {
                case 'A': AddOutfitMenu.Print(); break;
                default: OutfitsListMenu.Print(); break;
            }
        }

        private static string InsertOutfitName(int userId)
        {
            Console.Write($"{"Name: ", 22}");
            var outfitName = Console.ReadLine();

            if(outfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
            }
            if(outfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            if(outfitId != (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Name already in use", 30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return outfitName;
        }

        private static DateTime InsertOutfitDate(int userId)
        {
            Console.Write($"{"Date: ", 22}");
            var outfitDate = Console.ReadLine();

            if(outfitDate.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
            }
            if(outfitDate.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Date is required", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            DateTime parsedDate;
            if(!DateTime.TryParseExact(outfitDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                Console.WriteLine($"\n{"Date is invalid", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }
            if(parsedDate < DateTime.Now)
            {
                Console.WriteLine($"\n{"Date has already passed", 32}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return parsedDate;
        }
    }
}
