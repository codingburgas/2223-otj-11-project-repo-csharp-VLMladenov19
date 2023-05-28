using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.util;

namespace wm.console
{
    internal class EditClotheMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============  Edit Clothe ============");
            Console.WriteLine($"{"Type [B] to go back", 30}\n");

            int userId = UserLog.LoggedUser.Id;

            string oldClotheName = InsertOldName(userId);
            string newClotheName = InsertNewName(userId);
            int clotheTypeId = InsertNewType(userId);

            ClotheService.EditClothe(oldClotheName, newClotheName, clotheTypeId, userId);

            Console.WriteLine($"\n{"Clothe Eddited", 28}");
            Console.WriteLine($"\n{"Press [E] key to Edit another Clothes", 38}");
            Console.WriteLine($"{"or any other key to go back", 34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey(true).KeyChar);
            switch(input)
            {
                case 'E': EditClotheMenu.Print(); break;
                default: ClothesListMenu.Print(); break;
            }
        }

        private static string InsertOldName(int userId)
        {
            Console.Write($"{"Old Name: ", 24}");
            var oldClotheName = Console.ReadLine();

            if(oldClotheName.ToUpper() == "B")
            {
                ClothesListMenu.Print();
            }
            if(oldClotheName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int clotheId = ClotheService.GetClotheId(oldClotheName, userId);
            if(clotheId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Clothe not found", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return oldClotheName;
        }

        private static string InsertNewName(int userId)
        {
            Console.Write($"{"New Name: ", 24}");
            var newClotheName = Console.ReadLine();

            if(newClotheName.ToUpper() == "B")
            {
                ClothesListMenu.Print();
            }
            if(newClotheName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int clotheId = ClotheService.GetClotheId(newClotheName, userId);
            if(clotheId != (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Name already in use", 30}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return newClotheName;
        }

        private static int InsertNewType(int userId)
        {
            Console.Write($"{"Type: ", 22}");
            string? clotheTypeName = Console.ReadLine();

            if(clotheTypeName.ToUpper() == "B")
            {
                MainMenu.Print();
            }

            if(clotheTypeName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Type is required", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int clotheTypeId = TypeService.GetTypeId(clotheTypeName);
            if(clotheTypeId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Type does not exist", 29}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return clotheTypeId;
        }
    }
}
