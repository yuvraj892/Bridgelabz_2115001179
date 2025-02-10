using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Abstract class
abstract class EmployeeM
{
    protected int EmployeeId;
    protected string Name;
    protected double BaseSalary;

    public EmployeeM(int id, string name, double salary)
    {
        EmployeeId = id;
        Name = name;
        BaseSalary = salary;
    }

    public abstract double CalculateSalary();

    public void DisplayDetails()
    {
        Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Salary: {CalculateSalary()}");
    }
}

// Interface
interface IDepartment
{
    void AssignDepartment(string dept);
    string GetDepartmentDetails();
}

// Full-time Employee
class FullTimeEmployee : EmployeeM, IDepartment
{
    public FullTimeEmployee(int id, string name, double salary) : base(id, name, salary) { }

    public override double CalculateSalary() => BaseSalary;

    private string Department;
    public void AssignDepartment(string dept) => Department = dept;
    public string GetDepartmentDetails() => $"Department: {Department}";
}

// Part-time Employee
class PartTimeEmployee : EmployeeM, IDepartment
{
    private int WorkHours;
    private double HourlyRate;

    public PartTimeEmployee(int id, string name, int hours, double rate) : base(id, name, 0)
    {
        WorkHours = hours;
        HourlyRate = rate;
    }

    public override double CalculateSalary() => WorkHours * HourlyRate;

    private string Department;
    public void AssignDepartment(string dept) => Department = dept;
    public string GetDepartmentDetails() => $"Department: {Department}";
}

// Main Program
class Program
{
    static void Main()
    {
        List<EmployeeM> employees = new List<EmployeeM>
        {
            new FullTimeEmployee(1, "Alice", 5000),
            new PartTimeEmployee(2, "Bob", 40, 20)
        };

        foreach (var emp in employees)
        {
            emp.DisplayDetails();
        }
    }
}
