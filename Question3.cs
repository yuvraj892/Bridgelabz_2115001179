using System;

class Question3
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the temperature in C:");
        double c = Convert.ToDouble(Console.ReadLine());

        double f = (c*9/5) +32;
        Console.WriteLine("The temperature in F is: " + f);
    }
}
