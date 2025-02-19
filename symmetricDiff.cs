using System;
using System.Collections.Generic;

class SymmetricDifference
{
    // Method to compute symmetric difference between two sets
    public static HashSet<T> ComputeSymmetricDifference<T>(HashSet<T> set1, HashSet<T> set2)
    {
        // Create a new set to store the symmetric difference
        HashSet<T> result = new HashSet<T>();
       
        // Add elements from set1 that are not in set2
        foreach (T item in set1)
        {
            // Check if the item is not in set2
            if (!set2.Contains(item))
            {
                // Add the item to the result set
                result.Add(item);
            }
        }
       
        // Add elements from set2 that are not in set1
        foreach (T item in set2)
        {
            // Check if the item is not in set1
            if (!set1.Contains(item))
            {
                // Add the item to the result set
                result.Add(item);
            }
        }
       
        // Return the symmetric difference
        return result;
    }
   
    // Alternative implementation using set operations
    public static HashSet<T> ComputeSymmetricDifferenceUsingSetOps<T>(HashSet<T> set1, HashSet<T> set2)
    {
        // Create copies of the sets
        HashSet<T> unionSet = new HashSet<T>(set1);
        HashSet<T> intersectionSet = new HashSet<T>(set1);
       
        // Compute union
        unionSet.UnionWith(set2);
       
        // Compute intersection
        intersectionSet.IntersectWith(set2);
       
        // Compute symmetric difference (union - intersection)
        unionSet.ExceptWith(intersectionSet);
       
        // Return the result
        return unionSet;
    }
   
    static void Main(string[] args)
    {
        // Create first set
        HashSet<int> set1 = new HashSet<int>() { 1, 2, 3 };
        // Create second set
        HashSet<int> set2 = new HashSet<int>() { 3, 4, 5 };
       
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
       
        // Compute symmetric difference
        HashSet<int> symmetricDiff = ComputeSymmetricDifference(set1, set2);
       
        // Print symmetric difference
        Console.WriteLine("\nSymmetric Difference (Method 1):");
        // Iterate through each number in the symmetric difference set
        foreach (int num in symmetricDiff)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Compute symmetric difference using set operations
        HashSet<int> symmetricDiffSet = ComputeSymmetricDifferenceUsingSetOps(set1, set2);
       
        // Print symmetric difference using set operations
        Console.WriteLine("\nSymmetric Difference (Using Set Operations):");
        // Iterate through each number in the symmetric difference set
        foreach (int num in symmetricDiffSet)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Test with string sets
        HashSet<string> strSet1 = new HashSet<string>() { "apple", "banana", "orange" };
        HashSet<string> strSet2 = new HashSet<string>() { "orange", "grape", "pear" };
       
        // Compute symmetric difference of string sets
        HashSet<string> strSymDiff = ComputeSymmetricDifference(strSet1, strSet2);
       
        // Print string symmetric difference
        Console.WriteLine("\nSymmetric Difference of string sets:");
        // Iterate through each string in the symmetric difference set
        foreach (string str in strSymDiff)
        {
            // Print each string
            Console.Write(str + " ");
        }
        // Print a new line
        Console.WriteLine();
    }
}
