using System;
using System.Text.RegularExpressions;

class DateExtraction
{
    static void Main(string[] args)
    {
        // Sample text containing dates
        string text = "The events are scheduled for 12/05/2023, 15/08/2024, and 29/02/2020.";

        // Regex pattern for dd/mm/yyyy format
        string pattern = @"\b(0[1-9]|[12]\d|3[01])/(0[1-9]|1[0-2])/\d{4}\b";

        // Find all matches in the text
        MatchCollection matches = Regex.Matches(text, pattern);

        // Print header
        Console.WriteLine("Dates found (dd/mm/yyyy format):");

        // Extract and display each date
        foreach (Match match in matches)
        {
            string result = string.Format("- {0}", match.Value);
            Console.WriteLine(result);
        }
    }
}
