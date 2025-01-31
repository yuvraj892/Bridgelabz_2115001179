using System;
class Circle
{
    public double Radius { get; set; }
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
    public double CalculateCircumference()
    {
        return 2 * Math.PI * Radius;
    }
    // Method to display the area and circumference
    public void DisplayDetails()
    {
        Console.WriteLine($"Radius: {Radius}");
        Console.WriteLine($"Area: {CalculateArea():F2}");
        Console.WriteLine($"Circumference: {CalculateCircumference():F2}");
    }
}
class AreaOfCircle
{
    static void Main()
    {
        // Create an object of the Circle class
        Circle circle = new Circle();
        Console.WriteLine("Enter the radius of the circle:");
        circle.Radius = double.Parse(Console.ReadLine());
        circle.DisplayDetails();
    }
}
