using System;
class Question7
{
    static void Main(string[] args)
    {
        Console.WriteLine("length:");
        double length = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("width:");
        double width = Convert.ToDouble(Console.ReadLine());

        double perimeter = 2 * (length + width);
        Console.WriteLine("perimeter: " + perimeter);
    }
}
