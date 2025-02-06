using System;
using System.Collections.Generic;
class UnivMgmt
{
    static void Main()
    {
        University myUniversity = new University("Tech University");
        Professor profPrabhat = new Professor("Dr. Prabhat", "Computer Science");
        Professor profUmesh = new Professor("Dr. Umesh", "Mathematics");
		
		
        Student studentVivek = new Student("Vivek");
        Student studentAmit = new Student("Amit");

        Course cs101 = new Course("Introduction to Computer Science");
        Course math101 = new Course("Engineering Mathematics-III");

        // Assigning professors
        cs101.AssignProfessor(profPrabhat);
        math101.AssignProfessor(profUmesh);

        // Enrolling students in courses
        studentVivek.EnrollCourse(cs101);
        studentVivek.EnrollCourse(math101);
        studentAmit.EnrollCourse(math101);

        // Adding professors, students, and courses to university
        myUniversity.AddProfessor(profPrabhat);
        myUniversity.AddProfessor(profUmesh);
        myUniversity.AddStudent(studentVivek);
        myUniversity.AddStudent(studentAmit);
        myUniversity.AddCourse(cs101);
        myUniversity.AddCourse(math101);

        // Displaying university structure
        myUniversity.DisplayUniversity();
    }
}


//class University
using System;
using System.Collections.Generic;

// Represents a university that manages professors, students, and courses
class University
{
    public string Name { get; set; }
    public List<Course> Courses { get; set; }
    public List<Professor> Professors { get; set; }

    // List of students enrolled at the university
    public List<Student> Students { get; set; }
    public University(string name)
    {
        // Set the name of the university
        Name = name;
        Courses = new List<Course>();
        Professors = new List<Professor>();
        Students = new List<Student>();
    }

    // Adds a new course to the university
    public void AddCourse(Course course)
    {
        // Add the course to the list of courses
        Courses.Add(course);
    }

    // Adds a new professor to the university
    public void AddProfessor(Professor professor)
    {
        // Add the professor to the list of professors
        Professors.Add(professor);
    }

    // Adds a new student to the university
    public void AddStudent(Student student)
    {
        // Add the student to the list of students
        Students.Add(student);
    }
    public void DisplayUniversity()
    {
        // Print the university name
        Console.WriteLine($"University: {Name}");

        // Display all courses offered by the university
        Console.WriteLine("Courses:");
        foreach (var course in Courses)
        {
            course.DisplayCourse();
        }

        // Display all professors working at the university
        Console.WriteLine("Professors:");
        foreach (var professor in Professors)
        {
            professor.Display();
        }

        // Display all students enrolled at the university
        Console.WriteLine("Students:");
        foreach (var student in Students)
        {
            student.DisplayCourses();
        }
    }
}
//class Professor
using System;
// Represents a professor in the university, who teaches courses
class Professor
{
    // The name of the professor
    public string Name { get; set; }

    // The department the professor belongs to
    public string Department { get; set; }

    // Constructor to initialize the professor with a name and department
    public Professor(string name, string department)
    {
        // Set the name of the professor
        Name = name;

        // Set the department the professor belongs to
        Department = department;
    }

    // Displays the professor's details
    public void Display()
    {
        // Print the professor's name and department
        Console.WriteLine($"Professor: {Name}, Department: {Department}");
    }
}
//class Student
using System;
using System.Collections.Generic;
// Represents a student, who is enrolled in multiple courses
class Student
{
    // The name of the student
    public string Name { get; set; }

    // List of courses the student is enrolled in
    public List<Course> Courses { get; set; }

    // Constructor to initialize the student with a name
    public Student(string name)
    {
        // Set the student's name
        Name = name;

        // Initializes an empty list of courses the student is enrolled in
        Courses = new List<Course>();
    }

    // Enroll the student in a course
    public void EnrollCourse(Course course)
    {
        // Add the course to the student's list of courses
        Courses.Add(course);

        // Enroll the student in the course as well
        course.EnrollStudent(this);
    }

    // Displays the courses the student is enrolled in
    public void DisplayCourses()
    {
        // Print the student's name
        Console.WriteLine($"Student: {Name}");

        // Loop through each course the student is enrolled in and display its name
        foreach (var course in Courses)
        {
            Console.WriteLine($"Enrolled in: {course.Name}");
        }
    }
}
//class Course
using System;
using System.Collections.Generic;
class Course
{
    public string Name { get; set; }
    public Professor AssignedProfessor { get; private set; }
    public List<Student> EnrolledStudents { get; set; }
    public Course(string name)
    {
        Name = name;
        EnrolledStudents = new List<Student>();
    }
    public void AssignProfessor(Professor professor)
    {
        AssignedProfessor = professor;
    }

    // Enroll a student in the course
    public void EnrollStudent(Student student)
    
        EnrolledStudents.Add(student);
    }
    public void DisplayCourse()
    {
        Console.WriteLine($"Course: {Name}");
        Console.WriteLine($"Professor: {(AssignedProfessor != null ? AssignedProfessor.Name : "None")}");
        Console.WriteLine("Enrolled Students:");
        foreach (var student in EnrolledStudents)
        {
            Console.WriteLine($"- {student.Name}");
        }
    }
}
