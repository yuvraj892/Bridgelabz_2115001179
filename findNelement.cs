using System;
using System.Collections.Generic;

class FindNthFromEnd
{
    // Method to find the Nth element from the end of a LinkedList
    public static T FindNthElementFromEnd<T>(LinkedList<T> list, int n)
    {
        // Check if the list is empty
        if (list.Count == 0)
        {
            // Throw exception if list is empty
            throw new InvalidOperationException("The list is empty");
        }
       
        // Check if n is valid
        if (n <= 0)
        {
            // Throw exception if n is not positive
            throw new ArgumentException("N must be a positive integer");
        }
       
        // Initialize two pointers
        LinkedListNode<T> ahead = list.First;
        LinkedListNode<T> behind = list.First;
       
        // Move the ahead pointer n nodes forward
        for (int i = 0; i < n; i++)
        {
            // Check if ahead pointer is null
            if (ahead == null)
            {
                // Throw exception if n is greater than list length
                throw new ArgumentException("N is greater than the length of the list");
            }
            // Move ahead pointer forward
            ahead = ahead.Next;
        }
       
        // Move both pointers until ahead reaches the end
        while (ahead != null)
        {
            // Move ahead pointer forward
            ahead = ahead.Next;
            // Move behind pointer forward
            behind = behind.Next;
        }
       
        // Return the value at behind pointer (Nth from end)
        return behind.Value;
    }
   
    static void Main(string[] args)
    {
        // Create a linked list of characters
        LinkedList<char> letters = new LinkedList<char>(new[] { 'A', 'B', 'C', 'D', 'E' });
       
        // Print the original linked list
        Console.WriteLine("Original LinkedList:");
        // Iterate through each character in the linked list
        foreach (char letter in letters)
        {
            // Print each character
            Console.Write(letter + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        try
        {
            // Find 2nd element from the end
            int n = 2;
            // Call the method to find the element
            char result = FindNthElementFromEnd(letters, n);
            // Print the result
            Console.WriteLine("\n" + n + "nd element from the end: " + result);
           
            // Find 1st element from the end
            n = 1;
            // Call the method to find the element
            result = FindNthElementFromEnd(letters, n);
            // Print the result
            Console.WriteLine(n + "st element from the end: " + result);
           
            // Find 5th element from the end
            n = 5;
            // Call the method to find the element
            result = FindNthElementFromEnd(letters, n);
            // Print the result
            Console.WriteLine(n + "th element from the end: " + result);
           
            // Try to find 6th element from the end (should throw exception)
            n = 6;
            // Call the method to find the element
            result = FindNthElementFromEnd(letters, n);
        }
        catch (Exception ex)
        {
            // Print any exception that occurred
            Console.WriteLine("\nException: " + ex.Message);
        }
    }
}
