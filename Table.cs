using System;

class Table
{
    static void Main()
    {
        double[] numbers = new double[10]; // Array to store up to 10 numbers
        double total = 0.0; // Variable to store the total of numbers
        int index = 0; // Index for array

        // Infinite while loop to take user input
        while (true)
        {
            Console.Write("Enter a number (0 or a negative number to stop): ");
            double userInput = Convert.ToDouble(Console.ReadLine());

            // Check if the user entered 0 or a negative number to break the loop
            if (userInput <= 0)
            {
                break;
            }

            // Check if the index is 10, meaning array is full
            if (index >= 10)
            {
                break;
            }

            // Store the input in the array and increment the index
            numbers[index] = userInput;
            index++;
        }

        // Display all entered values and calculate the total
        Console.WriteLine("\nEntered numbers:");
        for (int i = 0; i < index; i++)
        {
            Console.WriteLine(numbers[i]);
            total += numbers[i]; // Add the current number to the total
        }

        // Display the total
        Console.WriteLine("\nTotal of all numbers: " + total);
    }
}
