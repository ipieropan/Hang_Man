using System.Text;
using static System.Console;

namespace Hang_Man.Game
{
    public class Game
    {
        public static void Run()
        {
            bool alive = true;

            while (alive)
            {
                Clear();
                WriteLine("The Hangman Game!");

                WriteLine("[S] Start game" +
                        "\n[Q] Quit" +
                        "\n[L] Change Language (not updated)");

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.S:
                        GameStart();
                        break;
                    case ConsoleKey.Q:
                        alive = false;
                        break;
                    case ConsoleKey.L:
                        SelectLanguage();
                        break;
                    default:
                        WriteLine("Please select something in the menu");
                        break;

                }
            }
        }

        public static void GameStart()
        {
            Clear();
            Random random = new((int)DateTime.Now.Ticks);
            string wordToGuess = GameInfo.Words[random.Next(0, GameInfo.Words.Length)];
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
                WriteLine($"The word has {wordToGuess.Length} letters");
                WriteLine(displayToPlayer.ToString());

                if (wordToGuess == GameInfo.Words[3] || wordToGuess == GameInfo.Words[3])
                {
                    WriteLine("It is related to programming...");
                }
                else if (wordToGuess == GameInfo.Words[1])
                {
                    WriteLine("It's a beautiful name...");
                }


                WriteLine($"Attempts = {GameInfo.Attempts}" +
                    $"\nLives = {lives}");
                Write("\nGuesses: ");
                GameInfo.Guesses.ForEach(g => Write(g));
                Write("\nGuess a letter: ");
                GameInfo.Attempts++;
                string? input = ReadLine().ToUpper();
                GameInfo.Guesses.Add(input[0]);


                // case user enters nothing
                while (input == null)
                {
                    WriteLine("Input can't be null");
                    input = ReadLine().ToUpper();
                }

                char guess = input[0]; // takes always the first letter


                // case user tries the same letter more than once
                if (GameInfo.CorrectLetters.Contains(guess))
                {
                    WriteLine($"You've already tried '{guess}', and it was correct!");
                    continue;
                }
                else if (GameInfo.IncorrectLetters.Contains(guess))
                {
                    WriteLine($"You've already tried '{guess}', and it was incorrect!");
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

                    // guess the whole word //

                    WriteLine("Do you want to guess the whole word? (case it's wrong you lose 2 lives)" +
                        "\n[Y]Yes [N]No");
                    ConsoleKeyInfo player = Console.ReadKey(true);
                    switch (player.Key)
                    {
                        case ConsoleKey.Y:
                            {
                                Write("Your Guess: ");
                                GameInfo.GuessTheWord = ReadLine().ToUpper();
                                if (GameInfo.GuessTheWord == wordToGuessToUpper)
                                {
                                    WriteLine($"You got it: {wordToGuess} is right!");
                                    win = true;
                                }
                                else
                                {
                                    win = false;
                                    lives -= 2;
                                }
                                break;
                            }

                        case ConsoleKey.N:
                            break;
                    }
                }

                // do not contains the guess
                else
                {
                    GameInfo.IncorrectLetters.Add(guess);

                    WriteLine($"Nope, there's no '{guess}' in it.");
                    lives--;
                }

                if (lives == 0)
                {
                    Clear();
                    WriteLine($"Lives = {lives}");
                    WriteLine("You lose ;(");
                }

                WriteLine("Press any key to continue...");
                ReadKey();
            }
        }

        public static void SelectLanguage()
        {
            Clear();
            WriteLine("Which language you want?" +
                            "\n[E] English" +
                            "\n[S] Swedish");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.E:
                    GameStart();
                    break;
                case ConsoleKey.S:
                    GameInSwedish.GameStart();
                    break;
            }
        }
    }
}
