using System;
using wm.bll;

namespace wm.console
{
    internal class Start
    {
        static void Main(string[] args)
        {
            string Username = Console.ReadLine();
            string Password = Console.ReadLine();
            //string FName = Console.ReadLine();
            //string LName = Console.ReadLine();
            //int Phone = int.Parse(Console.ReadLine());
            //string Email = Console.ReadLine();

            //UserService.RegisterUser(Username, Password, FName, LName, Phone, Email);

            //string change = Console.ReadLine();
            //UserService.UpdateUser(change, "vase", "change", "change", "change", 2, "change");

            //string delete = Console.ReadLine();
            //UserService.DeleteUser(UserService.GetUserIdByUsername(delete));

            Console.WriteLine(UserService.VerifyUser(Username, Password) ? "exists" : "doesn't exist");
        }
    }
}