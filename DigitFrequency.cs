using System;

class DigitFrequency
{
    static void Main(string[] args)
    {
        // Input number from the user
        Console.Write("Enter a number: ");
        long number = long.Parse(Console.ReadLine());

        // Create an array to store the frequency of digits (0-9)
        int[] frequency = new int[10];

        // Process each digit of the number
        while (number != 0)
        {
            int digit = (int)(number % 10); // Extract the last digit
            frequency[digit]++; // Increment the frequency of the digit
            number /= 10; // Remove the last digit
        }

        // Display the frequency of each digit
        Console.WriteLine("Digit\tFrequency");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i] > 0) // Display only digits that occur in the number
            {
                Console.WriteLine($"{i}\t{frequency[i]}");
            }
        }
    }
}
