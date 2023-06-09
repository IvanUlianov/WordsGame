namespace WordsGame
{
	internal class Menu
	{
		private static readonly string[] main_menu = { "Start", "Commands", "Exit" };
		internal static int index = 0;

		internal static int RunMenu()
		{
			ConsoleKey key;

			do
			{
				Console.Clear();
				Main_Menu(main_menu, index);
				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				key = keyInfo.Key;

				if (key == ConsoleKey.UpArrow)
				{
					index--;
					if (index < 0) index = main_menu.Length - 1;
				}
				else if (key == ConsoleKey.DownArrow)
				{
					index++;
					if (index > main_menu.Length - 1) index = 0;
				}
			}
			while (key != ConsoleKey.Enter);

			return index;
		}
		private static void Main_Menu(string[] main_menu, int index)
		{
			int width = Console.WindowWidth;
			int height = Console.WindowHeight;
			int length = main_menu.Length;

			for (int i = 0; i < length; i++)
			{
				if (i == index)
				{
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
				}
				Console.SetCursorPosition(width/2 - 5, (height - length) / 2 + i);
				Console.WriteLine($"\t{main_menu[i]}\t");
			}
			Console.ResetColor();
		}

		internal static void Choice(int index)
		{
			switch (index)
			{
				case 0:
					StartGame();
					break;
				case 1:
					Commands();
					break;
				case 2:
					ExitGame();
					break;
			}
		}

		protected


		private static void ExitGame()
		{
			Environment.Exit(0);
		}

		private static void Commands()
		{
			Controls.Options();
			RunMenu();
		}

		private static void StartGame()
		{
			Console.Clear();

			Player.SetPlayers();
			Words.SetChar();

			while (true)
			{
				Controls.ChoicePlayers(Player.players);
				Controls.WordInput(Words.chr);

				Words.CreateWordsArray(Words.words_arr, Player.id, Words.word);
			}
		}
	}
}
