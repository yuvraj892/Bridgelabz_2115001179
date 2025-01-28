using System;
public class maximumHandshakes
{
    public static void Main()
    {
        try
        {
            // Input
            Console.Write("Enter the number of students: ");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());

            // check the input
            if (numberOfStudents < 0)
            {
                Console.WriteLine("The number of students cannot be negative.");
                return;
            }
            // maximum number of handshakes
            int maxHandshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;

            // for output
            Console.WriteLine($"The maximum number of handshakes among {numberOfStudents} students is: {maxHandshakes}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}
