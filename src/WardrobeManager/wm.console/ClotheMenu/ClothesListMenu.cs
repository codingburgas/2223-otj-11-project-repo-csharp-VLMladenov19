using Microsoft.EntityFrameworkCore.Infrastructure;
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
    public class ClothesListMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============  Clothes List  ============");
            Console.WriteLine();

            int userId = UserLog.LoggedUser.Id;

            PrintClothesList(userId);

            Console.WriteLine($"\n{"Press [A] key to Add new Clothes",36}");
            Console.WriteLine($"{"Press [C] key to Add Colors",34}");
            Console.WriteLine($"{"Press [D] key to Remove Clothe",36}");
            Console.WriteLine($"{"Press [E] key to Edit Clothe",35}");
            Console.WriteLine($"{"Press [R] key to Remove Colors from a Clothe",43}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            switch (input)
            {
                case 'A': AddClotheMenu.Print(); break;
                case 'C': AddColorMenu.Print(); break;
                case 'D': RemoveClotheMenu.Print(); break;
                case 'E': EditClotheMenu.Print(); ; break;
                case 'R': RemoveColorMenu.Print(); break;
                default: MainMenu.Print(); break;
            }
        }

        private static void PrintClothesList(int userId)
        {
            Dictionary<string, List<string>> clothes = GetFullClothes(userId);

            foreach (var item in clothes)
            {
                var valueList = item.Value
                    .Where(c => !c.IsNullOrEmpty());
                var joinedColors = String.Join(", ", valueList);
                var colorTypes = item.Key.Split(" ");

                Console.Write($"{colorTypes[0], 10} : {colorTypes[1]} : {joinedColors}");
                Console.WriteLine();
            }
        }

        private static Dictionary<string, List<string>> GetFullClothes(int userId)
        {
            List<Clothe> clothesList = ClotheService.GetClothesByUserId(userId);
            List<dal.Models.Type> typesList = TypeService.GetAll();
            List<ClothesColor> colorBridgeList = ColorBridgeService.GetAll();
            List<Color> colorsList = ColorService.GetAll();

            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            // Create a list with every clothing that has at least 1 color
            var clothesTypesColors = clothesList
                .Join(
                    typesList,
                    c => c.TypeId,
                    t => t.Id,
                    (c, t) => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = t.Name
                    })
                .Join(
                    colorBridgeList,
                    c => c.Id,
                    cc => cc.ClotheId,
                    (c, cc) => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = c.Type,
                        ColorId = cc.ColorId
                    })
                .Join(
                    colorsList,
                    c => c.ColorId,
                    co => co.Id,
                    (c, co) => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = c.Type,
                        Color = co.Name
                    })
                .ToList();

            foreach (var i in clothesTypesColors)
            {
                if (dic.ContainsKey($"{i.Name} {i.Type}"))
                {
                    dic[$"{i.Name} {i.Type}"].Add(i.Color);
                }
                else
                {
                    dic[$"{i.Name} {i.Type}"] = new List<string> { i.Color };
                }
            }

            // Create a list with every clothing
            var clothesTypes = clothesList
                .Join(
                    typesList,
                    c => c.TypeId,
                    t => t.Id,
                    (c, t) => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = t.Name
                    })
                .ToList();

            foreach (var i in clothesTypes)
            {
                if (dic.ContainsKey($"{i.Name} {i.Type}"))
                {
                    dic[$"{i.Name} {i.Type}"].Add(String.Empty);
                }
                else
                {
                    dic[$"{i.Name} {i.Type}"] = new List<string> { String.Empty };
                }
            }

            return dic;
        }
    }
}
