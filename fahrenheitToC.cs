using System;
class fahrenheitToC
{
    static void Main()
    {
        Console.Write("Enter the temperature in Fahrenheit: ");
        double fahrenheit = Convert.ToDouble(Console.ReadLine());
        double celsiusResult = (fahrenheit - 32) * 5 / 9;
        Console.WriteLine(fahrenheit+ "Fahrenheit is"+ celsiusResult+" Celsius");
    }
}
