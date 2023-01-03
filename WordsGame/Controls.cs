using System.Runtime.CompilerServices;
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
            string instruction = "Привет это игра в слова\n"
            + "набери !quit для завершения игры, !print для вывода всех слов\n"
            + "...жми что либо для начала игры...";

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
                Console.Write("Введите номер игрока: ");
                string? InputId = Console.ReadLine();

                if (!string.IsNullOrEmpty(InputId))
                {
                    if (Regex.IsMatch(InputId, @"^[!]")) GameControls(InputId);

                    bool success = int.TryParse(InputId, out int tempId);
                    if (success)
                    {
                        if (tempId < 1 || tempId > players)
                        {
                            Console.WriteLine($"Введите число от 1 до {players}");
                        }
                        else
                        {
                            Player.id = tempId - 1;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Введите число от 1 до {players}");
                    }
                }
            }
        }
        internal static void WordInput(char gameChar)
        {
            while (true)
            {
                Console.Write($"Введите слово на букву {gameChar}: ");
                string? tempWord = Console.ReadLine();

                if (tempWord != null && tempWord != "")
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
                        Console.WriteLine("Ошибка в вводе слова, повторите ввод");
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
                    Console.WriteLine("Игра законченна...\n жми что-то");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case ("!print"):
                    Console.ForegroundColor = ConsoleColor.Green;
                    var arr = Words.wordsarr;
                    Words.PrintArr(arr);
                    Console.ForegroundColor = color;
                    break;
            }
        }
    }
}