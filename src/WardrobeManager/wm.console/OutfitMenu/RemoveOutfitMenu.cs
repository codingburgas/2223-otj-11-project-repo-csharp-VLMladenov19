using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.console.ClotheMenu;

namespace wm.console.OutfitMenu
{
    public class RemoveOutfitMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============ Remove Outfit  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            if (OutfitService.GetOutfitsByUserId(userId).IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"User has no outfits",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                OutfitsListMenu.Print(userId);
            }

            string name = InsertName(userId);

            int outfitId = OutfitService.GetOutfitId(name, userId);
            if (outfitId == -1)
            {
                Console.WriteLine($"\n{"Name is wrong or outfit does not exist",39}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            OutfitService.RemoveOutfit(outfitId);

            Console.WriteLine($"\n{"Outfit Removed",27}");
            Console.WriteLine($"{"Press a key to back to Outfits List",38}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey();
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

            return name;
        }
    }
}
