using System;

class multiplicationTable
{
    static void Main()
    {
        Console.Write("Enter a number to generate its multiplication table: ");
        int number = Convert.ToInt32(Console.ReadLine()); // Get user input for the number
        int[] multiplicationTable = new int[10]; // Array to store multiplication results

        // Loop to calculate and store multiplication results
        for (int i = 1; i <= 10; i++)
        {
            multiplicationTable[i - 1] = number * i; // Store multiplication result in array
        }

        // Display the multiplication table
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(number + " * " + i + " = " + multiplicationTable[i - 1]);
        }
    }
}
