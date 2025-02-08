// Subclass representing a Student
class Student : Person
{
    // Additional attribute for student
    public string Grade { get; private set; }

    // Constructor to initialize a student
    public Student(string name, int age, string grade) : base(name, age)
    {
        Grade = grade;
    }

    // Overriding method to display role
    public override void DisplayRole()
    {
        Console.WriteLine($"Student - Name: {Name}, Age: {Age}, Grade: {Grade}");
    }
}
