using System;
using System.Collections.Generic;

// Define an abstract class CourseType
public abstract class CourseType
{
    // Abstract property for course name
    public abstract string CourseName { get; set; }

    // Abstract property for credits
    public abstract int Credits { get; set; }

    // Abstract method to evaluate the course
    public abstract void Evaluate();

    // Method to get course details
    public void GetCourseDetails()
    {
        Console.Write("Course Name: " + CourseName);
        Console.Write(" Credits: " + Credits);
    }
}

// Define a class ExamCourse that inherits from CourseType
public class ExamCourse : CourseType
{
    // Property to store the exam date
    public DateTime ExamDate { get; set; }

    // Property to store the duration of the exam
    public int Duration { get; set; }

    // Override CourseName property
    public override string CourseName { get; set; }

    // Override Credits property
    public override int Credits { get; set; }

    // Override Evaluate method to display exam details
    public override void Evaluate()
    {
        Console.WriteLine(" This is an exam-based course. The exam will take place on " + ExamDate + " for " + Duration + " hours.");
    }
}

// Define a class AssignmentCourse that inherits from CourseType
public class AssignmentCourse : CourseType
{
    // Property to store the assignment submission date
    public DateTime Submission { get; set; }

    // Property to store the maximum marks for the assignment
    public int MaxMarks { get; set; }

    // Override CourseName property
    public override string CourseName { get; set; }

    // Override Credits property
    public override int Credits { get; set; }

    // Override Evaluate method to display assignment details
    public override void Evaluate()
    {
        Console.WriteLine(" This is an assignment-based course. Submit your work by " + Submission + ". Maximum marks: " + MaxMarks);
    }
}

// Define a generic class Course<T> where T is a type of CourseType
public class Course<T> where T : CourseType
{
    // List to store courses
    private List<T> courses = new List<T>();

    // Method to add a course to the list
    public void AddCourse(T course)
    {
        courses.Add(course);
        Console.WriteLine("Course " + course.CourseName + " added to the course list.");
    }

    // Method to display all courses in the list
    public void DisplayAllCourses()
    {
        foreach (var course in courses)
        {
            course.GetCourseDetails();
            course.Evaluate();
            Console.WriteLine();
        }
    }

    // Method to remove a course from the list based on course name
    public void RemoveCourse(string courseName)
    {
        var courseToRemove = courses.Find(c => c.CourseName == courseName);
        if (courseToRemove != null)
        {
            courses.Remove(courseToRemove);
            Console.WriteLine("Course '" + courseName + "' has been removed from the course list.");
        }
        else
        {
            Console.WriteLine("Course '" + courseName + "' not found.");
        }
    }
}

// Define the Program class
public class Program
{
    public static void Main()
    {
        // Create an instance of ExamCourse and initialize properties
        ExamCourse examCourse = new ExamCourse
        {
            CourseName = "Advanced Mathematics",
            Credits = 3,
            ExamDate = new DateTime(2025, 6, 15),
            Duration = 3
        };

        // Create an instance of AssignmentCourse and initialize properties
        AssignmentCourse assignmentCourse = new AssignmentCourse
        {
            CourseName = "Software Engineering",
            Credits = 4,
            Submission = new DateTime(2025, 5, 20),
            MaxMarks = 100
        };

        // Create an instance of Course<CourseType> to manage courses
        Course<CourseType> courseManager = new Course<CourseType>();

        // Add courses to the course manager
        courseManager.AddCourse(examCourse);
        courseManager.AddCourse(assignmentCourse);

        // Display all courses in the course manager
        Console.WriteLine("Courses in the Course Manager:");
        courseManager.DisplayAllCourses();

        // Remove a course from the course manager
        courseManager.RemoveCourse("Advanced Mathematics");

        // Display all courses after removal
        Console.WriteLine("\nCourses after removal:");
        courseManager.DisplayAllCourses();
    }
}
