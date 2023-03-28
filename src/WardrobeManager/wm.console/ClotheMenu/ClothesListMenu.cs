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

            PrintClothesList(userId);

            Console.WriteLine($"\n{"Press [A] key to Add new Clothes",36}");
            Console.WriteLine($"{"Press [C] key to Add Colors",34}");
            Console.WriteLine($"{"Press [D] key to Remove Clothing",36}");
            Console.WriteLine($"{"Press [E] key to Edit Clothing",35}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'A')
                AddClothingMenu.Print(userId);
            else if (input == 'C')
                AddColorMenu.Print(userId);
            else if (input == 'D')
                RemoveClothingMenu.Print(userId);
            else if (input == 'E')
                EditClothingMenu.Print(userId);
            else
                MainMenu.Print();
        }

        private static void PrintClothesList(int userId)
        {
            var clothesList = ClotheService.GetClothesByUserId(userId);
            var typesList = TypeService.GetAllTypes();
            var colorBridgeList = ColorsBridgeService.GetAll();
            var colorsList = ColorService.GetAll();

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

            var dic = new Dictionary<string, List<string>>();

            foreach(var i in clothesTypesColors)
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
                    });

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

            foreach (var item in dic)
            {
                var valueList = item.Value
                    .Where(c => !c.IsNullOrEmpty());
                var joinedColors = String.Join(", ", valueList);
                var colorTypes = item.Key.Split(" ");

                Console.Write($"{colorTypes[0], 10} : {colorTypes[1]} : {joinedColors}");
                Console.WriteLine();
            }
        }
    }
}
