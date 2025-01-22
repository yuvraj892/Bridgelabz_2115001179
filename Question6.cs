using System;
class Question6
{
    static void Main(string[] args)
    {
        Console.WriteLine("Principal amount:");
        double principal = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Rate of interest (in %):");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Time in years:");
        double time = Convert.ToDouble(Console.ReadLine());

        double simpleInterest = (principal * rate * time) / 100;
        Console.WriteLine("Simple Interest is: " + simpleInterest);
    }
}
