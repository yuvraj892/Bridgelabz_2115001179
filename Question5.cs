using System;

class Question5
{
    static void Main(string[] args)
    {
        Console.WriteLine("radius of the cylinder:");
        double radius = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("height of the cylinder:");
        double height = Convert.ToDouble(Console.ReadLine());

        double volume = Math.PI * Math.Pow(radius, 2) * height;
        Console.WriteLine("The volume is: " + volume);
    }
}
