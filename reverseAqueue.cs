using System;
using System.Collections.Generic;

class ReverseQueue
{
    // Method to reverse a queue using only queue operations
    public static Queue<T> ReverseQueueUsingStack<T>(Queue<T> queue)
    {
        // Create a stack to temporarily store elements
        Stack<T> stack = new Stack<T>();
       
        // Dequeue all elements from the queue and push to the stack
        while (queue.Count > 0)
        {
            // Dequeue an element from the queue
            T item = queue.Dequeue();
            // Push the element onto the stack
            stack.Push(item);
        }
       
        // Create a new queue for the result
        Queue<T> reversedQueue = new Queue<T>();
       
        // Pop all elements from the stack and enqueue to the new queue
        while (stack.Count > 0)
        {
            // Pop an element from the stack
            T item = stack.Pop();
            // Enqueue the element to the new queue
            reversedQueue.Enqueue(item);
        }
       
        // Return the reversed queue
        return reversedQueue;
    }
   
    // Alternative method to reverse a queue using recursion
    public static void ReverseQueueRecursive<T>(Queue<T> queue)
    {
        // Base case: if queue is empty, return
        if (queue.Count == 0)
            return;
       
        // Dequeue the front element
        T frontItem = queue.Dequeue();
       
        // Recursively reverse the remaining queue
        ReverseQueueRecursive(queue);
       
        // Enqueue the front element to put it at the back
        queue.Enqueue(frontItem);
    }
   
    static void Main(string[] args)
    {
        // Create a queue of integers
        Queue<int> queue = new Queue<int>();
       
        // Enqueue elements
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Enqueue(40);
        queue.Enqueue(50);
       
        // Print the original queue
        Console.WriteLine("Original Queue:");
        // Convert queue to array for display
        int[] queueArray = queue.ToArray();
        // Iterate through the array
        foreach (int item in queueArray)
        {
            // Print each item
            Console.Write(item + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Create a copy for the recursive method
        Queue<int> queueCopy = new Queue<int>(queue);
       
        // Reverse the queue using stack method
        Queue<int> reversedQueue = ReverseQueueUsingStack(queue);
       
        // Print the reversed queue
        Console.WriteLine("\nReversed Queue (Using Stack):");
        // Convert reversed queue to array for display
        int[] reversedArray = reversedQueue.ToArray();
        // Iterate through the array
        foreach (int item in reversedArray)
        {
            // Print each item
            Console.Write(item + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Reverse the queue copy using recursive method
        ReverseQueueRecursive(queueCopy);
       
        // Print the recursively reversed queue
        Console.WriteLine("\nReversed Queue (Using Recursion):");
        // Convert recursively reversed queue to array for display
        int[] recursiveReversedArray = queueCopy.ToArray();
        // Iterate through the array
        foreach (int item in recursiveReversedArray)
        {
            // Print each item
            Console.Write(item + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Test with a queue of strings
        Queue<string> stringQueue = new Queue<string>();
       
        // Enqueue string elements
        stringQueue.Enqueue("First");
        stringQueue.Enqueue("Second");
        stringQueue.Enqueue("Third");
       
        // Print the original string queue
        Console.WriteLine("\nOriginal String Queue:");
        // Convert string queue to array for display
        string[] stringQueueArray = stringQueue.ToArray();
        // Iterate through the array
        foreach (string item in stringQueueArray)
        {
            // Print each item
            Console.Write(item + " ");
        }
        // Print a new line
        Console.WriteLine();
       
        // Reverse the string queue
        Queue<string> reversedStringQueue = ReverseQueueUsingStack(stringQueue);
       
        // Print the reversed string queue
        Console.WriteLine("\nReversed String Queue:");
        // Convert reversed string queue to array for display
        string[] reversedStringArray = reversedStringQueue.ToArray();
        // Iterate through the array
        foreach (string item in reversedStringArray)
        {
            // Print each item
            Console.Write(item + " ");
        }
        // Print a new line
        Console.WriteLine();
    }
}
