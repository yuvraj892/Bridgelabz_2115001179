using System;

class FactorCalculator
{
    // Method to find factors and store them in an array
    static int[] FindFactors(int number)
    {
        int count = 0;

        // First loop to count factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                count++;
        }
        int[] factors = new int[count];
        int index = 0;
        // Second loop to store factors in the array
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                factors[index++] = i;
        }
        return factors;
    }
    // Method to calculate the sum of factors
    static int SumOfFactors(int[] factors)
    {
        int sum = 0;
        foreach (int factor in factors)
            sum += factor;
        return sum;
    }

    // Method to calculate the product of factors
    static long ProductOfFactors(int[] factors)
    {
        long product = 1;
        foreach (int factor in factors)
            product *= factor;
        return product;
    }

    // Method to calculate the sum of squares of factors
    static int SumOfSquaresOfFactors(int[] factors)
    {
        int sum = 0;
        foreach (int factor in factors)
            sum += (int)Math.Pow(factor, 2);
        return sum;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        // Find factors
        int[] factors = FindFactors(number);
        int sum = SumOfFactors(factors);
        long product = ProductOfFactors(factors);
        int sumOfSquares = SumOfSquaresOfFactors(factors);
        Console.WriteLine($"Factors of {number}: {string.Join(", ", factors)}");
        Console.WriteLine($"Sum of factors: {sum}");
        Console.WriteLine($"Product of factors: {product}");
        Console.WriteLine($"Sum of squares of factors: {sumOfSquares}");
    }
}
