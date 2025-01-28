using System;

public class Handshake
{
    // Method to calculate the maximum number of handshakes
    public static int CalculateHandshakes(int n)
    {
        if (n < 2)
        {
            return 0; // No handshakes possible if there are fewer than 2 students
        }
        return (n * (n - 1)) / 2; // Combination formula
    }

    public static void Main()
    {
        try
        {
            // Input the number of students
            Console.Write("Enter the number of students: ");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());
            // Validate input
            if (numberOfStudents < 0)
            {
                Console.WriteLine("The number of students cannot be negative.");
                return;
            }
            int maxHandshakes = CalculateHandshakes(numberOfStudents);
			Console.WriteLine($"\nThe maximum number of handshakes among {numberOfStudents} students is: {maxHandshakes}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for the number of students.");
        }
    }
}
