using System.Text.RegularExpressions;
namespace WordsGame
{
	internal class Words
	{
		internal static string[,] words_arr;
		internal static char chr = ' ';
		internal static string? word = "";

		private static void SetWords()
		{
			words_arr = new string[Player.players, 1];
		}
		internal static void SetChar()
		{
			while (true)
			{
				Console.Write("������� ����� � �������, �������, ������: ");
				string? InputGameChar = Console.ReadLine();

				if (!string.IsNullOrEmpty(InputGameChar))
				{
					InputGameChar = InputGameChar.ToLower().Trim();

					if (Regex.IsMatch(InputGameChar, @"^[!]")) Controls.GameControls(InputGameChar);

					if (Regex.IsMatch(InputGameChar, @"^[a-z�-�]"))
					{
						chr = InputGameChar[0];
						break;
					}
					else
					{
						Console.WriteLine($"{InputGameChar} - ��� �� �����");
					}
				}
			}
		}
		internal static string? CheckWords(string[,] words, string word, char gameChar)
		{
			if (words == null)
			{
				SetWords();
			}
			else if (word.StartsWith(gameChar))
			{
				for (int i = 0; i < words.GetLength(0); i++)
				{
					for (int j = 0; j < words.GetLength(1); j++)
					{
						if (words[i, j] == word)
						{
							Console.WriteLine($"����� �{i + 1} ��� ������� ����� {word}!");
							word = null;
							return word;
						}
					}
				}
			}
			else
			{
				Console.WriteLine($"����� ������ ���������� � \'{gameChar}\' ");
				word = null;
				return word;
			}
			return word;
		}
		internal static void CreateWordsArray(string[,] words, int id, string word)
		{
			if (words == null)
			{
				SetWords();
			}
			else if (!string.IsNullOrEmpty(word))
			{
				string[,] tempArr = new string[words.GetLength(0), words.GetLength(1) + 1];
				for (int i = 0; i < words.GetLength(0); i++)
				{
					for (int j = 0; j < words.GetLength(1); j++)
					{
						tempArr[i, j] = words[i, j];
					}
				}
				tempArr[id, words.GetLength(1) - 1] = word;
				words_arr = tempArr;
			}
		}

		internal static void Score(string[,] words, int players)
		{
			if (words != null)
			{
				int[,] tempScore = new int[players, 1];
				int count = 0;

				for (int i = 0; i < words.GetLength(0); i++)
				{
					for (int j = 0; j < words.GetLength(1); j++)
					{
						if (words[i, j] != null)
						{
							count++;
							tempScore[i, 0] = count;
						}
					}
					count = 0;
				}

				for (int i = 0; i < tempScore.GetLength(0); i++)
				{
					for (int j = 0; j < tempScore.GetLength(1); j++)
					{
						Console.Write($"� ������ �{i + 1} - {tempScore[i, j]} ����.\n");
					}
				}
			}
			else Console.WriteLine("��� �������");
		}

		internal static void PrintArr(string[,] words)
		{
			if (words != null)
			{
				for (int i = 0; i < words.GetLength(0); i++)
				{
					Console.WriteLine($"����� ������ �{i + 1}:");
					for (int j = 0; j < words.GetLength(1); j++)
					{
						if (words[i, j] != null)
						{
							Console.Write($"{words[i, j]} ");
						}
					}
					Console.WriteLine();
				}
			}
		}
	}
}