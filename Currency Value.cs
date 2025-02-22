using System;
using System.Text.RegularExpressions;

class CurrencyValueExtraction
{
    static void Main(string[] args)
    {
        // Sample text containing currency values
        string text = "The price is $45.99, and the discount is $ 10.50. " +
                     "Some items cost $100, $200.00, and $1,234.56";

        // Regex pattern for currency values
        // Matches optional $, optional space, optional thousands separator
        string pattern = @"\$\s*\d{1,3}(?:,\d{3})*(?:\.\d{2})?";

        // Find all matches in the text
        MatchCollection matches = Regex.Matches(text, pattern);

        // Print header
        Console.WriteLine("Currency values found:");

        // Extract and display each currency value
        foreach (Match match in matches)
        {
            // Remove spaces between $ and number
            string normalized = Regex.Replace(match.Value, @"\$\s+", "$");
            string result = string.Format("- {0}", normalized);
            Console.WriteLine(result);
        }
    }
}
