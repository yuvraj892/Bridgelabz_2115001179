using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string filePath = "D:\\Capgemini-Tranning\\Assignments\\Assignment16\\CountWordOccurence\\sample.txt";
        string searchWord = "hello"; // Word to search (case-insensitive)

        try
        {
            int count = CountWordOccurrences(filePath, searchWord);
            Console.WriteLine($"The word '{searchWord}' appears {count} times in the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static int CountWordOccurrences(string filePath, string word)
    {
        int count = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Convert to lowercase for case-insensitive search
                string[] words = line.ToLower().Split(new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\t' });
                foreach (string w in words)
                {
                    if (w == word.ToLower())
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
}

