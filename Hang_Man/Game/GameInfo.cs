using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hang_Man.Game
{
    public static class GameInfo
    {
        // box with words for the game (random will pick one of them every game)

        public static string[] Words = { "Music", "Igor", "Gothenburg", "VsCode", "Github", "King", "Marabou" };
        public static string[] WordsSwedish = { "Musik", "Igor", "Göteborg", "VsCode", "Github", "Kung", "Marabou" };

        public static List<char> IncorrectLetters = new();
        public static List<char> CorrectLetters = new();
        public static List<char> Guesses = new();

        public static string GuessTheWord { get; set; }
        public static int Attempts { get; set; }
    }
}
