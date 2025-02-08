// Derived class representing a Manager
class Manager : Employee
{
    // Additional attribute for Manager
    public int TeamSize { get; private set; }

    // Constructor to initialize Manager using the base class constructor
    public Manager(string name, int id, double salary, int teamSize) : base(name, id, salary)
    {
        TeamSize = teamSize;
    }
    // Overriding DisplayDetails method to provide specific details
    public override void DisplayDetails()
    {
        Console.WriteLine($"Manager Name: {Name}, ID: {Id}, Salary: {Salary}, Team Size: {TeamSize}");
    }
}

