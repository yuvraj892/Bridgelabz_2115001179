using System;

class Course
{
    // Instance variables (unique for each course)
    private string courseName;
    private int duration; // Duration in weeks
    private double fee;

    // Class variable (shared among all courses)
    private static string instituteName = "ABC Institute";

    // Constructor to initialize a course
    public Course(string courseName, int duration, double fee)
    {
        this.courseName = courseName;
        this.duration = duration;
        this.fee = fee;
    }

    // Instance method to display course details
    public void DisplayCourseDetails()
    {
        Console.WriteLine("Institute: " + instituteName);
        Console.WriteLine("Course Name: " + courseName);
        Console.WriteLine("Duration: " + duration + " weeks");
        Console.WriteLine("Fee: $" + fee);
    }

    // Class method to update the institute name
    public static void UpdateInstituteName(string newName)
    {
        instituteName = newName;
    }
}
class Program
{
    static void Main()
    {
        Course c1 = new Course("UI/Ux", 8, 24000);
        Course c2 = new Course("Graphic designing", 12, 18000);

        Console.WriteLine("Before Updating Institute Name:\n");
        c1.DisplayCourseDetails();
        Console.WriteLine();
        c2.DisplayCourseDetails();

        // Updating the institute name (affects all courses)
        Course.UpdateInstituteName("XYZ Academy");

        Console.WriteLine("\nAfter Updating Institute Name:\n");
        c1.DisplayCourseDetails();
        Console.WriteLine();
        c2.DisplayCourseDetails();
    }
}
