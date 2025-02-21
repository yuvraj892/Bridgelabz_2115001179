using System;

class InterestCalculation
{
    public static double CalculateInterest(double amount, double rate, int years)
    {
        if(amount < 0 || rate < 0)
        {
            throw new ArgumentException("Invalid input: Amount and rate must be positive.");
        }
        double SimpleInterest = (amount * rate * years) / 100;

        return SimpleInterest;
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter principal amount:");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter annual interest rate (in %):");
            double rate = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of years:");
            int years = int.Parse(Console.ReadLine());

            
            double interest = CalculateInterest(amount, rate, years);
            
            Console.WriteLine("Calculated Interest: " + interest);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input: Please enter numbers only.");
        }
    }
}