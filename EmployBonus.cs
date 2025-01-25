using System;
class EmployeeBonus
{
    static void Main(string[] args)
    {
        const int employeeCount = 10;
        double[] salaries = new double[employeeCount];
        double[] yearsOfService = new double[employeeCount];
        double[] bonuses = new double[employeeCount];
        double[] newSalaries = new double[employeeCount];

        double totalBonus = 0;
        double totalOldSalary = 0;
        double totalNewSalary = 0;
        // Input loop for salaries and years of service
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"Enter details for Employee {i + 1}:");
            // Input salary
            while (true)
            {
                Console.Write("Enter Salary: ");
                if (double.TryParse(Console.ReadLine(), out double salary) && salary > 0)
                {
                    salaries[i] = salary;
                    totalOldSalary += salary;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid salary. Please enter a positive number.");
                }
            }
            // Input years of service
            while (true)
            {
                Console.Write("Enter Years of Service: ");
                if (double.TryParse(Console.ReadLine(), out double years) && years >= 0)
                {
                    yearsOfService[i] = years;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid years of service. Please enter a non-negative number.");
                }
            }
        }
        // Calculation loop
        for (int i = 0; i < employeeCount; i++)
        {
            double bonusPercentage = yearsOfService[i] > 5 ? 0.05 : 0.02;
            bonuses[i] = salaries[i] * bonusPercentage;
            newSalaries[i] = salaries[i] + bonuses[i];

            totalBonus += bonuses[i];
            totalNewSalary += newSalaries[i];
        }
        // Display results
        Console.WriteLine("\nEmployee Details:");
        Console.WriteLine("Employee\tOld Salary\tYears of Service\tBonus\tNew Salary");
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"{i + 1}\t\t{salaries[i]:F2}\t\t{yearsOfService[i]:F2}\t\t\t{bonuses[i]:F2}\t{newSalaries[i]:F2}");
        }
        Console.WriteLine($"\nTotal Old Salary: {totalOldSalary:F2}");
        Console.WriteLine($"Total Bonus Payout: {totalBonus:F2}");
        Console.WriteLine($"Total New Salary: {totalNewSalary:F2}");
    }
}
