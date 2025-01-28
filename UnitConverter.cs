using System;
class UnitConverter
{
    private static double km2miles = 0.621371;
    private static double miles2km = 1.60934;
    private static double meters2feet = 3.28084;
    private static double feet2meters = 0.3048;
    // Convert kilometers to miles
    public static double ConvertKmToMiles(double km) => km * km2miles;
    // Convert miles to kilometers
    public static double ConvertMilesToKm(double miles) => miles * miles2km;
    // Convert meters to feet
    public static double ConvertMetersToFeet(double meters) => meters * meters2feet;
    // Convert feet to meters
    public static double ConvertFeetToMeters(double feet) => feet * feet2meters;
    static void Main()
    {
        Console.WriteLine("Conversions:");
        Console.WriteLine($"10 km to miles: {ConvertKmToMiles(10)} miles");
        Console.WriteLine($"10 miles to km: {ConvertMilesToKm(10)} km");
        Console.WriteLine($"10 meters to feet: {ConvertMetersToFeet(10)} feet");
        Console.WriteLine($"10 feet to meters: {ConvertFeetToMeters(10)} meters");
    }
}
