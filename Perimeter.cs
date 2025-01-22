using System;
class Perimeter
{
    static void Main()
    {
        // Input: Perimeter of the square
        Console.Write("perimeter of the square: ");
        double perimeter = Convert.ToDouble(Console.ReadLine());

        // Calculate the side of the square
        double side = perimeter / 4;

        // Output the result
        Console.WriteLine("The length of the side is "+ side+ "whose perimeter is "+ perimeter);
    }
}
