namespace WordGame
{
    internal class Words
    {
        internal static string[,] wordsarr = new string[1, 1];
        internal static char chr = ' ';
        internal static string word = "";
        internal static string[,] CreateWordsArray(string[,] words, int id, string word)
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
            words = tempArr;
            return words;
        }

        internal static string? CheckWords(string[,] words, string word, char gameChar)
        {
            if (word.StartsWith(gameChar))
            {
                for (int i = 0; i < words.GetLength(0); i++)
                {
                    for (int j = 0; j < words.GetLength(1); j++)
                    {
                        if (words[i, j] == word)
                        {
                            Console.WriteLine($"Игрок №{i + 1} уже называл слово {word}!");
                            return null;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Слово должно начинаться с \'{gameChar}\' ");
                return null;
            }
            return word;
        }

        internal static void Score(string[,] words, int players)
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
                    Console.Write($"У игрока №{i + 1} - {tempScore[i, j]} слов.\n");
                }
            }
        }

        internal static void PrintArr(string[,] words)
        {
            for (int i = 0; i < words.GetLength(0); i++)
            {
                System.Console.WriteLine($"Слова игрока №{i + 1}:");
                for (int j = 0; j < words.GetLength(1); j++)
                {
                    if (words[i, j] != null)
                    {
                        System.Console.Write($"{words[i, j]} ");
                    }
                }
                System.Console.WriteLine();
            }
        }
    }
}