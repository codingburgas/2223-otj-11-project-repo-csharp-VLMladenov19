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
    public class OutfitsListMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============  Outfits List  ============");
            Console.WriteLine();

            PrintOutfitList(userId);

            Console.WriteLine($"\n{"Press [A] key to Create new Outfit",37}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'A')
                AddOutfitMenu.Print(userId);
            else
                MainMenu.Print();
        }

        private static void PrintOutfitList(int userId)
        {
            var outfits = OutfitService.GetOutfitsByUserId(userId);

            foreach (var outfit in outfits)
            {
                var date = (outfit.Date).ToString("dd.MM.yyyy");
                Console.WriteLine($"{outfit.Name,18} : {date}");
            }
        }
    }
}
