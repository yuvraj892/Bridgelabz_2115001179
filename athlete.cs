using System;
class athleteProblem
{
    static void Main()
    {
        Console.Write("Enter the first side of the triangle (in meters): ");
        double side1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the second side of the triangle (in meters): ");
        double side2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the third side of the triangle (in meters): ");
        double side3 = Convert.ToDouble(Console.ReadLine());
        double perimeter = side1 + side2 + side3;
        double totalDistance = 5000;
        double rounds = totalDistance / perimeter;
        Console.WriteLine("The athlete needs to complete"+rounds+"rounds to run 5 kilometers.");
    }
}
