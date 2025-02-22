using System;
using System.Text.RegularExpressions;
using System.Linq;

class StringModification
{
    static void Main(string[] args)
    {
        // Sample text with multiple spaces
        string text = "This    is   an    example    with     multiple    spaces.";

        // Regex pattern to match multiple spaces
        string pattern = @"\s+";

        // Replace multiple spaces with single space
        string normalized = Regex.Replace(text, pattern, " ");

        // Print original and normalized text
        Console.WriteLine("Original text:");
        Console.WriteLine(text);
        Console.WriteLine("\nNormalized text:");
        Console.WriteLine(normalized);

        // Verify the difference in space count
        int originalSpaces = text.Count(c => c == ' ');
        int normalizedSpaces = normalized.Count(c => c == ' ');

        // Format comparison string without interpolation
        string comparison = string.Format(
            "Space count - Original: {0}, Normalized: {1}",
            originalSpaces,
            normalizedSpaces
        );
        Console.WriteLine("\n" + comparison);
    }
}
