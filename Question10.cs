using System;
class Question10
{
    static void Main(string[] args)
    {
        Console.WriteLine("distance in km:");
        double kilometers = Convert.ToDouble(Console.ReadLine());

        double miles = kilometers * 0.621371;
        Console.WriteLine("The distance in miles is: " + miles);
    }
}