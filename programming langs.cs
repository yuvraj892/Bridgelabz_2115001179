using System;
using System.Text.RegularExpressions;

class LanguageExtraction
{
    static void Main(string[] args)
    {
        // Sample text containing programming language names
        string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet. " +
                     "Some people also use C++, C#, and Ruby. kotlin is also popular.";

        // List of programming languages to match
        string[] languages = {
            "Java", "Python", "JavaScript", "Go", "C\\+\\+", "C#", "Ruby", "Kotlin"
        };

        // Create pattern from language list (case-insensitive)
        string pattern = string.Format(@"\b({0})\b", string.Join("|", languages));

        // Find all matches in the text
        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        // Print header
        Console.WriteLine("Programming languages found:");

        // Extract and display each language
        foreach (Match match in matches)
        {
            string result = string.Format("- {0}", match.Value);
            Console.WriteLine(result);
        }
    }
}
