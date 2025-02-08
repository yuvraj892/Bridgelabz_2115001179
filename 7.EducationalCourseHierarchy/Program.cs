// Main Program
using System;

class Program
{
    public static void Main()
    {
        // Creating a Course object
        Course basicCourse = new Course("Mathematics", "3 months");
        basicCourse.DisplayCourseInfo();

        // Creating an OnlineCourse object
        OnlineCourse onlineCourse = new OnlineCourse("Physics", "4 months", "Physics Wallah", true);
        onlineCourse.DisplayCourseInfo();

        // Creating a PaidOnlineCourse object
        PaidOnlineCourse paidCourse = new PaidOnlineCourse("Computer Science", "6 months", "Coursera", true, 200, 20);
        paidCourse.DisplayCourseInfo();
    }
}