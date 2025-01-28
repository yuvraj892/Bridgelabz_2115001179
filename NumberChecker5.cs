using System;
class NumberChecker5
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int[] factors = FindFactors(number);
        Console.WriteLine($"Factors of {number}: {string.Join(", ", factors)}");
        int greatestFactor = FindGreatestFactor(factors);
        Console.WriteLine($"Greatest factor of {number}: {greatestFactor}");
        int sumOfFactors = FindSumOfFactors(factors);
        Console.WriteLine($"Sum of factors of {number}: {sumOfFactors}");
        long productOfFactors = FindProductOfFactors(factors);
        Console.WriteLine($"Product of factors of {number}: {productOfFactors}");
        long productOfCubes = FindProductOfCubesOfFactors(factors);
        Console.WriteLine($"Product of cubes of factors of {number}: {productOfCubes}");
        bool isPerfect = IsPerfectNumber(number);
        Console.WriteLine($"Is {number} a perfect number? {isPerfect}");
        bool isAbundant = IsAbundantNumber(number);
        Console.WriteLine($"Is {number} an abundant number? {isAbundant}");
        bool isDeficient = IsDeficientNumber(number);
        Console.WriteLine($"Is {number} a deficient number? {isDeficient}");
        bool isStrong = IsStrongNumber(number);
        Console.WriteLine($"Is {number} a strong number? {isStrong}");
    }
    public static int[] FindFactors(int number)
    {
        int count = 0;
        for (int i = 1; i <= number; i++)
            if (number % i == 0)
                count++;
        int[] factors = new int[count];
        int index = 0;
        for (int i = 1; i <= number; i++)
            if (number % i == 0)
                factors[index++] = i;
        return factors;
    }
    public static int FindGreatestFactor(int[] factors)
    {
        int max = factors[0];
        foreach (int factor in factors)
        {
            if (factor > max)
                max = factor;
        }
        return max;
    }
    public static int FindSumOfFactors(int[] factors)
    {
        int sum = 0;
        foreach (int factor in factors)
        {
            sum += factor;
        }
        return sum;
    }
    public static long FindProductOfFactors(int[] factors)
    {
        long product = 1;
        foreach (int factor in factors)
        {
            product *= factor;
        }
        return product;
    }
    public static long FindProductOfCubesOfFactors(int[] factors)
    {
        long product = 1;
        foreach (int factor in factors)
        {
            product *= (long)Math.Pow(factor, 3);
        }
        return product;
    }
    public static bool IsPerfectNumber(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
                sum += i;
        }
        return sum == number;
    }
    public static bool IsAbundantNumber(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
                sum += i;
        }
        return sum > number;
    }
    public static bool IsDeficientNumber(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
                sum += i;
        }
        return sum < number;
    }
    public static bool IsStrongNumber(int number)
    {
        int sum = 0, temp = number;
        while (temp > 0)
        {
            int digit = temp % 10;
            sum += Factorial(digit);
            temp /= 10;
        }
        return sum == number;
    }
    public static int Factorial(int num)
    {
        if (num == 0 || num == 1) return 1;
        int fact = 1;
        for (int i = 2; i <= num; i++)
        {
            fact *= i;
        }
        return fact;
    }
}
