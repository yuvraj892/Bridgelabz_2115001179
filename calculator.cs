using System;
class Calculator
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the second number: ");
        double b = Convert.ToDouble(Console.ReadLine());
        double addition = a + b;
        double subtraction = a - b;
        double multiplication = a *b;
        double division =a / b;
        Console.WriteLine("The addition, subtraction, multiplication, and division of " + a + " and " + b + " are:");
        Console.WriteLine("Addition: " + addition);
        Console.WriteLine("Subtraction: " + subtraction);
        Console.WriteLine("Multiplication: " + multiplication);
        Console.WriteLine("Division: " + division.ToString());
    }
}