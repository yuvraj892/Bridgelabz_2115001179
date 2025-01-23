using System;
class SumtillZero
{
    static void Main()
    {
        double total = 0; // Initializing the total sum variable
        double userInput; // Variable to hold user input
        // Prompting the user to input numbers
        Console.WriteLine("Enter numbers to sum (0 to stop):");
        // Using a while loop to sum the numbers until 0 is entered
        while (true)
        {
            userInput = Convert.ToDouble(Console.ReadLine()); // Reading user input
            if (userInput == 0)
            {
                break; // Exiting the loop if input is 0
            }
            total += userInput;
        }
        Console.WriteLine("The total sum is: " + total);
    }
}