﻿using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.dal.Models;
using wm.util;

namespace wm.console
{
    internal class PrintClothesByOutfitMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============     Outfit     ============");
            Console.WriteLine($"{"Type [B] to go back", 30}\n");

            int userId = UserLog.LoggedUser.Id;

            string outfitName = InsertOutfitName(userId);
            Outfit outfit = OutfitService.GetOutfit(outfitName, userId);

            Console.WriteLine($"{(outfit.Date).ToString("dd.MM.yyyy"), 26}");
            PrintClothes(outfitName, userId);

            Console.WriteLine($"\n{"Press [P] key to See Clothes of other Outfit", 44}");
            Console.WriteLine($"{"or any other key to go back", 34}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey(true).KeyChar);
            switch(input)
            {
                case 'P': Print(); break;
                default: OutfitsListMenu.Print(); break;
            }
        }

        private static string InsertOutfitName(int userId)
        {
            Console.Write($"{"Outfit: ", 23}");
            var outfitName = Console.ReadLine();

            if(outfitName.ToUpper() == "B")
            {
                OutfitsListMenu.Print();
            }
            if(outfitName.IsNullOrEmpty())
            {
                Console.WriteLine($"\n{"Name is required", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            if(outfitId == (int)ErrorCodes.InvalidObject)
            {
                Console.WriteLine($"\n{"Outfit not found", 28}");
                Console.WriteLine($"\n========================================");
                Console.ReadKey(true);
                Print();
            }

            return outfitName;
        }

        private static void PrintClothes(string outfitName, int userId)
        {
            int outfitId = OutfitService.GetOutfitId(outfitName, userId);
            var outfitBridgeList = OutfitBridgeService.GetOutfitClothes(outfitId);

            var clothesList = ClotheService.GetClothesByUserId(userId);
            var typesList = TypeService.GetAll();
            var colorBridgeList = ColorBridgeService.GetAll();
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
                if(outfitBridgeList.Any(c => c.ClotheId == i.Id))
                {
                    if(dic.ContainsKey($"{i.Name} {i.Type}"))
                    {
                        dic[$"{i.Name} {i.Type}"].Add(i.Color);
                    }
                    else
                    {
                        dic[$"{i.Name} {i.Type}"] = new List<string> { i.Color };
                    }
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

            foreach(var i in clothesTypes)
            {
                if(outfitBridgeList.Any(c => c.ClotheId == i.Id))
                {
                    if(dic.ContainsKey($"{i.Name} {i.Type}"))
                    {
                        dic[$"{i.Name} {i.Type}"].Add(String.Empty);
                    }
                    else
                    {
                        dic[$"{i.Name} {i.Type}"] = new List<string> { String.Empty };
                    }
                }
            }

            foreach(var item in dic)
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
