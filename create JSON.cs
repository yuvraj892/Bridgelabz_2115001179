using Newtonsoft.Json;
using System;

class CreateJson
{
    // Class to represent a student
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Subjects { get; set; }
    }

    static void Main(string[] args)
    {
        // Create a new Student object
        Student student = new Student
        {
            Name = "John Doe",
            Age = 20,
            Subjects = new string[] { "Mathematics", "Physics", "Computer Science" }
        };

        // Convert the Student object to JSON string
        string jsonString = JsonConvert.SerializeObject(student, Formatting.Indented);

        // Print the JSON string
        Console.WriteLine("Student JSON:");
        Console.WriteLine(jsonString);

        Console.ReadKey();
    }
}
