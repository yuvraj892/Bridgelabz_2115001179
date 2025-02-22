using System;
using System.Text.RegularExpressions;

class LinkExtraction
{
    static void Main(string[] args)
    {
        // Sample text containing web links
        string text = "Visit https://www.google.com and http://example.org for more info.";

        // Regex pattern for http/https URLs
        string pattern = @"https?://[^\s]+";

        // Find all matches in the text
        MatchCollection matches = Regex.Matches(text, pattern);

        // Print header
        Console.WriteLine("Web links found:");

        // Extract and display each link
        foreach (Match match in matches)
        {
            string result = string.Format("- {0}", match.Value);
            Console.WriteLine(result);
        }
    }
}
