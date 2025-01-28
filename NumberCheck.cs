using System;
public class NumberCheck
{
    // Method to check number is positive, negative, or zero
    public static int CheckNumber(int number)
    {
        if (number > 0)
            return 1; // Positive number
        else if (number < 0)
            return -1; // Negative number
        else
            return 0; // Zero
    }
    public static void Main()
    {
        try
        {
            // User input for a number
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            // Call the CheckNumber method
            int result = CheckNumber(number);
            if (result == 1)
                Console.WriteLine("The number is positive.");
            else if (result == -1)
                Console.WriteLine("The number is negative.");
            else
                Console.WriteLine("The number is zero.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}
