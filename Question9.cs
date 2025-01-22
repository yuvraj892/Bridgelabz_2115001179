using System;
class Question9
{
    static void Main(string[] args)
    {
        Console.WriteLine("first number:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("second number:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("third number:");
        double num3 = Convert.ToDouble(Console.ReadLine());

        double average = (num1 + num2 + num3) / 3;
        Console.WriteLine("The average is: " + average);
    }
}
