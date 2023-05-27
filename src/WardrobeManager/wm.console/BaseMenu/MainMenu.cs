namespace wm.console
{
    internal class MainMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("[O] Outfits   [C] Clothes   [S] Settings   [E] Exit");
            while(true)
            {
                var input = Char.ToUpper(Console.ReadKey(true).KeyChar);

                switch (input)
                {
                    case 'O': OutfitsListMenu.Print(); break;
                    case 'C': ClothesListMenu.Print(); break;
                    case 'S': SettingsMenu.Print(); break;
                    case 'E': Environment.Exit(0); break;
                    default:
                        break;
                }
            }
        }
    }
}
