using System;

class Program
{
    static void Main()
    {
        string[] sentences =
        {
            "The quick brown fox jumps over the lazy dog.",
            "C# is a powerful programming language.",
            "Coding is fun and rewarding.",
            "Practice makes a programmer perfect."
        };

        Console.Write("Enter the word to search: ");
        string searchWord = Console.ReadLine();

        string result = FindSentenceWithWord(sentences, searchWord);

        if (result != null)
            Console.WriteLine("First sentence containing the word: " + result);
        else
            Console.WriteLine("No sentence contains the word.");
    }

    static string FindSentenceWithWord(string[] sentences, string word)
    {
        word = word.ToLower(); 

        foreach (string sentence in sentences)
        {
            string lowerSentence = sentence.ToLower(); 
            if (lowerSentence.Contains(word)) 
                return sentence; 
        }
        return null; 
    }
}
