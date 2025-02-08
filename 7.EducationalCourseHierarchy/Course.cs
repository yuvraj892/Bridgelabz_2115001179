// Base class representing a Course
class Course
{
    // Properties for course details
    public string CourseName { get; private set; }
    public string Duration { get; private set; }

    // Constructor to initialize a course
    public Course(string courseName, string duration)
    {
        CourseName = courseName;
        Duration = duration;
    }

    // Virtual method to display course information
    public virtual void DisplayCourseInfo()
    {
        Console.WriteLine($"Course: {CourseName}, Duration: {Duration}");
    }
}