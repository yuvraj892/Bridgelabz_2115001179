using System;
class NaturalNumbersWithWhile
{
    static void Main()
    {
        // input a number
        Console.Write("Enter a positive integer: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("The number is not a natural number.");
            return;
        }
        int sum = 0; 
        int i = 1;
        while (i <= n)
        {
            sum += i; // Adding the current number to the sum
            i++; 
        }
        int formulaSum = n * (n + 1) / 2;
        Console.WriteLine("Sum using while loop: " + sum);
        Console.WriteLine("Sum using formula: " + formulaSum);
    }
}
