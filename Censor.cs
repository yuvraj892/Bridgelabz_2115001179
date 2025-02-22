using System;
using System.Text.RegularExpressions;

class CensorBadWords
{
    static void Main(string[] args)
    {
        // Sample text with words to censor
        string text = "This is a damn bad example with some stupid words.";

        // List of words to censor
        string[] badWords = { "damn", "stupid" };

        // Create pattern from bad words list
        string pattern = string.Format(@"\b({0})\b", string.Join("|", badWords));

        // Replace bad words with asterisks
        string censored = Regex.Replace(text, pattern, "****");

        // Print original and censored text
        Console.WriteLine("Original text:");
        Console.WriteLine(text);
        Console.WriteLine("\nCensored text:");
        Console.WriteLine(censored);
    }
}
