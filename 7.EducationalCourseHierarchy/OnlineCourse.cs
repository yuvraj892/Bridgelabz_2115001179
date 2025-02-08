// Subclass representing an Online Course
class OnlineCourse : Course
{
    // Additional attributes for an online course
    public string Platform { get; private set; }
    public bool IsRecorded { get; private set; }

    // Constructor to initialize an online course
    public OnlineCourse(string courseName, string duration, string platform, bool isRecorded) : base(courseName, duration)
    {
        Platform = platform;
        IsRecorded = isRecorded;
    }

    // Overriding method to display online course information
    public override void DisplayCourseInfo()
    {
        Console.WriteLine($"Course: {CourseName}, Duration: {Duration}, Platform: {Platform}, Recorded: {IsRecorded}");
    }
}