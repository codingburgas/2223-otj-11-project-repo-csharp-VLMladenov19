using System;
using wm.bll;

namespace wm.console
{
    internal class Start
    {
        static void Main(string[] args)
        {
            string Username = Console.ReadLine();
            //string Password = Console.ReadLine();
            //string FName = Console.ReadLine();
            //string LName = Console.ReadLine();
            //int Phone = int.Parse(Console.ReadLine());
            //string Email = Console.ReadLine();

            //UserService.CheckUser(Username, Password, FName, LName, Phone, Email);

            UserService.UpdateUser(Username, "vase", "change", "change", "change", 2, "change");

            //UserService.DeleteUser(UserService.GetUserIdByUsername("vase"));
        }
    }
}