using System;
class Question8
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the base:");
            double baseNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the exponent:");
            double exponent = Convert.ToDouble(Console.ReadLine());

            double result = Math.Pow(baseNumber, exponent);
            Console.WriteLine($"The result of {baseNumber} raised to the power of {exponent} is: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter numeric values.");
        }
    }
}