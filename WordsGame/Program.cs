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
            }
        }
    }
}