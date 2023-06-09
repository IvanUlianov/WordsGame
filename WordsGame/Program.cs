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

			//Controls.Menu();

			//while (true)
			//{
			//	Controls.ChoicePlayers(Player.players);
			//	Controls.WordInput(Words.chr);

			//	Words.CreateWordsArray(Words.words_arr, Player.id, Words.word);
			//}
		}
	}
}