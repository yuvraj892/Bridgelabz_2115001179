using System;

class Student
{
    // Public variable (can be accessed from anywhere)
    public int rollNumber;

    // Protected variable (can be accessed in this class and derived classes)
    protected string name;

    // Private variable (can be accessed only within this class)
    private double CGPA;

    // Constructor to initialize student details
    public Student(int rollNumber, string name, double CGPA)
    {
        this.rollNumber = rollNumber;
        this.name = name;
        this.CGPA = CGPA;
    }

    // Public method to get CGPA
    public double GetCGPA()
    {
        return CGPA;
    }

    // Public method to set CGPA (controlled access)
    public void SetCGPA(double newCGPA)
    {
        if (newCGPA >= 0 && newCGPA <= 10) // Valid CGPA range
        {
            CGPA = newCGPA;
        }
        else
        {
            Console.WriteLine("Invalid CGPA. Must be between 0 and 10.");
        }
    }

    // Method to display student details
    public void DisplayStudentDetails()
    {
        Console.WriteLine("Roll Number: " + rollNumber);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("CGPA: " + CGPA);
    }
}

// Subclass demonstrating protected member access
class PostgraduateStudent : Student
{
    private string researchTopic;

    // Constructor for postgraduate student
    public PostgraduateStudent(int rollNumber, string name, double CGPA, string researchTopic)
        : base(rollNumber, name, CGPA)
    {
        this.researchTopic = researchTopic;
    }

    // Method to display postgraduate student details
    public void DisplayPGStudentDetails()
    {
        Console.WriteLine("Postgraduate Student Details:");
        Console.WriteLine("Roll Number: " + rollNumber);
        Console.WriteLine("Name: " + name); // Accessing protected member
        Console.WriteLine("Research Topic: " + researchTopic);
    }
}

class University
{
    static void Main()
    {
        // Creating Student object
        Student s1 = new Student(101, "Ramesh", 8.5);
        Console.WriteLine("Student Details:");
        s1.DisplayStudentDetails();

        // Modifying CGPA using public method
        s1.SetCGPA(9.2);
        Console.WriteLine("\nUpdated CGPA: " + s1.GetCGPA());

        // Creating PostgraduateStudent object
        PostgraduateStudent pg1 = new PostgraduateStudent(201, "Ram", 9.0, "Physics");
        Console.WriteLine("\nPostgraduate Student Details:");
        pg1.DisplayPGStudentDetails();
    }
}
