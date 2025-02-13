using System;
using System.Collections.Generic;

class StockSpan
{
    public static int[] CalculateSpan(int[] prices)
    {
        int n = prices.Length;
        int[] span = new int[n];
        Stack<int> stack = new Stack<int>();

        // Traverse each price
        for (int i = 0; i < n; i++)
        {
            // Pop elements from stack while stack is not empty and the price at the top of the stack is less than or equal to current price
            while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
            {
                stack.Pop();
            }

            // Calculate the span
            span[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());

            // Push the current index to the stack
            stack.Push(i);
        }

        return span;
    }

    // Display function to print the array
    public static void Display(int[] arr)
    {
        foreach (int value in arr)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int[] prices = { 100, 80, 60, 70, 60, 75, 85 };

        Console.WriteLine("Stock Prices:");
        Display(prices);

        int[] span = CalculateSpan(prices);

        Console.WriteLine("Stock Span:");
        Display(span);
    }
}
