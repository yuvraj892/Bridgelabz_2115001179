// Main Program
using System;
class Program
{
    public static void Main()
    {
        // Creating object for a Manager 
        Manager manager = new Manager("Ankush Singh", 101, 75000, 10);
        // Creating object for a Developer
        Developer developer = new Developer("Chahat Gupta", 102, 60000, "C#");
        // Creating object for a Intern
        Intern intern = new Intern("Amit Yadav", 103, 20000, "3 months");

        // Displaying details of Manager
        manager.DisplayDetails();
        // Displaying details of Developer
        developer.DisplayDetails();
        // Displaying details of Intern
        intern.DisplayDetails();
    }
}




