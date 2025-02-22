using System;
using System.Text.RegularExpressions;

class CapitalizedWordsExtraction
{
    static void Main(string[] args)
    {
        // Sample text containing capitalized words
        string text = "The Eiffel Tower is in Paris and the Statue of Liberty is in New York.";

        // Regex pattern for words starting with capital letters
        string pattern = @"\b[A-Z][a-zA-Z]*\b";

        // Find all matches in the text
        MatchCollection matches = Regex.Matches(text, pattern);

        // Print header
        Console.WriteLine("Capitalized words:");

        // Extract and display each capitalized word
        foreach (Match match in matches)
        {
            string result = string.Format("- {0}", match.Value);
            Console.WriteLine(result);
        }
    }
}
