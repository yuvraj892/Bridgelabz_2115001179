using System;

class Fizzbuzz3
{
    static void Main()
    {
        // Get user input for the number
        Console.Write("Enter a positive integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check if the number is positive
        if (number <= 0)
        {
            Console.WriteLine("Please enter a positive integer.");
            return;
        }

        // Create a string array to store the results
        string[] results = new string[number + 1];

        // Loop from 0 to the entered number
        for (int i = 0; i <= number; i++)
        {
            // Check for multiples of both 3 and 5
            if (i % 3 == 0 && i % 5 == 0)
            {
                results[i] = "FizzBuzz";
            }
            // Check for multiples of 3
            else if (i % 3 == 0)
            {
                results[i] = "Fizz";
            }
            // Check for multiples of 5
            else if (i % 5 == 0)
            {
                results[i] = "Buzz";
            }
            else
            {
                // Save the number itself if not a multiple of 3 or 5
                results[i] = i.ToString();
            }
        }

        // Display the results from the array
        Console.WriteLine("\nFizzBuzz Results:");
        for (int i = 0; i <= number; i++)
        {
            Console.WriteLine($"Position {i} = {results[i]}");
        }
    }
}
