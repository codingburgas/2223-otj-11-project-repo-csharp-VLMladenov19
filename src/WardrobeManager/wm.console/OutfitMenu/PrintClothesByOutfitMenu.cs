using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.bll;
using wm.dal.Repositories;

namespace wm.console.OutfitMenu
{
    public class PrintClothesByOutfitMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============     Outfit     ============");
            Console.WriteLine();

            string outfitName = InsertOutfitName(userId);
            PrintClothes(outfitName, userId);

            Console.WriteLine($"\n{"Press [P] key to See Clothes of Outfit",38}");
            Console.WriteLine($"{"or any other key to go back",34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey().KeyChar);
            if (input == 'P')
                PrintClothesByOutfitMenu.Print(userId);
            else
                OutfitsListMenu.Print(userId);
        }

        private static string InsertOutfitName(int userId)
        {
            Console.Write($"{"Outfit: ",23}");
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

        private static void PrintClothes(string outfitName, int userId)
        {
            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            var outfitBridgeList = OutfitBridgeRepository.GetAllByOutfitId(outfitId);

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

            clothesTypesColors.Where(c => outfitBridgeList.Any(o => c.Id == o.ClotheId));

            var dic = new Dictionary<string, List<string>>();

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

            clothesTypes.Where(c => outfitBridgeList.Any(o => c.Id == o.ClotheId));

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

                Console.Write($"{colorTypes[0],10} : {colorTypes[1]} : {joinedColors}");
                Console.WriteLine();
            }
        }
    }
}
