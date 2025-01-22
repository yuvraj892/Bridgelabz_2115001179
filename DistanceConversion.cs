using System;
class distanceConversion
{
    static void Main()
    {
        Console.Write("Enter the distance in feet: ");
        double distanceInFeet = Convert.ToDouble(Console.ReadLine());
        double distanceInYards = distanceInFeet / 3; 
        double distanceInMiles = distanceInYards / 1760;
        Console.WriteLine($"The distance in yards is {distanceInYards}.");
        Console.WriteLine($"The distance in miles is {distanceInMiles}.");
    }
}
