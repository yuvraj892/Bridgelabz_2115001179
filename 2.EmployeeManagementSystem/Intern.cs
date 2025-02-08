
// Derived class representing an Intern
class Intern : Employee
{
    // Additional attribute for Intern
    public string InternshipDuration { get; private set; }
    // Constructor to initialize Intern using the base class constructor
    public Intern(string name, int id, double salary, string internshipDuration) : base(name, id, salary)
    {
        InternshipDuration = internshipDuration;
    }
    // Overriding DisplayDetails method to provide specific details
    public override void DisplayDetails()
    {
        Console.WriteLine($"Intern Name: {Name}, ID: {Id}, Salary: {Salary}, Internship Duration: {InternshipDuration}");
    }
}