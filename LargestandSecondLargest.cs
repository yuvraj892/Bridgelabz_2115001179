using System;

class LargestAndSecondLargest
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        const int maxDigits = 10; // Max size of the array
        int[] digits = new int[maxDigits];
        int index = 0;
        // Extract digits and store them in the array
        while (number != 0 && index < maxDigits)
        {
            digits[index] = number % 10;
            number /= 10;
            index++;
        }
        if (index == 0)
        {
            Console.WriteLine("No digits to process.");
            return;
        }
        // Initialize variables to find largest and second largest
        int largest = int.MinValue;
        int secondLargest = int.MinValue;
        // Find largest and second-largest digits
        for (int i = 0; i < index; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest; // Update second largest
                largest = digits[i];    // Update largest
            }
            else if (digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i];
            }
        }
        // Display results
        Console.WriteLine("The digits of the number are:");
        for (int i = 0; i < index; i++)
        {
            Console.Write(digits[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine($"Largest digit: {largest}");
        Console.WriteLine($"Second largest digit: {(secondLargest == int.MinValue ? "Not available" : secondLargest.ToString())}");
    }
}
