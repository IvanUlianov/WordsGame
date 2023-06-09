using System.Text.RegularExpressions;

namespace WordsGame
{
    internal class Player
    {
        internal static int id;
        internal static int players;

        internal static void SetPlayers()
        {
            while (true)
            {
                Console.Write("������� ���������� �������: ");
                string? InputPlayers = Console.ReadLine();

                if (InputPlayers != "" && InputPlayers != null)
                {
                    if (Regex.IsMatch(InputPlayers, @"^[!]")) Controls.GameControls(InputPlayers);

                    bool success = int.TryParse(InputPlayers, out int tempPlayers);
                    if (success && tempPlayers > 0)
                    {
                        players = tempPlayers;
                        Console.WriteLine($"������ {players} �������");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{InputPlayers} - �� �����");
                    }
                }
            }
        }
    }
}