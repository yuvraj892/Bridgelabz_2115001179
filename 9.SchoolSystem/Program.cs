// Main Program
using System;

class Program
{
    public static void Main()
    {
        // Creating a Teacher object
        Teacher teacher = new Teacher("Ashish Chauhan", 35, "Mathematics");
        teacher.DisplayRole();

        // Creating a Student object
        Student student = new Student("Piyush Kumar Singh", 16, "10th Grade");
        student.DisplayRole();

        // Creating a Staff object
        Staff staff = new Staff("Pradeep Srivastava", 40, "Administrator");
        staff.DisplayRole();
    }
}
