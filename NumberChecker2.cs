using System;
class NumberChecker2
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int digitCount = CountDigits(number);
        Console.WriteLine($"Count of digits: {digitCount}");
        int[] digits = GetDigitsArray(number);
        Console.WriteLine("Digits in the number: " + string.Join(", ", digits));
        int sumOfDigits = FindSumOfDigits(digits);
        Console.WriteLine($"Sum of digits: {sumOfDigits}");
        int sumOfSquares = FindSumOfSquaresOfDigits(digits);
        Console.WriteLine($"Sum of squares of digits: {sumOfSquares}");
        bool isHarshad = IsHarshadNumber(number, sumOfDigits);
        Console.WriteLine($"Is Harshad Number: {isHarshad}");
        int[,] frequency = FindDigitFrequency(digits);
        Console.WriteLine("Digit frequencies:");
        for (int i = 0; i < frequency.GetLength(0); i++)
        {
            if (frequency[i, 1] > 0)
            {
                Console.WriteLine($"Digit {frequency[i, 0]}: {frequency[i, 1]} times");
            }
        }
    }
    // Method to count digits in the number
    public static int CountDigits(int number)
    {
        return number.ToString().Length;
    }
    // Metod to store digits in an array
    public static int[] GetDigitsArray(int number)
    {
        string numberStr = number.ToString();
        int[] digits = new int[numberStr.Length];
        for (int i = 0; i < numberStr.Length; i++)
        {
            digits[i] = numberStr[i] - '0'; // Convert char to int
        }
        return digits;
    }
    // Method to find the sum of the digits
    public static int FindSumOfDigits(int[] digits)
    {
        int sum = 0;
        foreach (int digit in digits)
        {
            sum += digit;
        }
        return sum;
    }
    // Method to find the sum of the squares of the digits
    public static int FindSumOfSquaresOfDigits(int[] digits)
    {
        int sumOfSquares = 0;
        foreach (int digit in digits)
        {
            sumOfSquares += (int)Math.Pow(digit, 2);
        }
        return sumOfSquares;
    }
    public static bool IsHarshadNumber(int number, int sumOfDigits)
    {
        return number % sumOfDigits == 0;
    }
    public static int[,] FindDigitFrequency(int[] digits)
    {
        int[,] frequency = new int[10, 2]; // 2D array to store digit and its frequency
        for (int i = 0; i < 10; i++)
        {
            frequency[i, 0] = i; // First column stores the digit
            frequency[i, 1] = 0; // Second column stores the frequency
        }
        foreach (int digit in digits)
        {
            frequency[digit, 1]++; // Increment frequency for the digit
        }
        return frequency;
    }
}