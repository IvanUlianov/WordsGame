namespace WordsGame
{   
    class Program
    {
        public static void Main()
        {
            Console.Title = "Игра в слова";
			Console.CursorVisible = false;

			Menu.RunMenu();
            while (true)
            {
				Menu.Choice(Menu.index);
            }
        }
    }
}
