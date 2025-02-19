using System;
using System.Collections.Generic;

class CheckEqualSets
{
    // Method to check if two sets contain the same elements
    public static bool AreSetsEqual<T>(HashSet<T> set1, HashSet<T> set2)
    {
        // First check if sets have the same count
        if (set1.Count != set2.Count)
        {
            // If counts differ, sets cannot be equal
            return false;
        }
       
        // Check if each element in set1 is present in set2
        foreach (T item in set1)
        {
            // If any element from set1 is not in set2, sets are not equal
            if (!set2.Contains(item))
            {
                return false;
            }
        }
       
        // If we get here, sets contain the same elements
        return true;
    }
   
    static void Main(string[] args)
    {
        // Create first set
        HashSet<int> set1 = new HashSet<int>() { 1, 2, 3 };
        // Create second set with same elements in different order
        HashSet<int> set2 = new HashSet<int>() { 3, 2, 1 };
        // Create third set with different elements
        HashSet<int> set3 = new HashSet<int>() { 1, 2, 4 };
       
        // Print the sets
        Console.WriteLine("Set 1:");
        // Iterate through each number in set1
        foreach (int num in set1)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Print set2
        Console.WriteLine("Set 2:");
        // Iterate through each number in set2
        foreach (int num in set2)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Print set3
        Console.WriteLine("Set 3:");
        // Iterate through each number in set3
        foreach (int num in set3)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Check if set1 and set2 are equal
        bool areEqual1And2 = AreSetsEqual(set1, set2);
        // Print the result
        Console.WriteLine("\nAre Set 1 and Set 2 equal? " + areEqual1And2);
       
        // Check if set1 and set3 are equal
        bool areEqual1And3 = AreSetsEqual(set1, set3);
        // Print the result
        Console.WriteLine("Are Set 1 and Set 3 equal? " + areEqual1And3);
       
        // Demonstrate with string sets
        HashSet<string> strSet1 = new HashSet<string>() { "apple", "banana", "orange" };
        HashSet<string> strSet2 = new HashSet<string>() { "orange", "apple", "banana" };
       
        // Check if string sets are equal
        bool areStringSetsEqual = AreSetsEqual(strSet1, strSet2);
        // Print the result
        Console.WriteLine("\nAre string sets equal? " + areStringSetsEqual);
    }
}
