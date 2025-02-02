using System;
class Circle
{
    private double radius;
    // Default constructor 
    public Circle()
    {
        radius = 1.0;  // Manually assigning default value
    }
    // Parameterized constructor
    public Circle(double radius)
    {
        this.radius = radius;
    }
}

class Try
{
    static void Main()
    {
        Circle c1 = new Circle();  // Default constructor
        c1.showRadius();

        Console.WriteLine();

        Circle c2 = new Circle(5.5);  // Parameterized constructor
        c2.showRadius();
    }
}
