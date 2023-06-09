using System.Text.RegularExpressions;

namespace WordsGame
{
    internal class Controls
    {
        internal static void Options()
        {
            Console.Clear();

            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            string instruction = "Доступные команды во время игры.\n"
            + "!quit для завершения игры,\n"
            + "!print для вывода всех слов,\n"
            + "!score для вывода счёта.\n"
            + "...жми что либо для начала игры...";

            Console.WriteLine(instruction);
            Console.ForegroundColor = color;
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

        internal static void ChoicePlayers(int players)
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
                        Console.WriteLine("Ошибка в вводе слова, повторите ввод");
                    }
                }
            }
            Words.word = Words.CheckWords(Words.words_arr, Words.word, Words.chr);
        }
        internal static void GameControls(string text)
        {
            var color = Console.ForegroundColor;

            switch (text)
            {
                case ("!quit"):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Игра окончена...\n жми что-то");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case ("!print"):
                    Console.ForegroundColor = ConsoleColor.Green;
                    var arr = Words.words_arr;
                    Words.PrintArr(arr);
                    Console.ForegroundColor = color;
                    break;
                case ("!score"):
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Words.Score(Words.words_arr, Player.players);
                    Console.ForegroundColor = color;
                    break;
            }
        }
    }
}