using System;

class multiplicationResult
{
    static void Main()
    {
        Console.Write("Enter a number between 6 and 9 to get its multiplication table: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check if the number is between 6 and 9
        if (number < 6 || number > 9)
        {
            Console.WriteLine("Please enter a number between 6 and 9.");
            return;
        }

        // Array to store multiplication results
        int[] multiplicationResult = new int[10];

        // Loop to generate multiplication table for the entered number
        for (int i = 1; i <= 10; i++)
        {
            multiplicationResult[i - 1] = number * i;
        }

        // Display the multiplication table from the array
        Console.WriteLine("\nMultiplication table of " + number + ":");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(number + " * " + i + " = " + multiplicationResult[i - 1]);
        }
    }
}
