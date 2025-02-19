using System;
using System.Collections.Generic;

class UnionIntersection
{
    // Method to compute the union of two sets
    public static HashSet<T> ComputeUnion<T>(HashSet<T> set1, HashSet<T> set2)
    {
        // Create a new set to store the union
        HashSet<T> unionSet = new HashSet<T>(set1);
       
        // Add all elements from set2 to the union set
        foreach (T item in set2)
        {
            // Add the item to the union set
            unionSet.Add(item);
        }
       
        // Return the union set
        return unionSet;
    }
   
    // Method to compute the intersection of two sets
    public static HashSet<T> ComputeIntersection<T>(HashSet<T> set1, HashSet<T> set2)
    {
        // Create a new set to store the intersection
        HashSet<T> intersectionSet = new HashSet<T>();
       
        // Add elements from set1 that are also in set2
        foreach (T item in set1)
        {
            // Check if the item is in set2
            if (set2.Contains(item))
            {
                // Add the item to the intersection set
                intersectionSet.Add(item);
            }
        }
       
        // Return the intersection set
        return intersectionSet;
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
       
        // Compute union
        HashSet<int> union = ComputeUnion(set1, set2);
       
        // Print union
        Console.WriteLine("\nUnion of Set 1 and Set 2:");
        // Iterate through each number in the union set
        foreach (int num in union)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Compute intersection
        HashSet<int> intersection = ComputeIntersection(set1, set2);
       
        // Print intersection
        Console.WriteLine("\nIntersection of Set 1 and Set 2:");
        // Iterate through each number in the intersection set
        foreach (int num in intersection)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Test with string sets
        HashSet<string> strSet1 = new HashSet<string>() { "apple", "banana", "orange" };
        HashSet<string> strSet2 = new HashSet<string>() { "orange", "grape", "pear" };
       
        // Compute union of string sets
        HashSet<string> strUnion = ComputeUnion(strSet1, strSet2);
       
        // Print string union
        Console.WriteLine("\nUnion of string sets:");
        // Iterate through each string in the union set
        foreach (string str in strUnion)
        {
            // Print each string
            Console.Write(str + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Compute intersection of string sets
        HashSet<string> strIntersection = ComputeIntersection(strSet1, strSet2);
       
        // Print string intersection
        Console.WriteLine("\nIntersection of string sets:");
        // Iterate through each string in the intersection set
        foreach (string str in strIntersection)
        {
            // Print each string
            Console.Write(str + " ");
        }
        // Print a new line
        Console.WriteLine();
    }
}
