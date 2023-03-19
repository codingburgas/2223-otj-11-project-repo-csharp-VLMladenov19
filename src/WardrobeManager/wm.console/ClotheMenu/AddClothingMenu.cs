using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wm.console.ClotheMenu
{
    public class AddClothingMenu
    {
        public static void Print(int userId)
        {
            Console.Clear();
            Console.WriteLine("============  Add Clothing  ============");
            Console.WriteLine();

            // name
            // type
            //(id);

            Console.WriteLine($"\n{"Press a key to back to Clothes List",38}");
            Console.WriteLine($"\n========================================");
            Console.ReadKey();
            ClothesListMenu.Print(userId);
        }
    }
}
