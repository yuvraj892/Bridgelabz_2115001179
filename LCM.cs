using System;
class LCM
{
    static void Main()
    {
        // Take input
        Console.WriteLine("Enter two numbers:");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        // Calculate GCD and LCM
        int gcd = CalculateGCD(num1, num2);
        int lcm = CalculateLCM(num1, num2, gcd);
        Console.WriteLine("The GCD of"+num1+"and "+num2+" is: "+gcd);
        Console.WriteLine("The LCM of "+num1+" and "+num2+" is: "+lcm);
    }
    static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    //calculate LCM using GCD
    static int CalculateLCM(int a, int b, int gcd)
    {
        return Math.Abs(a*b)/gcd;
    }
}
