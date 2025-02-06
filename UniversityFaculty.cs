using System;
using System.Collections.Generic;



class UniversityFaculty
{
    static void Main()
    {
		
		
        University myUniversity = new University("Tech University");

        // Adding departments
        myUniversity.AddDepartment("Engineering mqaths");
        myUniversity.AddDepartment("operating system");

        // Creating faculty members
        Faculty profAlice = new Faculty("Arun", "Operating System");
        Faculty profBob = new Faculty("Anjali", "Verbal");

        myUniversity.AddFaculty(profArun);
        myUniversity.AddFaculty(profAnjali);

        // Displaying university structure
        myUniversity.DisplayUniversity();
    }
}
//Class University
using System;
using System.Collections.Generic;
class University
{
    public string Name { get; set; }
    // List of departments in the university (private to restrict direct access)
    private List<Department> Departments { get; set; }

    // List of faculty members associated with the university (private to restrict direct access)
    private List<Faculty> Faculties { get; set; }
    // Constructor to initialize the university with a name
    public University(string name)
    {
        Name = name;
        Departments = new List<Department>(); // Initializes an empty list of departments
        Faculties = new List<Faculty>(); // Initializes an empty list of faculties
    }

    // Adds a new department to the university
    public void AddDepartment(string departmentName)
    {
        Departments.Add(new Department(departmentName)); // Adds a new department
    }

    // Adds a new faculty member to the university
    public void AddFaculty(Faculty faculty)
    {
        Faculties.Add(faculty); // Adds the faculty to the list
    }



    // Displays the university's structure, including departments and faculties
    public void DisplayUniversity()
    {
        Console.WriteLine($"University: {Name}");

        // Display all departments in the university
        Console.WriteLine("Departments:");
        foreach (var department in Departments)
        {
            department.Display();
			
        }


        // Display all faculty members in the university
        Console.WriteLine("Faculties:");
        foreach (var faculty in Faculties)
        {
            faculty.Display();
        }
    }
}
//Class Department
using System;
class Department
{
	
    
    public string Name { get; set; }

    // Constructor to initialize the department with a name
    public Department(string name)
    {
        Name = name;
    }

    // Displays the department's name
    public void Display()
    {
        Console.WriteLine($"Department: {Name}");
    }
}



//Class Faculty
using System;
// Represents a faculty member in a university, independent of departments
class Faculty
{
    // The name of the faculty member
    public string Name { get; set; }

    // The area of specialization of the faculty member
    public string Specialization { get; set; }

    // Constructor to initialize the faculty member with a name and specialization
    public Faculty(string name, string specialization)
    {
        Name = name;
        Specialization = specialization;
    }

    public void Display()
    {
        Console.WriteLine($"Faculty: {Name}, Specialization: {Specialization}");
    }
}
