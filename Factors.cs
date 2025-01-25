using System;

class Factors
{
    static void Main()
    {
        // Get user input for the number
        Console.Write("Enter a number to find its factors: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Initialize maxFactor to 10 and create an array for storing factors
        int maxFactor = 10;
        int[] factors = new int[maxFactor];
        int index = 0;

        // Loop to find factors of the number
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0) // If i is a factor
            {
                if (index == maxFactor) // If the array is full, resize it
                {
                    maxFactor *= 2; // Double the size of the array
                    int[] temp = new int[maxFactor]; // Temporary array to store the factors
                    Array.Copy(factors, temp, factors.Length); // Copy existing factors to temp
                    factors = temp; // Assign the temp array back to factors
                }

                factors[index] = i; // Store the factor
                index++; // Increment the index
            }
        }

        // Display the factors
        Console.WriteLine("\nFactors of " + number + ":");
        for (int i = 0; i < index; i++)
        {
            Console.Write(factors[i] + " ");
        }
    }
}
