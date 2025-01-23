using System;
class ArmstrongNumber
{
    static void Main(string[] args)
    {
        //Get user input
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        // Initialize variables
        int sum = 0;
        int originalNumber = num;

        //Process each digit
        while (originalNumber != 0)
        {
            int remainder = originalNumber % 10; // Get the last digit
            sum += remainder * remainder * remainder; // Add the cube of the digit to the sum
            originalNumber /= 10; // Remove the last digit
        }
        //Check if the sum equals the original number
        if (sum == num)
        {
            Console.WriteLine($"{num} is an Armstrong number.");
        }
        else
        {
            Console.WriteLine($"{num} is not an Armstrong number.");
        }
    }
}
