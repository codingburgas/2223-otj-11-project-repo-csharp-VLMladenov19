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

            Console.WriteLine($"\n{"Press [P] key to See Clothes of Outfit",38}");
            Console.WriteLine($"{"Press [A] key to Create new Outfit",37}");
            Console.WriteLine($"{"Press [E] key to Edit an Outfit",36}");
            Console.WriteLine($"{"Press [D] key to Delete an Outfit",37}");
            Console.WriteLine($"{"Press [C] key to Add Clothes",35}");
            Console.WriteLine($"{"Press [R] key to Remove Clothes",36}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);

            switch(input)
            {
                case 'P': PrintClothesByOutfitMenu.Print(userId); break;
                case 'A': AddOutfitMenu.Print(userId); break;
                case 'E': EditOutfitMenu.Print(userId); break;
                case 'D': RemoveOutfitMenu.Print(userId); break;
                case 'C': AddClothesToOutfitMenu.Print(userId); break;
                case 'R': RemoveClothesFromOutfitMenu.Print(userId); break;
                default: MainMenu.Print(); break;
            }
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
