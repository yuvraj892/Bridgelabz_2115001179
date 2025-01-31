using System;
class Employee
{
    // Attributes
    public string Name { get; set; }
    public int Id { get; set; }
    public double Salary { get; set; }

    // Method to display details
    public void DisplayDetails()
    {
        Console.WriteLine("Employee Details:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Salary: {Salary:C}"); // Formats salary as currency
    }
}

class employeeDetails
{
    static void Main()
    {
        // Create an object of the Employee class
        Employee emp = new Employee();
        Console.WriteLine("Enter Employee Name:");
        emp.Name = Console.ReadLine();
        Console.WriteLine("Enter Employee ID:");
        emp.Id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Employee Salary:");
        emp.Salary = double.Parse(Console.ReadLine());
        emp.DisplayDetails();
    }
}
