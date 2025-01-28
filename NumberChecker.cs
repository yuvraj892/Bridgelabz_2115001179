using System;
class NumberChecker
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        // Call methods and display results
        int digitCount = CountDigits(number);
        Console.WriteLine($"Count of digits: {digitCount}");

        int[] digits = GetDigitsArray(number);
        Console.WriteLine("Digits in the number: " + string.Join(", ", digits));
        bool isDuck = IsDuckNumber(digits);
        Console.WriteLine($"Is Duck Number: {isDuck}");
        bool isArmstrong = IsArmstrongNumber(number, digits);
        Console.WriteLine($"Is Armstrong Number: {isArmstrong}");
        (int largest, int secondLargest) = FindLargestAndSecondLargest(digits);
        Console.WriteLine($"Largest digit: {largest}, Second largest digit: {secondLargest}");
        (int smallest, int secondSmallest) = FindSmallestAndSecondSmallest(digits);
        Console.WriteLine($"Smallest digit: {smallest}, Second smallest digit: {secondSmallest}");
    }
    // Method to count digits in the number
    public static int CountDigits(int number)
    {
        return number.ToString().Length;
    }
    // Method to store digits in an array
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
    // Method to check if the number is a Duck Number
    public static bool IsDuckNumber(int[] digits)
    {
        for (int i = 1; i < digits.Length; i++) // Duck number cannot start with 0
        {
            if (digits[i] == 0)
            {
                return true;
            }
        }
        return false;
    }
    // Method to check if the number is an Armstrong Number
    public static bool IsArmstrongNumber(int number, int[] digits)
    {
        int power = digits.Length;
        int sum = 0;
        foreach (int digit in digits)
        {
            sum += (int)Math.Pow(digit, power);
        }
        return sum == number;
    }
    // Method to find the largest and second largest digits
    public static (int, int) FindLargestAndSecondLargest(int[] digits)
    {
        int largest = Int32.MinValue;
        int secondLargest = Int32.MinValue;
        foreach (int digit in digits)
        {
            if (digit > largest)
            {
                secondLargest = largest;
                largest = digit;
            }
            else if (digit > secondLargest && digit != largest)
            {
                secondLargest = digit;
            }
        }
        return (largest, secondLargest);
    }
    // Method to find the smallest and second smallest digits
    public static (int, int) FindSmallestAndSecondSmallest(int[] digits)
    {
        int smallest = Int32.MaxValue;
        int secondSmallest = Int32.MaxValue;
        foreach (int digit in digits)
        {
            if (digit < smallest)
            {
                secondSmallest = smallest;
                smallest = digit;
            }
            else if (digit < secondSmallest && digit != smallest)
            {
                secondSmallest = digit;
            }
        }
        return (smallest, secondSmallest);
    }
}