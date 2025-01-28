using System;
class NumberChecker3
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        //Count digits and store in an array
        int digitCount = CountDigits(number);
        Console.WriteLine($"Count of digits: {digitCount}");
        int[] digits = GetDigitsArray(number);
        Console.WriteLine("Digits in the number: " + string.Join(", ", digits));
        //Reverse the digits array
        int[] reversedDigits = ReverseArray(digits);
        Console.WriteLine("Reversed digits: " + string.Join(", ", reversedDigits));
        //Compare
        bool areArraysEqual = CompareArrays(digits, reversedDigits);
        Console.WriteLine($"Are the original and reversed arrays equal? {areArraysEqual}");
        //if the number is a palindrome
        bool isPalindrome = IsPalindrome(digits, reversedDigits);
        Console.WriteLine($"Is the number a palindrome? {isPalindrome}");
        //if the number is a duck number
        bool isDuckNumber = IsDuckNumber(digits);
        Console.WriteLine($"Is the number a duck number? {isDuckNumber}");
    }
    public static int CountDigits(int number)
    {
        return number.ToString().Length;
    }
    //Method to store digits in an array
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
    //Method to reverse the digits array
    public static int[] ReverseArray(int[] array)
    {
        int[] reversed = new int[array.Length];
        for (int i = 0, j = array.Length - 1; i < array.Length; i++, j--)
        {
            reversed[i] = array[j];
        }
        return reversed;
    }
    //Method to compare two arrays
    public static bool CompareArrays(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length)
            return false;

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
                return false;
        }
        return true;
    }
    // Method to check if a number is a palindrome
    public static bool IsPalindrome(int[] digits, int[] reversedDigits)
    {
        return CompareArrays(digits, reversedDigits);
    }
    public static bool IsDuckNumber(int[] digits)
    {
        for (int i = 1; i < digits.Length; i++) // Skip the first digit
        {
            if (digits[i] == 0)
                return true;
        }
        return false;
    }
}