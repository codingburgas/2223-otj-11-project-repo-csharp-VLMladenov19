using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.dal.Models;

namespace wm.console.ClotheMenu
{
    public class ClothesListMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============  Clothes List  ============");
            Console.WriteLine();

            PrintClothesListByUserId(userId);

            Console.WriteLine($"{"Press [A] key to Add new Clothes",36}");
            Console.WriteLine($"{"Press [C] key to Add Colors",34}");
            Console.WriteLine($"{"Press [D] key to Remove Clothing",36}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'A')
                AddClothingMenu.Print(userId);
            else if (input == 'C')
                AddColorMenu.Print(userId);
            else if (input == 'D')
                RemoveClothingMenu.Print(userId);
            else
                MainMenu.Print();
        }

        private static void PrintClothesListByUserId(int userId)
        {
            var clothes = ClotheService.GetClothesByUserId(userId);
            var types = TypeService.GetAllTypes();

            var joined = clothes
                .Join(
                    types,
                    c => c.TypeId,
                    t => t.Id,
                    (c, t) => new
                    {
                        Name = c.Name,
                        Type = t.Name
                    });

            foreach (var item in joined)
            {
                Console.WriteLine($"{item.Name,18} : {item.Type}");
            }
            Console.WriteLine();
        }
    }
}
