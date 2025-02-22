using System;
using System.Text.RegularExpressions;

class EmailExtraction
{
    static void Main(string[] args)
    {
        // Sample text containing email addresses
        string text = "Contact us at support@example.com and info@company.org. Invalid emails: not.an.email, missing@domain.";

        // Regex pattern for email matching
        string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

        // Find all matches in the text
        MatchCollection matches = Regex.Matches(text, pattern);

        // Print header
        Console.WriteLine("Extracted email addresses:");

        // Extract and display each email address
        foreach (Match match in matches)
        {
            string result = string.Format("- {0}", match.Value);
            Console.WriteLine(result);
        }
    }
}
