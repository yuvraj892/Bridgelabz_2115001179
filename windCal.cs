using System;
class WindCal {
    static void Main(string[] args) {
        // Prompt for temp input
        Console.WriteLine("Enter the temp (in Fahrenheit):");
        double temp = Convert.ToDouble(Console.ReadLine());

        // Prompt for wind speed input
        Console.WriteLine("Enter the wind speed (in mph):");
        double windSpeed = Convert.ToDouble(Console.ReadLine());
        // Calculate wind chill using the method
        double windChill = CalculateChill(temp, windSpeed);
        Console.WriteLine("The wind chill temp is: " + windChill + "°F");
    }

    public static double CalculateChill(double temp, double windSpeed) {
        // Wind chill calculation formula
        double windChill = 35.74 + 0.6215 * temp + (0.4275 * temp - 35.75) * Math.Pow(windSpeed, 0.16);
        return windChill;
    }
}
