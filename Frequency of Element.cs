using System;
using System.Collections.Generic;

class FrequencyCounter
{
    // Method to count frequency of each element in a list of strings
    public static Dictionary<string, int> CountFrequency(List<string> items)
    {
        // Create a new dictionary to store frequencies
        Dictionary<string, int> frequencyMap = new Dictionary<string, int>();
       
        // Iterate through each item in the list
        foreach (string item in items)
        {
            // Convert the item to lowercase for case-insensitive comparison
            string normalizedItem = item.ToLower();
           
            // Check if the dictionary already contains the item
            if (frequencyMap.ContainsKey(normalizedItem))
            {
                // Increment the count if item exists
                frequencyMap[normalizedItem]++;
            }
            else
            {
                // Add the item with count 1 if it doesn't exist
                frequencyMap.Add(normalizedItem, 1);
            }
        }
       
        // Return the frequency dictionary
        return frequencyMap;
    }
   
    static void Main(string[] args)
    {
        // Create a list of strings for testing
        List<string> fruits = new List<string>() { "apple", "banana", "apple", "orange", "banana", "apple" };
       
        // Print the original list
        Console.WriteLine("Original list:");
        // Iterate through each item in the list
        foreach (string fruit in fruits)
        {
            // Print each item
            Console.Write(fruit + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Count the frequency of each element
        Dictionary<string, int> frequency = CountFrequency(fruits);
       
        // Print the frequency map
        Console.WriteLine("\nFrequency of each element:");
        // Iterate through each key-value pair in the dictionary
        foreach (KeyValuePair<string, int> pair in frequency)
        {
            // Print the key and its frequency
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }
}
ḍ