using System;
using System.Collections.Generic;

class InvertMap
{
    // Method to invert a Dictionary<K, V> to a Dictionary<V, List<K>>
    public static Dictionary<V, List<K>> InvertDictionary<K, V>(Dictionary<K, V> originalDict)
    {
        // Create a new dictionary to store the inverted mapping
        Dictionary<V, List<K>> invertedDict = new Dictionary<V, List<K>>();
       
        // Iterate through each entry in the original dictionary
        foreach (KeyValuePair<K, V> entry in originalDict)
        {
            // Check if the value already exists as a key in the inverted dictionary
            if (invertedDict.ContainsKey(entry.Value))
            {
                // Add the original key to the list of keys for this value
                invertedDict[entry.Value].Add(entry.Key);
            }
            else
            {
                // Create a new list with the original key for this value
                invertedDict.Add(entry.Value, new List<K> { entry.Key });
            }
        }
       
        // Return the inverted dictionary
        return invertedDict;
    }
   
    static void Main(string[] args)
    {
        // Create a dictionary mapping letters to numbers
        Dictionary<string, int> letterToNumber = new Dictionary<string, int>
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 1 },
            { "D", 3 },
            { "E", 2 }
        };
       
        // Print the original dictionary
        Console.WriteLine("Original Dictionary:");
        // Iterate through each entry in the original dictionary
        foreach (KeyValuePair<string, int> entry in letterToNumber)
        {
            // Print each key-value pair
            Console.WriteLine(entry.Key + " = " + entry.Value);
        }
       
        // Invert the dictionary
        Dictionary<int, List<string>> numberToLetters = InvertDictionary(letterToNumber);
       
        // Print the inverted dictionary
        Console.WriteLine("\nInverted Dictionary:");
        // Iterate through each entry in the inverted dictionary
        foreach (KeyValuePair<int, List<string>> entry in numberToLetters)
        {
            // Start building the output string
            string letters = string.Join(", ", entry.Value);
            // Print the value and its corresponding keys
            Console.WriteLine(entry.Key + " = [" + letters + "]");
        }
       
        // Test with an empty dictionary
        Dictionary<string, double> emptyDict = new Dictionary<string, double>();
       
        // Invert the empty dictionary
        Dictionary<double, List<string>> invertedEmptyDict = InvertDictionary(emptyDict);
       
        // Print the result of inverting an empty dictionary
        Console.WriteLine("\nInverting an empty dictionary:");
        // Check if the inverted dictionary is empty
        if (invertedEmptyDict.Count == 0)
        {
            // Print message for empty dictionary
            Console.WriteLine("Result is also an empty dictionary.");
        }
       
        // Test with a dictionary having unique values
        Dictionary<int, string> idToName = new Dictionary<int, string>
        {
            { 1, "Alice" },
            { 2, "Bob" },
            { 3, "Charlie" }
        };
       
        // Print the dictionary with unique values
        Console.WriteLine("\nDictionary with unique values:");
        // Iterate through each entry in the dictionary
        foreach (KeyValuePair<int, string> entry in idToName)
        {
            // Print each key-value pair
            Console.WriteLine(entry.Key + " = " + entry.Value);
        }
       
        // Invert the dictionary with unique values
        Dictionary<string, List<int>> nameToIds = InvertDictionary(idToName);
       
        // Print the inverted dictionary
        Console.WriteLine("\nInverted Dictionary with unique values:");
        // Iterate through each entry in the inverted dictionary
        foreach (KeyValuePair<string, List<int>> entry in nameToIds)
        {
            // Start building the output string
            string ids = string.Join(", ", entry.Value);
            // Print the name and its corresponding IDs
            Console.WriteLine(entry.Key + " = [" + ids + "]");
        }
    }
}
