using System;
class CollinearityCheck
{
    // Method to check collinearity using the slope formula
    static bool ArePointsCollinearBySlope(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        // Calculate slopes
        double slopeAB = (y2 - y1) / (x2 - x1);
        double slopeBC = (y3 - y2) / (x3 - x2);
        double slopeAC = (y3 - y1) / (x3 - x1);
        return (slopeAB == slopeBC) && (slopeBC == slopeAC);
    }
    // Method to check collinearity using the area of a triangle formula
    static bool ArePointsCollinearByArea(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        double area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
        return area == 0;
    }
    // Main method
    static void Main()
    {
        // User input for three points
        Console.Write("Enter x1: ");
        double x1 = double.Parse(Console.ReadLine());
        Console.Write("Enter y1: ");
        double y1 = double.Parse(Console.ReadLine());
        Console.Write("Enter x2: ");
        double x2 = double.Parse(Console.ReadLine());
        Console.Write("Enter y2: ");
        double y2 = double.Parse(Console.ReadLine());
        Console.Write("Enter x3: ");
        double x3 = double.Parse(Console.ReadLine());
        Console.Write("Enter y3: ");
        double y3 = double.Parse(Console.ReadLine());
        // Check collinearity
        bool collinearBySlope = ArePointsCollinearBySlope(x1, y1, x2, y2, x3, y3);
        bool collinearByArea = ArePointsCollinearByArea(x1, y1, x2, y2, x3, y3);
        if (collinearBySlope && collinearByArea)
        {
            Console.WriteLine("\nThe given points are collinear.");
        }
        else
        {
            Console.WriteLine("\nThe given points are NOT collinear.");
        }
    }
}
