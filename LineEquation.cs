using System;
class LineEquation
{
    // Method to calculate Euclidean distance
    static double CalculateDistance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
    // Method to find the equation of the line (slope and y-intercept)
    static double[] FindLineEquation(double x1, double y1, double x2, double y2)
    {
        double m, b;
        if (x1 == x2)  // Vertical line (undefined slope)
        {
            Console.WriteLine("The line is vertical, equation: x = " + x1);
            return new double[] { double.NaN, double.NaN }; // No slope, no y-intercept
        }
        m = (y2 - y1) / (x2 - x1);  // Calculate slope
        b = y1 - (m * x1);          // Calculate y-intercept
        return new double[] { m, b };
    }
    // Main method
    static void Main()
    {
        // User inputs for two points
        Console.Write("Enter x1: ");
        double x1 = double.Parse(Console.ReadLine());
        Console.Write("Enter y1: ");
        double y1 = double.Parse(Console.ReadLine());
        Console.Write("Enter x2: ");
        double x2 = double.Parse(Console.ReadLine());
        Console.Write("Enter y2: ");
        double y2 = double.Parse(Console.ReadLine());
        // Compute Euclidean distance
        double distance = CalculateDistance(x1, y1, x2, y2);
        Console.WriteLine($"\nEuclidean Distance: {distance:F2}");
        // Compute Line Equation
        double[] lineEquation = FindLineEquation(x1, y1, x2, y2);
        if (!double.IsNaN(lineEquation[0]))  // If not a vertical line
        {
            Console.WriteLine($"Equation of the Line: y = {lineEquation[0]:F2}x + {lineEquation[1]:F2}");
        }
    }
}
