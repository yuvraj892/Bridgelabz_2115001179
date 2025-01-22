using System;

class Question4
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the radius:");
        double rad = Convert.ToDouble(Console.ReadLine());

        double area = Math.PI * Math.Pow(rad, 2);
        Console.WriteLine("The area of the circle is: " + area);
    }
}
