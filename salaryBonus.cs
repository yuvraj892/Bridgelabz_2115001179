using System;
class salaryBonus
{
    static void Main()
    {
        Console.Write("salary INR: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("bonus INR: ");
        double bonus = Convert.ToDouble(Console.ReadLine());
        double totalIncome = salary + bonus;
        Console.WriteLine("The salary is INR"+ salary+" and bonus is INR"+ bonus+". Hence Total Income is INR "+totalIncome);
    }
}
