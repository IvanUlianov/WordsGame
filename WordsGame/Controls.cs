using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace WordGame
{
    internal class Controls
    {
        internal static void Menu(ref int players, ref char gameChar)
        {
            Console.Clear();

            string instruction = "Привет это игра в слова\n"
            + "набери !quit для завершения игры, !print для вывода всех слов\n"
            + "...жми что либо для начала игры...";

            Console.WriteLine(instruction);
            Console.ReadKey();

            while (true)
            {
                Console.Write("Введите количество игроков: ");
                string? InputPlayers = Console.ReadLine();

                if (InputPlayers != "" && InputPlayers != null)
                {
                    if (Regex.IsMatch(InputPlayers, @"^[!]")) GameControls(InputPlayers);

                    bool success = int.TryParse(InputPlayers, out int tempPlayers);
                    if (success && tempPlayers > 0)
                    {
                        players = tempPlayers;
                        Console.WriteLine($"Играет {players} игроков");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{InputPlayers} - не число");
                    }
                }
            }

            while (true)
            {
                Console.Write("Введите букву с короторой сегодня играем: ");
                string? InputGameChar = Console.ReadLine();

                if (InputGameChar != null && InputGameChar != "")
                {
                    InputGameChar = InputGameChar.ToLower().Trim();

                    if (Regex.IsMatch(InputGameChar, @"^[!]")) GameControls(InputGameChar);

                    if (Regex.IsMatch(InputGameChar, @"^[a-zа-я]"))
                    {
                        gameChar = InputGameChar[0];
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{InputGameChar} - это не буква");
                    }
                }
            }

        }

        internal static void ConsoleInput(ref int id, ref string word, char gameChar, int players)
        {
            while (true)
            {
                Console.Write("Введите номер игрока: ");
                string? InputId = Console.ReadLine();

                if (InputId != null && InputId != "")
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
                            id = tempId - 1;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Введите число от 1 до {players}");
                    }
                }
            }

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
                        word = tempWord;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка в вводе слова, повторите ввод");
                    }
                }
            }
        }
        private static void GameControls(string text)
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