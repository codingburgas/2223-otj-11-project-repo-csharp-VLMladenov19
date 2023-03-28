using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;

namespace wm.console.ClotheMenu
{
    public class EditClothingMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============  Edit Clothing ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            string oldName = InsertOldName(userId);
            string newName = InsertNewName(userId);
            string type = InsertType(userId);
            var typeId = TypeService.GetTypeIdByTypeName(type);

            if (typeId == -1)
            {
                Console.WriteLine($"\n{"Type does not exist",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }

            ClotheService.EditClothing(oldName, newName, userId, typeId);

            Console.WriteLine($"\n{"Clothing Eddited",28}");
            Console.WriteLine($"\n{"Press [E] key to Edit another Clothes",38}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'E')
                AddClothingMenu.Print(userId);
            else
                ClothesListMenu.Print(userId);
        }

        private static string InsertOldName(int userId)
        {
            Console.Write($"{"Old Name: ",24}");
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
            if (ClotheService.GetClothingId(name, userId) == -1)
            {
                Console.WriteLine($"\n{"Clothe not found",28}");
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
                ClothesListMenu.Print(userId);
            }
            if (name.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print(userId);
            }
            if (ClotheService.GetClothingId(name, userId) != -1)
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
