using System;

class Employee
{
    private static int totalEmployees = 0;
    public static string CompanyName = "Capgemini";
    public readonly int Id;
    public string Name;
    public string Designation;

    public Employee(string Name, int Id, string Designation)
    {
        this.Name = Name;
        this.Id = Id;
        this.Designation = Designation;
        totalEmployees++;
    }

    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + totalEmployees);
    }

    public void DisplayEmployeeDetails()
    {
        if (this is Employee)
        {
            Console.WriteLine("Company Name: " + CompanyName);
            Console.WriteLine("Employee Name: " + Name);
            Console.WriteLine("Employee ID: " + Id);
            Console.WriteLine("Designation: " + Designation);
        }
    }

    static void Main()
    {
        Console.Write("Enter number of employees: ");
        int count = int.Parse(Console.ReadLine());
        Employee[] employees = new Employee[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Designation: ");
            string designation = Console.ReadLine();
            employees[i] = new Employee(name, id, designation);
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Total Employees");
            Console.WriteLine("2. Display All Employees");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayTotalEmployees();
                    break;
                case 2:
                    foreach (var employee in employees)
                    {
                        employee.DisplayEmployeeDetails();
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
