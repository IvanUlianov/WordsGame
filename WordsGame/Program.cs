namespace WordGame
{   
    class Program
    {
        public static void Main()
        {
            Console.Title = "Игра в слова";
            
            Controls.Menu();
            while (true)
            {
                Controls.NumOfPlayers(Player.players);
                Controls.WordInput(Words.chr);
                
                Words.CreateWordsArray(Words.wordsarr, Player.id, Words.word);
                Words.Score(Words.wordsarr, Player.players);
            }
        }

        //private static void Game()
        //{
        //    Console.Title = "Игра в слова";
        //    int players = 1;
        //    char gameChar = ' ';

        //    Controls.Menu(ref players, ref gameChar);

        //    string[,] words = new string[players, 1];
        //    int id = 1;
        //    string word = " ";

        //    while (true)
        //    {

        //        Controls.ConsoleInput(ref id, ref word, gameChar, players);

        //        word = Words.CheckWords(words, word, gameChar);
        //        if (word != null && words != null)
        //        {
        //            words = Words.CreateWordsArray(words, id, word);
        //            Words.Score(words, players);
        //            Words.wordsarr = words;
        //        }
        //    }

        //}
    }

}

