using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 3, 7, 1, -4, 9, -2, 5 };

        int firstNegative = FindFirstNegative(numbers);

        if (firstNegative != int.MaxValue)
            Console.WriteLine("First negative number: " + firstNegative);
        else
            Console.WriteLine("No negative numbers found.");
    }

    static int FindFirstNegative(int[] arr)
    {
        foreach (int num in arr)
        {
            if (num < 0)
                return num;
        }
        return int.MaxValue; 
    }
}
