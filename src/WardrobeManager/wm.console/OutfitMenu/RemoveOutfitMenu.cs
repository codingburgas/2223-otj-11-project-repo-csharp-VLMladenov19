using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class RemoveOutfitMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============ Remove Outfit  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            int userId = UserLog.LoggedUser.Id;

            if(OutfitService.GetOutfitsByUserId(userId).IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"User has no outfits",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                OutfitsListMenu.Print();
            }

            string outfitName = InsertName(userId);

            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            OutfitService.RemoveOutfit(outfitId);

            Console.WriteLine($"\n{"Outfit Removed",27}");
            Console.WriteLine($"{"Press a key to back to Outfits List",38}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey(true);
            OutfitsListMenu.Print();
        }

        private static string InsertName(int userId)
        {
            Console.Write($"{"Name: ",22}");
            var outfitName = Console.ReadLine();

            if(outfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
            }
            if(outfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            if(outfitId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Name is wrong or outfit does not exist",39}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return outfitName;
        }
    }
}
