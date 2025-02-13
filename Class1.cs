using System;
using System.Collections.Generic;

class QueueUsingStacks
{
    private Stack<int> stack1; // Used for enqueuing
    private Stack<int> stack2; // Used for dequeuing

    public QueueUsingStacks()
    {
        stack1 = new Stack<int>();
        stack2 = new Stack<int>();
    }

    // Enqueue operation
    public void Enqueue(int value)
    {
        stack1.Push(value);
    }

    // Dequeue operation (checks for empty queue without exception handling)
    public int Dequeue()
    {
        // If both stacks are empty, return -1 
        if (stack1.Count == 0 && stack2.Count == 0)
        {
            Console.WriteLine("Queue is empty.");
            return -1; // You can also return any sentinel value
        }

        // If stack2 is empty, transfer all elements from stack1 to stack2
        if (stack2.Count == 0)
        {
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
        }

        return stack2.Pop();
    }

    // Display all elements in the queue
    public void Display()
    {
        if (stack1.Count == 0 && stack2.Count == 0)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        // Transfer elements from stack1 to stack2 to show the correct order
        while (stack1.Count > 0)
        {
            stack2.Push(stack1.Pop());
        }

        Console.WriteLine("Queue contents (front to back):");
        foreach (int value in stack2)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        QueueUsingStacks queue = new QueueUsingStacks();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Console.WriteLine("Dequeue: " + queue.Dequeue());
        queue.Enqueue(40);

        queue.Display();
    }
}
