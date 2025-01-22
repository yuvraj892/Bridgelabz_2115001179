using System;
class Program
{
    static void Main()
    {
        int fee = 125000;
        int discountPercent = 10;
        int discount = (fee * discountPercent) / 100;
        int discountedFee = fee - discount;
        Console.WriteLine("The discount amount is INR " + discount+ "final discounted fee is INR " + discountedFee);
    }
}