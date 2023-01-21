using System.Text.RegularExpressions;

namespace WordGame
{
	internal class Controls
	{
		internal static void Menu()
		{
			Console.Clear();

			var color = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;
			string instruction = "������ ��� ���� � �����\n"
			+ "������ !quit ��� ���������� ����, !print ��� ������ ���� ����, !score ��� ������ �����\n"
			+ "...��� ��� ���� ��� ������ ����...";

			Console.WriteLine(instruction);
			Console.ForegroundColor = color;
			Console.ReadKey();

			Player.SetPlayers();
			Words.SetChar();
		}

		internal static void NumOfPlayers(int players)
		{
			while (true)
			{
				Console.Write("������� ����� ������: ");
				string? InputId = Console.ReadLine();

				if (!string.IsNullOrEmpty(InputId))
				{
					if (Regex.IsMatch(InputId, @"^[!]")) GameControls(InputId);

					bool success = int.TryParse(InputId, out int tempId);
					if (success)
					{
						if (tempId < 1 || tempId > players)
						{
							Console.WriteLine($"������� ����� �� 1 �� {players}");
						}
						else
						{
							Player.id = tempId - 1;
							break;
						}
					}
					else
					{
						Console.WriteLine($"������� ����� �� 1 �� {players}");
					}
				}
			}
		}
		internal static void WordInput(char gameChar)
		{
			while (true)
			{
				Console.Write($"������� ����� �� ����� {gameChar}: ");
				string? tempWord = Console.ReadLine();

				if (!string.IsNullOrEmpty(tempWord))
				{
					tempWord = tempWord.Trim().ToLower();

					if (Regex.IsMatch(tempWord, @"^[!]")) GameControls(tempWord);

					if (tempWord != gameChar.ToString() && tempWord != "")
					{
						Words.word = tempWord;
						break;
					}
					else
					{
						Console.WriteLine("������ � ����� �����, ��������� ����");
					}
				}
			}
			Words.word = Words.CheckWords(Words.wordsarr, Words.word, Words.chr);
		}
		internal static void GameControls(string text)
		{
			var color = Console.ForegroundColor;
			switch (text)
			{
				case ("!quit"):
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("���� ����������...\n ��� ���-��");
					Console.ReadKey();
					Environment.Exit(0);
					break;
				case ("!print"):
					Console.ForegroundColor = ConsoleColor.Green;
					var arr = Words.wordsarr;
					Words.PrintArr(arr);
					Console.ForegroundColor = color;
					break;
				case ("!score"):
					Console.ForegroundColor = ConsoleColor.Blue;
					Words.Score(Words.wordsarr, Player.players);
					Console.ForegroundColor = color;
					break;
			}
		}
	}
}