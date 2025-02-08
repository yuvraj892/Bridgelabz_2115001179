// Subclass representing a Staff member
class Staff : Person
{
    // Additional attribute for staff
    public string Position { get; private set; }

    // Constructor to initialize a staff member
    public Staff(string name, int age, string position) : base(name, age)
    {
        Position = position;
    }

    // Overriding method to display role
    public override void DisplayRole()
    {
        Console.WriteLine($"Staff - Name: {Name}, Age: {Age}, Position: {Position}");
    }
}
