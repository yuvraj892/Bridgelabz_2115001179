using System;
using System.IO;
using System.Collections.Generic;

namespace StudentDataBinaryStorage
{
    // Student class to store student information
    class Student
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }

        // Constructor
        public Student(int rollNumber, string name, double gpa)
        {
            RollNumber = rollNumber;
            Name = name;
            GPA = gpa;
        }

        // Override ToString for display
        public override string ToString()
        {
            return "Roll Number: " + RollNumber + ", Name: " + Name + ", GPA: " + GPA.ToString("F2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Define binary file path
            string binaryFilePath = "students.bin";

            try
            {
                // Create a list of students
                List<Student> students = new List<Student>
                {
                    new Student(101, "John Smith", 3.75),
                    new Student(102, "Emily Johnson", 4.00),
                    new Student(103, "Michael Brown", 3.50),
                    new Student(104, "Jessica Davis", 3.82),
                    new Student(105, "David Wilson", 3.65)
                };

                // Store students in binary file
                StoreStudentsToBinaryFile(students, binaryFilePath);
               
                // Retrieve students from binary file
                List<Student> retrievedStudents = RetrieveStudentsFromBinaryFile(binaryFilePath);
               
                // Display retrieved students
                Console.WriteLine("Retrieved Student Information:");
                foreach (var student in retrievedStudents)
                {
                    Console.WriteLine(student);
                }
            }
            catch (IOException ex)
            {
                // Handle IO exceptions
                Console.WriteLine("An IO error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Wait for user to press a key before closing
            Console.ReadKey();
        }

        // Method to store students to binary file
        static void StoreStudentsToBinaryFile(List<Student> students, string filePath)
        {
            try
            {
                // Create FileStream for binary file
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                // Create BinaryWriter for writing primitive data
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    // Write number of students (for later reading)
                    writer.Write(students.Count);
                   
                    // Write each student's data
                    foreach (var student in students)
                    {
                        // Write roll number (int)
                        writer.Write(student.RollNumber);
                       
                        // Write name (string)
                        writer.Write(student.Name);
                       
                        // Write GPA (double)
                        writer.Write(student.GPA);
                    }
                }
               
                // Display success message
                Console.WriteLine("Successfully stored " + students.Count + " students to " + filePath);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error storing students to binary file: " + ex.Message);
                throw;
            }
        }

        // Method to retrieve students from binary file
        static List<Student> RetrieveStudentsFromBinaryFile(string filePath)
        {
            try
            {
                // Check if file exists
                if (!File.Exists(filePath))
                {
                    // Throw exception if file doesn't exist
                    throw new FileNotFoundException("The binary file does not exist.", filePath);
                }

                // Create a list to store retrieved students
                List<Student> retrievedStudents = new List<Student>();
               
                // Create FileStream for reading
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                // Create BinaryReader for reading primitive data
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    // Read number of students
                    int studentCount = reader.ReadInt32();
                   
                    // Read each student's data
                    for (int i = 0; i < studentCount; i++)
                    {
                        // Read roll number
                        int rollNumber = reader.ReadInt32();
                       
                        // Read name
                        string name = reader.ReadString();
                       
                        // Read GPA
                        double gpa = reader.ReadDouble();
                       
                        // Create new Student object with retrieved data
                        Student student = new Student(rollNumber, name, gpa);
                       
                        // Add to list
                        retrievedStudents.Add(student);
                    }
                }
               
                // Display success message
                Console.WriteLine("Successfully retrieved " + retrievedStudents.Count + " students from " + filePath);
               
                // Return list of retrieved students
                return retrievedStudents;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error retrieving students from binary file: " + ex.Message);
                throw;
            }
        }
    }
}
