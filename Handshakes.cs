using System;
class Handshakes
{
    static void Main()
    {
        Console.Write("Enter the number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());
        int maxHandshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;
        Console.WriteLine("The maximum number of possible handshakes among"+numberOfStudents+"students is "+maxHandshakes);
    }
}
