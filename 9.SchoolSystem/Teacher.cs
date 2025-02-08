// Subclass representing a Teacher
class Teacher : Person
{
    // Additional attribute for teacher
    public string Subject { get; private set; }

    // Constructor to initialize a teacher
    public Teacher(string name, int age, string subject) : base(name, age)
    {
        Subject = subject;
    }

    // Overriding method to display role
    public override void DisplayRole()
    {
        Console.WriteLine($"Teacher - Name: {Name}, Age: {Age}, Subject: {Subject}");
    }
}
