// Base class representing a general Employee
class Employee
{
    // Properties to store name, ID, and salary of the employee
    public string Name { get; private set; }
    public int Id { get; private set; }
    public double Salary { get; private set; }
    // Constructor to initialize the employee with name, ID, and salary
    public Employee(string name, int id, double salary)
    {
        Name = name;
        Id = id;
        Salary = salary;
    }
    // Virtual method to be overridden by subclasses (provides default employee details)
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Employee Name: {Name}, ID: {Id}, Salary: {Salary}");
    }
}
