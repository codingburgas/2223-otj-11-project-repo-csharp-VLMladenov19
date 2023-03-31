using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.dal.Models;
using wm.util;

namespace wm.console.ClotheMenu
{
    public class AddClotheMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============  Add Clothe  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            string clotheName = InsertClotheName(userId);
            int typeId = InsertType(userId);

            ClotheService.AddClothe(clotheName, userId, typeId);

            Console.WriteLine($"\n{"Clothe Added",27}");
            Console.WriteLine($"{"Press [A] key to Add new Clothes",36}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            switch(input)
            {
                case 'A': AddClotheMenu.Print(userId); break;
                default: ClothesListMenu.Print(userId); break;
            }
        }

        private static string InsertClotheName(int userId)
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

            int clotheId = ClotheService.GetClotheId(name, userId);
            if (clotheId != (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Name already in use",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return name;
        }

        private static int InsertType(int userId)
        {
            Console.Write($"{"Type: ",22}");
            string? typeName = Console.ReadLine();

            if (typeName.ToUpper() == "B")
            {
                MainMenu.Print();
            }

            if (typeName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Type is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            int typeId = TypeService.GetTypeId(typeName);
            if (typeId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Type does not exist",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return typeId;
        }
    }
}
