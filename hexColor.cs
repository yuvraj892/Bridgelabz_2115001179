using System;
using System.Text.RegularExpressions;

class HexColorvalidation
{
    static void Main(string[] args)
    {
        // Test cases for hex color validation
        string[] colors = { "#FFA500", "#ff4500", "#123", "#GGGGGG", "#FFB", "#FF00FF00" };

        // Regex pattern: # followed by exactly 6 hex digits (case insensitive)
        string pattern = @"^#[0-9A-Fa-f]{6}$";

        foreach (string color in colors)
        {
            // Check if hex color matches the pattern
            bool isValid = Regex.IsMatch(color, pattern);
           
            // Format and display the result
            string result = string.Format("Hex color '{0}' is {1}", color, isValid ? "valid" : "invalid");
            Console.WriteLine(result);
        }
    }
}
