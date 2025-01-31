using System;

class Factorial
{
    static void Main()
    {//input
        int number = GetInput();
        long factorial = calFactorial(number);
        DisplayResult(factorial);
    }
    static int GetInput()
    {
        Console.WriteLine("Enter a number to calculate its factorial:");
        return int.Parse(Console.ReadLine());
    }
    static long calFactorial(int n)
    {
        // Base case: factorial of 0 or 1 is 1
        if (n <= 1)
        {
            return 1;
        }
        // Recursive case: n * factorial of (n-1)
        return n * calFactorial(n - 1);
    }
    static void DisplayResult(long result)
    {
        Console.WriteLine($"The factorial is: "+result);
    }
}
