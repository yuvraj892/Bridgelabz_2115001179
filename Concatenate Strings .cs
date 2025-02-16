using System;
using System.Text;

class Program
{
    static void Main()
    {
        string[] words = { "Hello", " ", "World", "!", " ", "I", " ", "am", " ", "Learning", " ", "C#" };

        string result = ConcatenateStrings(words);
        Console.WriteLine("Concatenated String: " + result);
    }

    static string ConcatenateStrings(string[] words)
    {
        StringBuilder sb = new StringBuilder();

        foreach (string word in words)
        {
            sb.Append(word);
        }

        return sb.ToString();
    }
}

