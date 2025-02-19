using System;
using System.Collections;
using System.Collections.Generic;

class ReverseList
{
    // Method to reverse an ArrayList without using built-in reverse methods
    public static ArrayList ReverseArrayList(ArrayList list)
    {
        // Create a new ArrayList to store the reversed elements
        ArrayList reversedList = new ArrayList();
       
        // Iterate through the original list in reverse order
        for (int i = list.Count - 1; i >= 0; i--)
        {
            // Add each element to the new list
            reversedList.Add(list[i]);
        }
       
        // Return the reversed list
        return reversedList;
    }
   
    // Method to reverse a LinkedList without using built-in reverse methods
    public static LinkedList<T> ReverseLinkedList<T>(LinkedList<T> list)
    {
        // Create a new LinkedList to store the reversed elements
        LinkedList<T> reversedList = new LinkedList<T>();
       
        // Iterate through the original list from last to first
        LinkedListNode<T> current = list.Last;
        while (current != null)
        {
            // Add each element to the beginning of the new list
            reversedList.AddLast(current.Value);
            // Move to the previous node
            current = current.Previous;
        }
       
        // Return the reversed list
        return reversedList;
    }

    static void Main(string[] args)
    {
        // Test ArrayList reversal
        ArrayList arrayList = new ArrayList() { 1, 2, 3, 4, 5 };
       
        // Print original ArrayList
        Console.WriteLine("Original ArrayList:");
        // Iterate through each element in the ArrayList
        foreach (var item in arrayList)
        {
            // Print each element
            Console.Write(item + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Reverse the ArrayList
        ArrayList reversedArrayList = ReverseArrayList(arrayList);
       
        // Print reversed ArrayList
        Console.WriteLine("Reversed ArrayList:");
        // Iterate through each element in the reversed ArrayList
        foreach (var item in reversedArrayList)
        {
            // Print each element
            Console.Write(item + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Test LinkedList reversal
        LinkedList<int> linkedList = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });
       
        // Print original LinkedList
        Console.WriteLine("\nOriginal LinkedList:");
        // Iterate through each element in the LinkedList
        foreach (var item in linkedList)
        {
            // Print each element
            Console.Write(item + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Reverse the LinkedList
        LinkedList<int> reversedLinkedList = ReverseLinkedList(linkedList);
       
        // Print reversed LinkedList
        Console.WriteLine("Reversed LinkedList:");
        // Iterate through each element in the reversed LinkedList
        foreach (var item in reversedLinkedList)
        {
            // Print each element
            Console.Write(item + " ");
        }
        // Print a new line
        Console.WriteLine();
    }
}
