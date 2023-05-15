using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.util;

namespace wm.console
{
    public class AddClotheMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============  Add Clothe  ============");
            Console.WriteLine($"{"Type [B] to go back",30}\n");

            int userId = UserLog.LoggedUser.Id;

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
                case 'A': AddClotheMenu.Print(); break;
                default: ClothesListMenu.Print(); break;
            }
        }

        private static string InsertClotheName(int userId)
        {
            Console.Write($"{"Name: ",22}");
            var name = Console.ReadLine();

            if (name.ToUpper() == "B")
            {
                ClothesListMenu.Print();
            }
            if (name.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required",28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print();
            }

            int clotheId = ClotheService.GetClotheId(name, userId);
            if (clotheId != (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Name already in use",30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print();
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
                Print();
            }

            int typeId = TypeService.GetTypeId(typeName);
            if (typeId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Type does not exist",29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey();
                Print();
            }

            return typeId;
        }
    }
}
