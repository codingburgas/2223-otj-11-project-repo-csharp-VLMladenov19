using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;

namespace wm.console.ClotheMenu
{
    public class AddClothingMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============  Add Clothing  ============");
            Console.WriteLine($"{"Type [B] to go back to Main Menu",36}\n");

            string name = InsertName(userId);
            string type = InsertType(userId);
            var typeId = TypeService.GetTypeIdByTypeName(type);

            if(typeId == -1)
            {
                Console.WriteLine($"\n{"Type does not exist",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            ClotheService.AddClothing(name, userId, typeId);

            Console.WriteLine($"\n{"Clothing Added",27}");
            Console.WriteLine($"\n{"Press [A] key to Add new Clothes",36}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'A')
                AddClothingMenu.Print(userId);
            else
                ClothesListMenu.Print(userId);
        }

        private static string InsertName(int userId)
        {
            Console.Write($"{"Name: ",22}");
            var name = Console.ReadLine();

            if (name.ToUpper() == "B")
            {
                MainMenu.Print();
            }
            if (name.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }
            if (ClotheService.GetClothingId(name, userId) != -2)
            {
                Console.WriteLine($"\n{"Name already in use",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return name;
        }

        private static string InsertType(int userId)
        {
            Console.Write($"{"Type: ",22}");
            var type = Console.ReadLine();

            if (type.ToUpper() == "B")
            {
                MainMenu.Print();
            }

            if (type.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Type is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            return type;
        }
    }
}
