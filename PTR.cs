using System;
class PRT
{
    static void Main()
    {
        // Input: Principal, Rate, and Time
        Console.Write("Enter the Principal amount (INR): ");
        double principal = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the Rate of Interest (%): ");
        double rate = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the Time (in years): ");
        double time = Convert.ToDouble(Console.ReadLine());
        // Calculate Simple Interest
        double simpleInterest = (principal * rate * time) / 100;
        // Output the result
        Console.WriteLine("The Simple Interest is INR"+simpleInterest+" for Principal"+principal+", Rate of Interest "+rate+"%, and Time "+time+" years.");
    }
}
