using System;
using System.Collections.Generic;
using System.Linq;

class SetToSortedList
{
    // Method to convert a HashSet to a sorted List
    public static List<T> ConvertSetToSortedList<T>(HashSet<T> set) where T : IComparable<T>
    {
        // Create a new list from the set
        List<T> sortedList = new List<T>(set);
       
        // Sort the list
        sortedList.Sort();
       
        // Return the sorted list
        return sortedList;
    }
   
    // Alternative method using LINQ
    public static List<T> ConvertSetToSortedListLinq<T>(HashSet<T> set)
    {
        // Use LINQ to order the elements and convert to a list
        return set.OrderBy(item => item).ToList();
    }
   
    static void Main(string[] args)
    {
        // Create a HashSet of integers
        HashSet<int> intSet = new HashSet<int>() { 5, 3, 9, 1, 7 };
       
        // Print the original set
        Console.WriteLine("Original HashSet:");
        // Iterate through each number in the set
        foreach (int num in intSet)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Convert to sorted list
        List<int> sortedList = ConvertSetToSortedList(intSet);
       
        // Print the sorted list
        Console.WriteLine("\nSorted List (Method 1):");
        // Iterate through each number in the sorted list
        foreach (int num in sortedList)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Convert to sorted list using LINQ
        List<int> sortedListLinq = ConvertSetToSortedListLinq(intSet);
       
        // Print the sorted list from LINQ
        Console.WriteLine("\nSorted List (Using LINQ):");
        // Iterate through each number in the sorted list from LINQ
        foreach (int num in sortedListLinq)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Test with a HashSet of strings
        HashSet<string> stringSet = new HashSet<string>() { "orange", "apple", "banana", "grape" };
       
        // Print the original string set
        Console.WriteLine("\nOriginal String HashSet:");
        // Iterate through each string in the set
        foreach (string str in stringSet)
        {
            // Print each string
            Console.Write(str + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Convert string set to sorted list
        List<string> sortedStringList = ConvertSetToSortedList(stringSet);
       
        // Print the sorted string list
        Console.WriteLine("\nSorted String List:");
        // Iterate through each string in the sorted list
        foreach (string str in sortedStringList)
        {
            // Print each string
            Console.Write(str + " ");
        }
        // Print a new line
        Console.WriteLine();
    }
}
