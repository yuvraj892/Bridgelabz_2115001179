using System;
class StudentScore
{
    static Random rand = new Random();
    static int[,] GenerateScores(int numStudents)
    {
        int[,] scores = new int[numStudents, 3];
        for (int i = 0; i < numStudents; i++)
        {
            scores[i, 0] = rand.Next(10, 100); // Physics Score
            scores[i, 1] = rand.Next(10, 100); // Chemistry Score
            scores[i, 2] = rand.Next(10, 100); // Math Score
        }
        return scores;
    }

    static double[,] CalculateResults(int[,] scores)
    {
        int numStudents = scores.GetLength(0);
        double[,] results = new double[numStudents, 3]; // Total, Average, Percentage
        for (int i = 0; i < numStudents; i++)
        {
            int total = scores[i, 0] + scores[i, 1] + scores[i, 2];
            double average = total / 3.0;
            double percentage = (total / 300.0) * 100;
            results[i, 0] = total;
            results[i, 1] = Math.Round(average, 2);
            results[i, 2] = Math.Round(percentage, 2);
        }
        return results;
    }
    static string AssignGrade(double percentage)
    {
        if (percentage >= 80) return "A";
        if (percentage >= 70) return "B";
        if (percentage >= 60) return "C";
        if (percentage >= 50) return "D";
        if (percentage >= 40) return "E";
        return "R"; // Remedial standards
    }
    static void DisplayResults(int[,] scores, double[,] results)
    {
        Console.WriteLine("Stu No\tPhysics\tChemistry\tMath\tTotal\tAverage\tPercentage\tGrade");
        for (int i = 0; i < scores.GetLength(0); i++)
        {
            string grade = AssignGrade(results[i, 2]);
            Console.WriteLine($"{i + 1}\t{scores[i, 0]}\t{scores[i, 1]}\t\t{scores[i, 2]}\t{results[i, 0]}\t{results[i, 1]}\t{results[i, 2]}%\t\t{grade}");
        }
    }
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int numStudents = int.Parse(Console.ReadLine());
        int[,] scores = GenerateScores(numStudents);
        double[,] results = CalculateResults(scores);
        DisplayResults(scores, results);
    }
}