using System;
class volumeOfEarth
{
    static void Main()
    {
        double radiusKm = 6378;
        double volumeKm3 = (4.0 / 3.0) * Math.PI * Math.Pow(radiusKm, 3);
        double radiusMiles = radiusKm * 0.621371;
        double volumeMiles3 = (4.0 / 3.0) * Math.PI * Math.Pow(radiusMiles, 3);
        Console.WriteLine($"The volume of Earth in cubic kilometers is "+ volumeKm3+" and in cubic miles is "+ volumeMiles3);
    }
}