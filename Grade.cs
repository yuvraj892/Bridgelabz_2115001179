using System;
class Grade
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of students: ");
        int numStudents = int.Parse(Console.ReadLine());
        // Arrays to store data for each student
        int[,] marks = new int[numStudents, 3]; // Physics, Chemistry, Maths
        double[] percentages = new double[numStudents];
        char[] grades = new char[numStudents];

        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"\nEnter marks for Student {i + 1}:");

            for (int j = 0; j < 3; j++)
            {
                string subject = j == 0 ? "Physics" : j == 1 ? "Chemistry" : "Maths";

                while (true)
                {
                    Console.Write($"Enter marks for {subject} (0-100): ");
                    int mark = int.Parse(Console.ReadLine());
                    if (mark >= 0 && mark <= 100)
                    {
                        marks[i, j] = mark;
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter marks between 0 and 100.");
                }
            }
            // Calculate percentage
            percentages[i] = (marks[i, 0] + marks[i, 1] + marks[i, 2]) / 3.0;
            if (percentages[i] >= 80)
                grades[i] = 'A';
            else if (percentages[i] >= 70)
                grades[i] = 'B';
            else if (percentages[i] >= 60)
                grades[i] = 'C';
            else if (percentages[i] >= 50)
                grades[i] = 'D';
            else if (percentages[i] >= 40)
                grades[i] = 'E';
            else
                grades[i] = 'R';
        }
        // Display results
        Console.WriteLine("\nResults:");
        Console.WriteLine("Student\tPhysics\tChemistry\tMaths\tPercentage\tGrade");
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"{i + 1}\t{marks[i, 0]}\t{marks[i, 1]}\t\t{marks[i, 2]}\t{percentages[i]:F2}%\t\t{grades[i]}");
        }
    }
}
