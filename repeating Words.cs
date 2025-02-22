using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class RepeatingWrds
{
    static void Main(string[] args)
    {
        // Sample text with repeating words
        string text = "This is is a repeated repeated word test test. The the quick brown fox.";

        // Regex pattern for finding repeated words
        // Matches word boundaries and captures the word
        string pattern = @"\b(\w+)\b\s+\b\1\b";

        // Find all matches in the text
        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        // Use HashSet to store unique repeated words
        HashSet<string> repeatedWords = new HashSet<string>(
            matches.Cast<Match>()
                  .Select(m => m.Groups[1].Value.ToLower())
        );

        // Print header
        Console.WriteLine("Repeating words found:");

        // Display each repeated word
        foreach (string word in repeatedWords)
        {
            string result = string.Format("- {0}", word);
            Console.WriteLine(result);
        }
    }
}
