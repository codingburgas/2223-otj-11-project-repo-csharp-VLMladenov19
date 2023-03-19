using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;

namespace wm.console
{
    public class ClothesListMenu
    {
        public static void Print(int id)
        {
            Console.Clear();
            Console.WriteLine("============  Clothes List  ============");
            Console.WriteLine();

            PrintClothesListByUserId(id);

            Console.WriteLine($"\n{"Press a key to go to Main Menu",35}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey();
            MainMenu.Print();
        }

        private static void PrintClothesListByUserId(int userId)
        {
            var clothes = ClotheService.GetClothesByUserId(userId);

            foreach(var item in clothes)
            {
                Console.WriteLine($"{item.Name, 28}");
            }
        }
    }
}
