using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;

class CSVToObjects
{
    public static void Main(string[] args)
    {
        // Create a list to hold Student objects
        List<Student> students = new List<Student>();

        // Read the CSV file
        using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\students.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // Get all records from the CSV file and convert to list
            students = csv.GetRecords<Student>().ToList();
        }

        // Print the number of students loaded
        Console.WriteLine("Loaded " + students.Count + " students from CSV file.");
        Console.WriteLine();

        // Print each student object
        Console.WriteLine("Student Details:");
        foreach (var student in students)
        {
            // Print student information
            Console.WriteLine("ID: " + student.ID +
                            ", Name: " + student.Name +
                            ", Age: " + student.Age +
                            ", Marks: " + student.Marks);
        }
    }
}

// Class to represent a student record
class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}