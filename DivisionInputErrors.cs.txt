using System;

class DivisionInputErrors
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the first number: ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            int b = int.Parse(Console.ReadLine());

            int result = a/b;
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            Console.WriteLine("Exception message: " + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
            Console.WriteLine("Exception message: " + ex.Message);
        }
    }
}