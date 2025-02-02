using System;
class Employee
{
    // Public: Can be accessed from anywhere
    public string employeeID;

    // Protected: Can be accessed within this class and by subclasses
    protected string department;

    // Private: Can only be accessed inside this class
    private double salary;

    // Constructor to initialize employee details
    public Employee(string employeeID, string department, double salary)
    {
        this.employeeID = employeeID;
        this.department = department;
        this.salary = salary;
    }

    // Public method to get salary
    public double GetSalary()
    {
        return salary;
    }

    // Public method to modify salary
    public void ModifySalary(double newSalary)
    {
        if (newSalary > 0)
        {
            salary = newSalary;
            Console.WriteLine($"Salary updated to: ${salary}");
        }
        else
        {
            Console.WriteLine("Invalid salary amount!");
        }
    }

    // Method to display employee details
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("Employee ID: " + employeeID);
        Console.WriteLine("Department: " + department);
        Console.WriteLine("Salary: $" + salary);
    }
}

// Subclass demonstrating protected and public access
class Manager : Employee
{
    private string role;

    // Constructor
    public Manager(string employeeID, string department, double salary, string role)
        : base(employeeID, department, salary)  // Calling base class constructor
    {
        this.role = role;
    }

    // Method to display manager details
    public void DisplayManagerDetails()
    {
        Console.WriteLine("Employee ID: " + employeeID);  // Accessing public member
        Console.WriteLine("Department: " + department);  // Accessing protected member
        Console.WriteLine("Role: " + role);
    }
}

class main
{
    static void Main()
    {
        // Creating an Employee object
        Employee employee1 = new Employee("2115001179", "IT", 5000);
        Console.WriteLine("Employee Details:");
        employee1.DisplayEmployeeDetails();

        // Modifying salary using public method
        employee1.ModifySalary(6000);

        // Creating a Manager object
        Manager manager1 = new Manager("2115000786", "HR", 8000, "Team Leader");
        Console.WriteLine("\nManager Details:");
        manager1.DisplayManagerDetails();
    }
}
