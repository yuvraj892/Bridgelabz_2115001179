using System;
class EmployeeBonus
{
    static Random rand = new Random();
    // Method to generate random salary (5-digit) and years of service
    static int[,] GenerateEmployeeData(int numEmployees)
    {
        int[,] employeeData = new int[numEmployees, 2];
        for (int i = 0; i < numEmployees; i++)
        {
            employeeData[i, 0] = rand.Next(10000, 99999); // Random 5-digit salary
            employeeData[i, 1] = rand.Next(1, 11);
        }
        return employeeData;
    }
    static double[,] CalculateNewSalaries(int[,] employeeData)
    {
        int numEmployees = employeeData.GetLength(0);
        double[,] updatedData = new double[numEmployees, 3]; // Old Salary, Bonus, New Salary
        for (int i = 0; i < numEmployees; i++)
        {
            int oldSalary = employeeData[i, 0];
            int yearsOfService = employeeData[i, 1];
            double bonusPercentage = (yearsOfService > 5) ? 0.05 : 0.02;
            double bonusAmount = oldSalary * bonusPercentage;
            double newSalary = oldSalary + bonusAmount;
            updatedData[i, 0] = oldSalary;
            updatedData[i, 1] = bonusAmount;
            updatedData[i, 2] = newSalary;
        }
        return updatedData;
    }
    // Method to compute total bonus payout and display all data in a table
    static void DisplayResults(int[,] employeeData, double[,] updatedData)
    {
        double totalOldSalary = 0, totalNewSalary = 0, totalBonus = 0;
        Console.WriteLine("Emp No | Old Salary | Years of Service | Bonus Amount | New Salary ");

        for (int i = 0; i < employeeData.GetLength(0); i++)
        {
            int oldSalary = employeeData[i, 0];
            int yearsOfService = employeeData[i, 1];
            double bonusAmount = updatedData[i, 1];
            double newSalary = updatedData[i, 2];
            totalOldSalary += oldSalary;
            totalNewSalary += newSalary;
            totalBonus += bonusAmount;
            Console.WriteLine($"{i + 1,6} | {oldSalary,10:C} | {yearsOfService,15} | {bonusAmount,12:C} | {newSalary,10:C}");
        }
        Console.WriteLine($"Total  | {totalOldSalary,10:C} |                 | {totalBonus,12:C} | {totalNewSalary,10:C}");
    }
    static void Main()
    {
        int numEmployees = 10;
        // Generate random salary and years of service
        int[,] employeeData = GenerateEmployeeData(numEmployees);
        double[,] updatedData = CalculateNewSalaries(employeeData);
        DisplayResults(employeeData, updatedData);
    }
}
