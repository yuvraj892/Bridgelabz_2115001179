using System;
using System.Collections.Generic;

class StackSorter
{
    // Function to sort the stack using recursion
    public static void SortStack(Stack<int> stack)
    {
        if (stack.Count > 0)
        {
            // Step 1: Pop the top element
            int temp = stack.Pop();

            // Step 2: Recursively sort the remaining stack
            SortStack(stack);

            // Step 3: Insert the popped element at the correct position
            InsertInSortedOrder(stack, temp);
        }
    }

    // Helper function to insert an element at the correct position in the sorted stack
    private static void InsertInSortedOrder(Stack<int> stack, int value)
    {
        // If the stack is empty or the top element is smaller or equal, push the value
        if (stack.Count == 0 || stack.Peek() <= value)
        {
            stack.Push(value);
        }
        else
        {
            // Step 1: Pop the top element
            int temp = stack.Pop();

            // Step 2: Recursively insert the value
            InsertInSortedOrder(stack, value);

            // Step 3: Push the popped element back
            stack.Push(temp);
        }
    }

    // Function to display the stack
    public static void DisplayStack(Stack<int> stack)
    {
        foreach (int value in stack)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();

        // Add elements to the stack
        stack.Push(3);
        stack.Push(1);
        stack.Push(4);
        stack.Push(2);
        stack.Push(5);

        Console.WriteLine("Original Stack:");
        DisplayStack(stack);

        // Sort the stack
        SortStack(stack);

        Console.WriteLine("Sorted Stack:");
        DisplayStack(stack);
    }
}
