using System;
class UnitConverter3
{
    // Convert Fahrenheit to Celsius
    public static double ConvertFahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;
    // Convert Celsius to Fahrenheit
    public static double ConvertCelsiusToFahrenheit(double celsius) => (celsius * 9 / 5) + 32;
    // Convert pounds to kilograms
    public static double ConvertPoundsToKilograms(double pounds) => pounds * 0.453592;
    // Convert kilograms to pounds
    public static double ConvertKilogramsToPounds(double kilograms) => kilograms * 2.20462;
    // Convert gallons to liters
    public static double ConvertGallonsToLiters(double gallons) => gallons * 3.78541;
    // Convert liters to gallons
    public static double ConvertLitersToGallons(double liters) => liters * 0.264172;
    static void Main()
    {
        Console.WriteLine("Conversions:");
        Console.WriteLine($"100°F to Celsius: {ConvertFahrenheitToCelsius(100)}°C");
        Console.WriteLine($"37°C to Fahrenheit: {ConvertCelsiusToFahrenheit(37)}°F");
        Console.WriteLine($"150 pounds to kilograms: {ConvertPoundsToKilograms(150)} kg");
        Console.WriteLine($"50 kilograms to pounds: {ConvertKilogramsToPounds(50)} lbs");
        Console.WriteLine($"5 gallons to liters: {ConvertGallonsToLiters(5)} L");
        Console.WriteLine($"20 liters to gallons: {ConvertLitersToGallons(20)} gal");
    }
}
