using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;

class MergeCSV
{
    public static void Main(string[] args)
    {
        // Create dictionaries to store data from both files
        Dictionary<int, StudentDetails1> students1 = new Dictionary<int, StudentDetails1>();
        Dictionary<int, StudentDetails2> students2 = new Dictionary<int, StudentDetails2>();

        // Read the first CSV file (students1.csv)
        using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\students1.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // Get all records and create dictionary with ID as key
            var records = csv.GetRecords<StudentDetails1>();
            foreach (var record in records)
            {
                students1[record.ID] = record;
            }
        }

        // Read the second CSV file (students2.csv)
        using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\students2.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // Get all records and create dictionary with ID as key
            var records = csv.GetRecords<StudentDetails2>();
            foreach (var record in records)
            {
                students2[record.ID] = record;
            }
        }

        // Create a list for merged student records
        List<MergedStudent> mergedStudents = new List<MergedStudent>();

        // Merge records based on ID
        foreach (var id in students1.Keys.Union(students2.Keys))
        {
            // Create new merged student object
            MergedStudent mergedStudent = new MergedStudent();
            mergedStudent.ID = id;

            // Add data from first file if available
            if (students1.ContainsKey(id))
            {
                mergedStudent.Name = students1[id].Name;
                mergedStudent.Age = students1[id].Age;
            }

            // Add data from second file if available
            if (students2.ContainsKey(id))
            {
                mergedStudent.Marks = students2[id].Marks;
                mergedStudent.Grade = students2[id].Grade;
            }

            // Add to merged list
            mergedStudents.Add(mergedStudent);
        }

        // Write merged data to a new CSV file
        using (var writer = new StreamWriter("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\merged_students.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            // Write all records to the new file
            csv.WriteRecords(mergedStudents);
        }

        // Display confirmation message
        Console.WriteLine("Files merged successfully! Total records: " + mergedStudents.Count);
    }
}

// Class to represent records from the first CSV file
class StudentDetails1
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

// Class to represent records from the second CSV file
class StudentDetails2
{
    public int ID { get; set; }
    public int Marks { get; set; }
    public string Grade { get; set; }
}

// Class to represent merged records
class MergedStudent
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
    public string Grade { get; set; }
}