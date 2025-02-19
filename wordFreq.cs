using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class WordFrequencyCounter
{
    // Method to count word frequency in a text
    public static Dictionary<string, int> CountWordFrequency(string text)
    {
        // Create a dictionary to store word frequencies
        Dictionary<string, int> frequencyMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
       
        // Check if text is null or empty
        if (string.IsNullOrWhiteSpace(text))
        {
            // Return empty dictionary for empty input
            return frequencyMap;
        }
       
        // Split the text into words, removing punctuation
        string[] words = Regex.Split(text, @"\W+");
       
        // Count frequency of each word
        foreach (string word in words)
        {
            // Skip empty strings
            if (string.IsNullOrWhiteSpace(word))
            {
                continue;
            }
           
            // Convert word to lowercase for case-insensitive comparison
            string normalizedWord = word.ToLower();
           
            // Check if the word exists in the dictionary
            if (frequencyMap.ContainsKey(normalizedWord))
            {
                // Increment count if word exists
                frequencyMap[normalizedWord]++;
            }
            else
            {
                // Add the word with count 1 if it doesn't exist
                frequencyMap.Add(normalizedWord, 1);
            }
        }
       
        // Return the frequency map
        return frequencyMap;
    }
   
    // Method to count word frequency in a file
    public static Dictionary<string, int> CountWordFrequencyInFile(string filePath)
    {
        try
        {
            // Read all text from the file
            string text = File.ReadAllText(filePath);
            // Count word frequency in the text
            return CountWordFrequency(text);
        }
        catch (Exception ex)
        {
            // Print error message
            Console.WriteLine("Error reading file: " + ex.Message);
            // Return empty dictionary on error
            return new Dictionary<string, int>();
        }
    }
   
    static void Main(string[] args)
    {
        // Sample text for testing
        string text = "Hello world, hello Java! Hello C#, hello Python, java is great.";
       
        // Print the input text
        Console.WriteLine("Input text:");
        Console.WriteLine(text);
       
        // Count word frequency
        Dictionary<string, int> wordFrequency = CountWordFrequency(text);
       
        // Print the word frequency
        Console.WriteLine("\nWord Frequency:");
        // Iterate through each word and its frequency
        foreach (KeyValuePair<string, int> pair in wordFrequency)
        {
            // Skip empty words
            if (string.IsNullOrWhiteSpace(pair.Key))
                continue;
           
            // Print the word and its frequency
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
       
        // Create a test file for file reading test
        string testFilePath = "test_text.txt";
        // Write sample text to a file
        File.WriteAllText(testFilePath, "This is a test file.\nThis file contains test text.\nTest file is used to test word frequency counter.");
       
        // Print notification about file test
        Console.WriteLine("\nTesting word frequency count from file: " + testFilePath);
       
        // Count word frequency in the file
        Dictionary<string, int> fileWordFrequency = CountWordFrequencyInFile(testFilePath);
       
        // Print the word frequency from file
        Console.WriteLine("\nWord Frequency from file:");
        // Iterate through each word and its frequency
        foreach (KeyValuePair<string, int> pair in fileWordFrequency)
        {
            // Skip empty words
            if (string.IsNullOrWhiteSpace(pair.Key))
                continue;
           
            // Print the word and its frequency
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
       
        // Check for top 3 most frequent words
        Console.WriteLine("\nTop 3 most frequent words:");
        // Convert dictionary to list for sorting
        List<KeyValuePair<string, int>> wordList = new List<KeyValuePair<string, int>>(fileWordFrequency);
        // Sort the list by frequency in descending order
        wordList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
       
        // Print top 3 words (or less if there are fewer words)
        for (int i = 0; i < Math.Min(3, wordList.Count); i++)
        {
            // Print word and its frequency
            Console.WriteLine((i + 1) + ". " + wordList[i].Key + ": " + wordList[i].Value);
        }
       
        // Clean up - delete the test file
        File.Delete(testFilePath);
    }
}
