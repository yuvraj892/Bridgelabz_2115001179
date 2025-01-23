using System;
class HarshadNumber
{
    static void Main(string[] args)
    {
        // Step 1: Get the input number
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Step 2: Initialize variables
        int sum = 0;
        int originalNumber = number;

        // Step 3: Calculate the sum of digits
        while (originalNumber != 0)
        {
            int digit = originalNumber % 10; // Extract the last digit
            sum += digit; // Add the digit to the sum
            originalNumber /= 10; // Remove the last digit
        }

        // Step 4: Check if the number is divisible by the sum of its digits
        if (number % sum == 0)
        {
            Console.WriteLine($"{number} is a Harshad Number.");
        }
        else
        {
            Console.WriteLine($"{number} is not a Harshad Number.");
        }
    }
}
