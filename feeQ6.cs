using System;
class Program
{
    static void Main()
    {   Console.Write("Enter the university fee: ");
        int fee = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the discount provided: ");
        int discountPercent = Convert.ToInt32(Console.ReadLine());
        int discount = (fee * discountPercent) / 100;
        int discountedFee = fee - discount;
        Console.WriteLine("The discount amount is INR " + discount+ "final discounted fee is INR " + discountedFee);
    }
}