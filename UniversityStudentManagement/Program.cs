using System;

class Student
{
    private static int totalStudents = 0;
    public static string UniversityName = "Global University";
    public readonly int RollNumber;
    public string Name;
    public string Grade;

    public Student(string Name, int RollNumber, string Grade)
    {
        this.Name = Name;
        this.RollNumber = RollNumber;
        this.Grade = Grade;
        totalStudents++;
    }

    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students Enrolled: " + totalStudents);
    }

    public void DisplayStudentDetails()
    {
        if (this is Student)
        {
            Console.WriteLine("University Name: " + UniversityName);
            Console.WriteLine("Student Name: " + Name);
            Console.WriteLine("Roll Number: " + RollNumber);
            Console.WriteLine("Grade: " + Grade);
        }
    }

    static void Main()
    {
        Console.Write("Enter number of students: ");
        int count = int.Parse(Console.ReadLine());
        Student[] students = new Student[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Roll Number: ");
            int rollNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Grade: ");
            string grade = Console.ReadLine();
            students[i] = new Student(name, rollNumber, grade);
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Total Students");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayTotalStudents();
                    break;
                case 2:
                    foreach (var student in students)
                    {
                        student.DisplayStudentDetails();
                    }
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}