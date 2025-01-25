using System;

class LargestAndSecondLargestMod
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int maxDigits = 10; // Initial size of the array
        int[] digits = new int[maxDigits];
        int index = 0;

        // Extract digits and dynamically increase array size if needed
        while (number != 0)
        {
            if (index == maxDigits)
            {
                // Increase the size of the array by 10
                maxDigits += 10;
                int[] temp = new int[maxDigits];
                for (int i = 0; i < index; i++)
                {
                    temp[i] = digits[i];
                }
                digits = temp; // Assign the larger array
            }

            digits[index] = number % 10; // Add digit to the array
            number /= 10;                // Remove the last digit
            index++;                     // Increment index
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
                largest = digits[i];     // Update largest
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
