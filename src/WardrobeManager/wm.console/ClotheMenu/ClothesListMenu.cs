﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using wm.bll;
using wm.dal.Models;
using wm.util;

namespace wm.console
{
    internal class ClothesListMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("============  Clothes List  ============");
            Console.WriteLine();

            int userId = UserLog.LoggedUser.Id;

            PrintUsersClothes(userId);

            Console.WriteLine($"\n{"Press [A] key to Add new Clothes", 36}");
            Console.WriteLine($"{"Press [R] key to Remove Clothe", 36}");
            Console.WriteLine($"{"Press [E] key to Edit Clothe", 35} \n");
            Console.WriteLine($"{"Press [C] key to Add Colors", 34}");
            Console.WriteLine($"{"Press [D] key to Remove Colors from a Clothe", 43}\n");
            Console.WriteLine($"{"Press any other key to go back", 36}");
            Console.WriteLine($"\n========================================");

            var input = Char.ToUpper(Console.ReadKey(true).KeyChar);
            switch (input)
            {
                case 'A': AddClotheMenu.Print(); break;
                case 'R': RemoveClotheMenu.Print(); break;
                case 'E': EditClotheMenu.Print(); ; break;
                case 'C': AddColorMenu.Print(); break;
                case 'D': RemoveColorMenu.Print(); break;
                default: MainMenu.Print(); break;
            }
        }

        // Prints all clothes of an user
        private static void PrintUsersClothes(int userId)
        {
            Dictionary<string, List<string>> clothes = GetFullClothes(userId);

            foreach (var item in clothes)
            {
                var valueList = item.Value
                    .Where(c => !c.IsNullOrEmpty());
                var joinedColors = String.Join(", ", valueList);
                var colorTypes = item.Key.Split(" ");

                Console.Write($"{colorTypes[0],10} : {colorTypes[1]} : {joinedColors}");
                Console.WriteLine();
            }
        }

        // Create a dictionary with all clothes of an user, with their types and colors
        private static Dictionary<string, List<string>> GetFullClothes(int userId)
        {
            List<Clothe> clothesList = ClotheService.GetClothesByUserId(userId);
            List<dal.Models.Type> typesList = TypeService.GetAll();
            List<ClotheColor> colorBridgeList = ColorBridgeService.GetAll();
            List<Color> colorsList = ColorService.GetAll();

            Dictionary<string, List<string>> usersClothes = new Dictionary<string, List<string>>();

            // Create a list with every clothing that has at least oneolor
            var coloredClothes = clothesList
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

            // Add all clothes with at least one color to dictionary
            foreach(var i in coloredClothes)
            {
                if(usersClothes.ContainsKey($"{i.Name} {i.Type}"))
                {
                    usersClothes[$"{i.Name} {i.Type}"].Add(i.Color);
                }
                else
                {
                    usersClothes[$"{i.Name} {i.Type}"] = new List<string> { i.Color };
                }
            }

            // Create a list with every clothing
            var noColorsClothes = clothesList
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

            // Add all clothes that don't have colors to dictionary
            foreach(var i in noColorsClothes)
            {
                if(usersClothes.ContainsKey($"{i.Name} {i.Type}"))
                {
                    usersClothes[$"{i.Name} {i.Type}"].Add(String.Empty);
                }
                else
                {
                    usersClothes[$"{i.Name} {i.Type}"] = new List<string> { String.Empty };
                }
            }

            return usersClothes;
        }
    }
}
