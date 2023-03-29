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
    public class EditOutfitMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============   Edit Outfit  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            string oldName = InsertOldName(userId);
            string newName = InsertNewName(userId);

            Console.WriteLine($"\n{"Date syntax: DD.MM.YYYY",32}");
            DateTime date = InsertDate(userId);

            OutfitService.EditOutfit(oldName, newName, date, userId);

            Console.WriteLine($"\n{"Outfit Eddited",27}");
            Console.WriteLine($"\n{"Press [E] key to Edit another Outfit",38}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'E')
                EditOutfitMenu.Print(userId);
            else
                OutfitsListMenu.Print(userId);
        }

        private static string InsertOldName(int userId)
        {
            Console.Write($"{"Old Name: ",24}");
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
            if (OutfitService.GetOutfitId(name, userId) == -1)
            {
                Console.WriteLine($"\n{"Outfit not found",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return name;
        }

        private static string InsertNewName(int userId)
        {
            Console.Write($"{"New Name: ",24}");
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
            if (OutfitService.GetOutfitId(name, userId) != -1)
            {
                Console.WriteLine($"\n{"Name already in use",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return name;
        }

        private static DateTime InsertDate(int userId)
        {
            Console.Write($"{"Date: ",22}");
            var date = Console.ReadLine();

            if (date.ToUpper() == "B")
            {
                OutfitsListMenu.Print(userId);
            }
            if (date.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Date is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            DateTime parsedDate = DateTime.Parse(date);
            if (parsedDate <= DateTime.Now)
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
