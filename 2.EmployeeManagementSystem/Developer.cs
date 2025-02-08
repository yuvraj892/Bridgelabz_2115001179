// Derived class representing a Developer
class Developer : Employee
{
    // Additional attribute for Developer
    public string ProgrammingLanguage { get; private set; }
    // Constructor to initialize Developer using the base class constructor
    public Developer(string name, int id, double salary, string programmingLanguage) : base(name, id, salary)
    {
        ProgrammingLanguage = programmingLanguage;
    }
    // Overriding DisplayDetails method to provide specific details
    public override void DisplayDetails()
    {
        Console.WriteLine($"Developer Name: {Name}, ID: {Id}, Salary: {Salary}, Programming Language: {ProgrammingLanguage}");
    }
}