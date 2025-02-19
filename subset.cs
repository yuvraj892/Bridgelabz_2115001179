using System;
using System.Collections.Generic;

class FindSubsets
{
    // Method to check if one set is a subset of another
    public static bool IsSubset<T>(HashSet<T> possibleSubset, HashSet<T> superset)
    {
        // Check if each element in the possible subset is in the superset
        foreach (T item in possibleSubset)
        {
            // If any element is not in the superset, it's not a subset
            if (!superset.Contains(item))
            {
                return false;
            }
        }
       
        // If all elements were found in the superset, it's a subset
        return true;
    }
   
    // Alternative method using built-in IsSubsetOf method
    public static bool IsSubsetBuiltIn<T>(HashSet<T> possibleSubset, HashSet<T> superset)
    {
        // Use the built-in IsSubsetOf method
        return possibleSubset.IsSubsetOf(superset);
    }
   
    static void Main(string[] args)
    {
        // Create a potential subset
        HashSet<int> smallSet = new HashSet<int>() { 2, 3 };
        // Create a superset
        HashSet<int> largeSet = new HashSet<int>() { 1, 2, 3, 4 };
        // Create a non-subset
        HashSet<int> nonSubset = new HashSet<int>() { 2, 5 };
       
        // Print the sets
        Console.WriteLine("Small Set:");
        // Iterate through each number in the small set
        foreach (int num in smallSet)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Print the large set
        Console.WriteLine("Large Set:");
        // Iterate through each number in the large set
        foreach (int num in largeSet)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Print the non-subset
        Console.WriteLine("Non-Subset:");
        // Iterate through each number in the non-subset
        foreach (int num in nonSubset)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Check if smallSet is a subset of largeSet
        bool isSmallSubset = IsSubset(smallSet, largeSet);
        // Print the result
        Console.WriteLine("\nIs Small Set a subset of Large Set? " + isSmallSubset);
       
        // Check if nonSubset is a subset of largeSet
        bool isNonSubset = IsSubset(nonSubset, largeSet);
        // Print the result
        Console.WriteLine("Is Non-Subset a subset of Large Set? " + isNonSubset);
       
        // Test with built-in method
        bool isSmallSubsetBuiltIn = IsSubsetBuiltIn(smallSet, largeSet);
        // Print the result using built-in method
        Console.WriteLine("\nUsing built-in method - Is Small Set a subset of Large Set? " + isSmallSubsetBuiltIn);
       
        // Test with string sets
        HashSet<string> smallStringSet = new HashSet<string>() { "apple", "banana" };
        HashSet<string> largeStringSet = new HashSet<string>() { "apple", "banana", "orange", "grape" };
       
        // Check if smallStringSet is a subset of largeStringSet
        bool isStringSubset = IsSubset(smallStringSet, largeStringSet);
        // Print the result
        Console.WriteLine("\nIs Small String Set a subset of Large String Set? " + isStringSubset);
    }
}
