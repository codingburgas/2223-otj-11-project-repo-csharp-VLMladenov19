using System;
using wm.bll;

namespace wm.console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Username = Console.ReadLine();
            string Password = Console.ReadLine();
            string FName = Console.ReadLine();
            string LName = Console.ReadLine();
            int Phone = int.Parse(Console.ReadLine());
            string Email = Console.ReadLine();

            Register.CheckUser(Username, Password, FName, LName, Phone, Email);
        }
    }
}