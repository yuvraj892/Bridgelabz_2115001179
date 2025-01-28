using System;
class WindCalculator {
    static void Main(string[] args) {
        // Input temperature
        Console.WriteLine("Enter the temp :");
        double temp = Convert.ToDouble(Console.ReadLine());
        // Input wind speed
        Console.WriteLine("give the wind speed (in mph):");
        double windSpeed = Convert.ToDouble(Console.ReadLine());
        // Calculate wind chill using the method
        double windChill = CalculateChill(temp, windSpeed);
        Console.WriteLine("The wind chill temperature is: " + windChill + "°F");
    }
    public static double CalculateChill(double temp, double windSpeed) {
        // Formula for wind chill
        double windChill = 35.74 + 0.6215 * temp + (0.4275 * temp - 35.75) * Math.Pow(windSpeed, 0.16);
        return windChill;
    }
}
