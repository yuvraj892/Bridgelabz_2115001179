using System;
using System.Collections.Generic;

class RemoveDuplicates
{
    // Method to remove duplicates while preserving order
    public static List<T> RemoveDuplicatesPreserveOrder<T>(List<T> list)
    {
        // Create a new list to store unique elements
        List<T> result = new List<T>();
        // Create a hash set to track seen elements
        HashSet<T> seen = new HashSet<T>();
       
        // Iterate through each element in the original list
        foreach (T item in list)
        {
            // Check if the element has been seen before
            if (!seen.Contains(item))
            {
                // Add to the result list if it's the first occurrence
                result.Add(item);
                // Mark the element as seen
                seen.Add(item);
            }
        }
       
        // Return the list with duplicates removed
        return result;
    }
   
    static void Main(string[] args)
    {
        // Create a list of integers with duplicates
        List<int> numbers = new List<int>() { 3, 1, 2, 2, 3, 4, 1, 5, 5 };
       
        // Print the original list
        Console.WriteLine("Original list with duplicates:");
        // Iterate through each number in the list
        foreach (int num in numbers)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Remove duplicates while preserving order
        List<int> uniqueList = RemoveDuplicatesPreserveOrder(numbers);
       
        // Print the list with duplicates removed
        Console.WriteLine("\nList after removing duplicates (order preserved):");
        // Iterate through each number in the unique list
        foreach (int num in uniqueList)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Test with strings
        List<string> fruits = new List<string>() { "apple", "banana", "apple", "orange", "banana" };
       
        // Print the original list of strings
        Console.WriteLine("\nOriginal list of strings with duplicates:");
        // Iterate through each string in the list
        foreach (string fruit in fruits)
        {
            // Print each string
            Console.Write(fruit + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Remove duplicates while preserving order for strings
        List<string> uniqueFruits = RemoveDuplicatesPreserveOrder(fruits);
       
        // Print the list of strings with duplicates removed
        Console.WriteLine("\nList of strings after removing duplicates (order preserved):");
        // Iterate through each string in the unique list
        foreach (string fruit in uniqueFruits)
        {
            // Print each string
            Console.Write(fruit + " ");
        }
        // Print a new line
        Console.WriteLine();
    }
}
