using System;
public class Park
{
    // creating method to cal the no of rounds
    public static int CalculateRounds(double side1, double side2, double side3, double distanceInMeters)
    {
        double perimeter = side1 + side2 + side3; // Calculate the perimeter of the triangle
        if (perimeter == 0)
        {
            Console.WriteLine("Perimeter cannot be zero. Check the inputs for triangle sides.");
            return 0;
        }
        return (int)Math.Ceiling(distanceInMeters / perimeter); // Calculate and return the number of rounds
    }
    public static void Main()
    {
        try
        {
            // User input for the sides of the triangular park
            Console.Write("Enter the length of side 1 in meters: ");
            double side1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the length of side 2 in meters: ");
            double side2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the length of side 3 in meters: ");
            double side3 = Convert.ToDouble(Console.ReadLine());
            // Validate input: check if the sides form a valid triangle
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                Console.WriteLine("Side lengths must be positive numbers.");
                return;
            }
            if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
            {
                Console.WriteLine("The given sides do not form a valid triangle.");
                return;
            }
            // Total distance to run
            double distanceInMeters = 5000;
            // Calculate the number of rounds
            int rounds = CalculateRounds(side1, side2, side3, distanceInMeters);
            Console.WriteLine("To complete a 5 km run, the athlete must complete"+rounds+" rounds.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter valid numbers.");
        }
    }
}
