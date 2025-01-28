using System;
public class SimpleInterestCal
{
    // Method to calculate Simple Interest
    public static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        return (principal * rate * time) / 100;
    public static void Main()
    {
        try
        {
            // Input Principal, Rate, and Time
            Console.Write("Enter the Principal amount: ");
            double principal = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the Rate of Interest: ");
            double rate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the Time (in years): ");
            double time = Convert.ToDouble(Console.ReadLine());
            if (principal < 0 || rate < 0 || time < 0)
            {
                Console.WriteLine("Principal, Rate, and Time must be non-negative values.");
                return;
            }
            double simpleInterest = CalculateSimpleInterest(principal, rate, time);
            Console.WriteLine($"\nThe Simple Interest is {simpleInterest:F2} for Principal {principal}, Rate of Interest {rate}% and Time {time} years.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter numerical values for Principal, Rate, and Time.");
        }
    }
}
