using System;
class UnitConverterreq
{
    private static double yards2feet = 3;
    private static double feet2yards = 0.333333;
    private static double meters2inches = 39.3701;
    private static double inches2meters = 0.0254;
    private static double inches2cm = 2.54;
    // Convert yards to feet
    public static double ConvertYardsToFeet(double yards) => yards * yards2feet;
    // Convert feet to yards
    public static double ConvertFeetToYards(double feet) => feet * feet2yards;
    // Convert meters to inches
    public static double ConvertMetersToInches(double meters) => meters * meters2inches;
    // Convert inches to meters
    public static double ConvertInchesToMeters(double inches) => inches * inches2meters;
    // Convert inches to centimeters
    public static double ConvertInchesToCm(double inches) => inches * inches2cm;
    static void Main()
    {
        Console.WriteLine("Conversions:");
        Console.WriteLine($"5 yards to feet: {ConvertYardsToFeet(5)} feet");
        Console.WriteLine($"10 feet to yards: {ConvertFeetToYards(10)} yards");
        Console.WriteLine($"2 meters to inches: {ConvertMetersToInches(2)} inches");
        Console.WriteLine($"20 inches to meters: {ConvertInchesToMeters(20)} meters");
        Console.WriteLine($"15 inches to cm: {ConvertInchesToCm(15)} cm");
    }
}
