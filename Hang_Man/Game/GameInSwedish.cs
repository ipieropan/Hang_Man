using System.Text;
using static System.Console;

namespace Hang_Man.Game
{
    public class GameInSwedish
    {
        public static void GameStart()
        {
            Clear();
            Random random = new((int)DateTime.Now.Ticks);
            string wordToGuess = GameInfo.WordsSwedish[random.Next(0, GameInfo.WordsSwedish.Length)];
            string wordToGuessToUpper = wordToGuess.ToUpper();


            StringBuilder displayToPlayer = new(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');

            int lives = 5;
            bool win = false;
            int lettersRevealed = 0;


            while (!win && lives > 0)
            {
                Clear();
                WriteLine($"Ordet har {wordToGuess.Length} bokstäver.");
                WriteLine(displayToPlayer.ToString());

                if (wordToGuess == GameInfo.Words[3] || wordToGuess == GameInfo.Words[3])
                {
                    WriteLine("Det är relaterat till programmering...");
                }
                else if (wordToGuess == GameInfo.Words[1])
                {
                    WriteLine("Det är ett vackert namn...");
                }
                WriteLine($"Försök = {GameInfo.Attempts}" +
                    $"\nLiv = {lives}");
                Write("Gissa en bokstav: ");
                GameInfo.Attempts++;
                string? input = ReadLine().ToUpper();

                // case user enters nothing
                while (input == null)
                {
                    WriteLine("Indata kan inte vara null.");
                    input = ReadLine().ToUpper();
                }

                char guess = input[0]; // takes always the first letter

                // case user tries the same letter more than once
                if (GameInfo.CorrectLetters.Contains(guess))
                {
                    WriteLine($"Du har redan provat '{guess}', och det var korrekt!");
                    continue;
                }
                else if (GameInfo.IncorrectLetters.Contains(guess))
                {
                    WriteLine($"Du har redan provat '{guess}', och det var felaktigt!");
                    continue;
                }

                // contains the guess
                if (wordToGuessToUpper.Contains(guess))
                {
                    GameInfo.CorrectLetters.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessToUpper[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersRevealed++;
                        }
                    }
                    WriteLine(displayToPlayer.ToString());
                    if (lettersRevealed == wordToGuess.Length)
                        win = true;
                }

                // do not contains the guess
                else
                {
                    GameInfo.IncorrectLetters.Add(guess);

                    WriteLine($"Nej, det finns ingen '{guess}' i den.");
                    lives--;
                }

                if (lives == 0)
                {
                    WriteLine("Du förlorade matchen ;(");
                }

                WriteLine("Tryck på valfri tangent för att fortsätta...");
                ReadKey();
            }
        }
    }
}
