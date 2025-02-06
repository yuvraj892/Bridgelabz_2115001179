using System;
using System.Collections.Generic;
class CompanyDept
{
    static void Main()
    {
        // Creating company
        Company myCompany = new Company("Capgemini");
		
		
		
        myCompany.AddDept("IT");
        myCompany.AddDept("HR");

        // Adding employees to departments
        myCompany.AddEmployeeToDepartment("IT", "Yuvraj Srivastava", "Software Engineer");
        myCompany.AddEmployeeToDepartment("IT", "Amitabh", "System Administrator");
        myCompany.AddEmployeeToDepartment("HR", "Krishna", "HR Manager");
        // Displaying company structure
        myCompany.DisplayCompanyStructure();
    }
}
//Class Company
using System;
using System.Collections.Generic;



// Represents a company that consists of multiple departments and employees
class Company
{
	
    public string Name { get; set; }
	

    // List of departments within the company (private to restrict direct access)
    private List<Department> Departments { get; set; }

    // Constructor to initialize the company with a name
    public Company(string name)
    {
        Name = name;
        Departments = new List<Department>(); // Initializes an empty department list
    }

    // Adds a new department to the company
    public void AddDept(string departmentName)
    {
        Departments.Add(new Department(departmentName));
    }

    // Adds an employee to a specific department (if it exists)
    public void AddEmployeeToDepartment(string departmentName, string employeeName, string position)
    {
        var department = Departments.Find(d => d.Name == departmentName);

        if (department != null)
        {
            department.AddEmployee(employeeName, position);
        }
        else
        {
            Console.WriteLine("Department not found.");
        }
    }

    // Displays the entire company structure, including all departments and employees
    public void DisplayCompanyStructure()
    {
        Console.WriteLine($"Company: {Name}");

        // Loop through each department and display its employees
        foreach (var department in Departments)
        {
            department.DisplayEmployees();
        }
    }
}
//Class Department
using System;
using System.Collections.Generic;
class Department
{
    // The name of the department
    public string Name { get; set; }

    // List of employees in this department (private to restrict direct modification)
    private List<Employee> Employees { get; set; }

    // Constructor to initialize a department with a name
    public Department(string name)
    {
        Name = name;
        Employees = new List<Employee>();
    }

    // Adds a new employee to the department
    public void AddEmployee(string name, string position)
    {
        Employees.Add(new Employee(name, position));
    }



    public void DisplayEmployees()
    {
        Console.WriteLine($"Department: {Name}");
        foreach (var employee in Employees)
        {
            employee.Display();
        }
    }
}
//class Employee
using System;



class Employee
{
	
    public string Name { get; set; }
    public string Position { get; set; }
    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void Display()
    {
        Console.WriteLine($"Employee: {Name}, Position: {Position}");
    }
}
