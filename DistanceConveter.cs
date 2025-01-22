using System;

class DistanceConverter
{
    static void Main()
    {
        Console.Write("Please enter the distance in kilometers: ");
        double kilometers = Convert.ToDouble(Console.ReadLine());

        double conversionFactor = 1.6;
        double miles = kilometers / conversionFactor;

        Console.WriteLine("The total distance is " +miles + "miles for the given "+kilometers+" kilometers.");
    }
}ḍ