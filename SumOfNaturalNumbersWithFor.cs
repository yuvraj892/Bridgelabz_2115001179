using System;
class SumOfNaturalNumbersWithFor
{
    static void Main()
    {
        // input a number
        Console.Write("Enter a positive integer: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // checking input is a natural number
        if (n <= 0)
        {
            Console.WriteLine("The number is not a natural number.");
            return;
        }
        int sum = 0; 
        // Usng a for loop to calculate the sum
        for (int i = 1; i <= n; i++)
        {
            sum += i; // Adding the current number to the sum
        }
        // Calculating the sum using the formula
        int formulaSum = n * (n + 1) / 2;
        Console.WriteLine("Sum using for loop: " + sum);
        Console.WriteLine("Sum using formula: " + formulaSum);
    }
}
