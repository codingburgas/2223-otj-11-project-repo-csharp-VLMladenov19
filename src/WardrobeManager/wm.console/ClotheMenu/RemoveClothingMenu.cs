using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;

namespace wm.console.ClotheMenu
{
    public class RemoveClothingMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============ Remove Cloting ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            if (ClotheService.GetClothesByUserId(userId).IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"User has no clothes",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                ClothesListMenu.Print(userId);
            }

            string name = InsertName(userId);

            int clothingId = ClotheService.GetClothingId(name, userId);
            if (clothingId == -1)
            {
                Console.WriteLine($"\n{"Name is wrong or clothe does not exist",39}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            ClotheService.RemoveClothing(clothingId);

            Console.WriteLine($"\n{"Clothing Removed",28}");
            Console.WriteLine($"{"Press a key to back to Clothes List",38}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey();
            ClothesListMenu.Print(userId);
        }

        private static string InsertName(int userId)
        {
            Console.Write($"{"Name: ",22}");
            var name = Console.ReadLine();

            if (name.ToUpper() == "B")
            {
                ClothesListMenu.Print(userId);
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
