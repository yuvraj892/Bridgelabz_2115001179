using System;
class CalculateBonus
{
    static void Main(string[] args)
    {
        Console.Write("Enter the employee's salary: ");
        double salary = double.Parse(Console.ReadLine());

        Console.Write("Enter the employee's years of service: ");
        int yearsOfService = int.Parse(Console.ReadLine());

        // Check if the employee qualifies for the bonus
        if (yearsOfService > 5)
        {
            double bonus = salary * 0.05; // Calculate 5% of the salary
            Console.WriteLine("The bonus amount is: "+bonus);
        }
        else
        {
            Console.WriteLine("No bonus is awarded as the years of service are 5 or less.");
        }
    }
}
