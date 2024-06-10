using System.Text.RegularExpressions;

namespace WordCounter
{
    public static class StringExtensions
    {
        public static int LengthOfLastWord(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            var words = Regex.Split(str, @"\W+");

            words = Array.FindAll(words, w => !string.IsNullOrEmpty(w));

            if (words.Length == 0)
                return 0;

            return words[^1].Length;
        }
    }
}


namespace WordCounter
{
    class Program
    {
        static void Main()
        {
            string[] testLines =
            {
                "Hello, world!",
                "This is a test line with several words.",
                "SingleWord",
                "",
                "     ",
                "Another\ttest\twith\ttabs",
                "New\nline\ncharacters\nare\nalso\nhandled.",
                "   Leading and trailing spaces are ignored   "
            };

            foreach (var line in testLines)
            {
                Console.WriteLine($"The length of the last word in \"{line}\" is {line.LengthOfLastWord()}.");
            }
        }
    }
}

