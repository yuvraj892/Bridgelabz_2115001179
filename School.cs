using System;
using System.Collections.Generic;

class School
{
    static void Main()
    {
        School mySchool = new School("Bal Vidyapeeth Public School,Aonla");
        Student student1 = new Student("Nishant Chauhan");
        Student student2 = new Student("Piyush Kumar Singh");
        //Adding students to the school
        mySchool.AddStudent(student1);
        mySchool.AddStudent(student2);

        //courses
        Course math = new Course("maths");
        Course science = new Course("Hindi");
        // Enrolling students in courses
        math.EnrollStudent(student1);
        math.EnrollStudent(student2);
        science.EnrollStudent(student1);

        // Displaying students and their courses
        student1.ViewEnrolledCourses();
        student2.ViewEnrolledCourses();

        // Displaying courses and their enrolled students
        math.DisplayEnrolledStudents();
        science.DisplayEnrolledStudents();
    }
}
//Class School
using System;
using System.Collections.Generic;
class School
{
    // The name of the school
    public string SchoolName { get; set; }
    public List<Student> Students { get; set; }




    public School(string schoolName)
    {
        SchoolName = schoolName;
        Students = new List<Student>(); // Initializes an empty list of students
    }

    public void AddStudent(Student student)
    {
        if (!Students.Contains(student))
        {
            Students.Add(student); // Adds the student to the list
    }
    }
    public void DisplayStudents()
    {
        Console.WriteLine($"School: {SchoolName}");
    foreach (var student in Students)
        {
            Console.WriteLine($"Student: {student.Name}");
        }
    }
}
//Class Student
using System;
using System.Collections.Generic;

// Represents a student who can enroll in multiple courses
class Student
{
    // The name of the student
    public string Name { get; set; }

    // List of courses the student is enrolled in
    public List<Course> Courses { get; set; }

    // Constructor to initialize the student with a name
    public Student(string name)
    {
        Name = name;
        Courses = new List<Course>(); // Initializes an empty list of courses
    }

    // Enrolls the student in a course (if not already enrolled)
    public void EnrollInCourse(Course course)
    {
        if (!Courses.Contains(course))
        {
            Courses.Add(course); // Adds the course to the student's list of enrolled courses
        }
    }

    // Displays all courses the student is currently enrolled in
    public void ViewEnrolledCourses()
    {
        Console.WriteLine($"Student: {Name}");

        // Loop through each course and display its name
        foreach (var course in Courses)
        {
            Console.WriteLine($"Enrolled in: {course.CourseName}");
        }
    }
}


//Class Course
using System;
using System.Collections.Generic;

// Represents a course that students can enroll in
class Course
{
    // The name of the course
    public string CourseName { get; set; }

    // List of students currently enrolled in the course
    public List<Student> EnrolledStudents { get; set; }

    // Constructor to initialize the course with a name
    public Course(string courseName)
    {
        CourseName = courseName;
        EnrolledStudents = new List<Student>(); // Initializes an empty list of enrolled students
    }

    // Enrolls a student in the course (if they are not already enrolled)
    public void EnrollStudent(Student student)
    {
        if (!EnrolledStudents.Contains(student))
        {
            EnrolledStudents.Add(student);
            student.EnrollInCourse(this); // Notifies the student that they have enrolled in the course
        }
    }

    // Displays all students enrolled in the course
    public void DisplayEnrolledStudents()
    {
        Console.WriteLine($"Course: {CourseName}");

        // Loop through each enrolled student and display their name
        foreach (var student in EnrolledStudents)
        {
            Console.WriteLine($"Student: {student.Name}");
        }
    }
}
