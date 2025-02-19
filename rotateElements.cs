using System;
using System.Collections.Generic;

class RotateList
{
    // Method to rotate elements in a list by a given number of positions
    public static List<T> RotateElements<T>(List<T> list, int positions)
    {
        // Check if the list is empty or has only one element
        if (list.Count <= 1)
        {
            // Return the original list if it's empty or has one element
            return new List<T>(list);
        }
       
        // Normalize the number of positions
        int actualPositions = positions % list.Count;
        // Handle negative rotations
        if (actualPositions < 0)
        {
            // Convert negative rotation to equivalent positive rotation
            actualPositions += list.Count;
        }
       
        // If no rotation needed
        if (actualPositions == 0)
        {
            // Return a copy of the original list
            return new List<T>(list);
        }
       
        // Create a new list for the result
        List<T> rotatedList = new List<T>(list.Count);
       
        // Add elements from the rotation point to the end
        for (int i = actualPositions; i < list.Count; i++)
        {
            // Add element to the new list
            rotatedList.Add(list[i]);
        }
       
        // Add elements from the beginning to the rotation point
        for (int i = 0; i < actualPositions; i++)
        {
            // Add element to the new list
            rotatedList.Add(list[i]);
        }
       
        // Return the rotated list
        return rotatedList;
    }
   
    static void Main(string[] args)
    {
        // Create a list of integers for testing
        List<int> numbers = new List<int>() { 10, 20, 30, 40, 50 };
        // Number of positions to rotate
        int rotateBy = 2;
       
        // Print the original list
        Console.WriteLine("Original list:");
        // Iterate through each number in the list
        foreach (int num in numbers)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Rotate the list
        List<int> rotatedList = RotateElements(numbers, rotateBy);
       
        // Print the rotated list
        Console.WriteLine("\nList after rotating by " + rotateBy + " positions:");
        // Iterate through each number in the rotated list
        foreach (int num in rotatedList)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Test with negative rotation
        rotateBy = -1;
        // Rotate the list with negative value
        rotatedList = RotateElements(numbers, rotateBy);
       
        // Print the list rotated by negative positions
        Console.WriteLine("\nList after rotating by " + rotateBy + " positions:");
        // Iterate through each number in the rotated list
        foreach (int num in rotatedList)
        {
            // Print each number
            Console.Write(num + " ");
        }
        // Print a new line
        Console.WriteLine();
    }
}
