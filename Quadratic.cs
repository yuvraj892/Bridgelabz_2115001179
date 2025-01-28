using System;
class Quadratic
{
    // Method to find the roots of equation
    public static void FindRoots(double a, double b, double c)
    {
        // Calculate delta 
        double delta = Math.Pow(b, 2) - 4 * a * c;
        // Check if delta is positive, zero, or negative
        if (delta > 0)
        {
            // Two real and distinct roots
            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"The roots are: {root1} and {root2}");
        }
        else if (delta == 0)
        {
            // One real root
            double root = -b / (2 * a);
            Console.WriteLine($"The root is: {root}");
        }
        else
        {
            // No real roots (delta is negative)
            Console.WriteLine("No real roots");
        }
    }
    static void Main()
    {
        // Input the coefficients
        Console.Write("Enter coefficient a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter coefficient b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter coefficient c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        // Call the method to find the roots
        FindRoots(a, b, c);
    }
}
