using System;
class Calculator
{
    static void Main()
    {
        // Prompt user to choose an operation
        Console.WriteLine("Choose an operation: ");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.Write("Enter the number of the operation (1/2/3/4): ");
        int choice = int.Parse(Console.ReadLine());

        // Take two numbers as input
        Console.Write("Enter the first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double num2 = double.Parse(Console.ReadLine());

        // Perform the chosen operation
        switch (choice)
        {
            case 1:
                Add(num1, num2);
                break;
            case 2:
                Subtract(num1, num2);
                break;
            case 3:
                Multiply(num1, num2);
                break;
            case 4:
                Divide(num1, num2);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    // Function to perform addition
    static void Add(double a, double b)
    {
        double result = a + b;
        Console.WriteLine($"Result: {a} + {b} = {result}");
    }

    // Function to perform subtraction
    static void Subtract(double a, double b)
    {
        double result = a - b;
        Console.WriteLine($"Result: {a} - {b} = {result}");
    }

    // Function to perform multiplication
    static void Multiply(double a, double b)
    {
        double result = a * b;
        Console.WriteLine($"Result: {a} * {b} = {result}");
    }

    // Function to perform division
    static void Divide(double a, double b)
    {
        if (b != 0)
        {
            double result = a / b;
            Console.WriteLine($"Result: {a}/{b} = {result}");
        }
        else
        {
            Console.WriteLine("Cannot divide by zero.");
        }
    }
}
