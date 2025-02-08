// Subclass representing a Paid Online Course
class PaidOnlineCourse : OnlineCourse
{
    // Additional attributes for a paid online course
    public double Fee { get; private set; }
    public double Discount { get; private set; }

    // Constructor to initialize a paid online course
    public PaidOnlineCourse(string courseName, string duration, string platform, bool isRecorded, double fee, double discount)
        : base(courseName, duration, platform, isRecorded)
    {
        Fee = fee;
        Discount = discount;
    }

    // Overriding method to display paid online course information
    public override void DisplayCourseInfo()
    {
        double discountedPrice = Fee - (Fee * Discount / 100);
        Console.WriteLine($"Course: {CourseName}, Duration: {Duration}, Platform: {Platform}, Recorded: {IsRecorded}, Fee: ${Fee}, Discount: {Discount}%, Final Price: ${discountedPrice}");
    }
}