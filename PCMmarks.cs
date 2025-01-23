using System;
class PCMmarks
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter marks for three subjects (Physics, Chemistry, Maths):");
        Console.Write("Physics: ");
        double physics = Convert.ToDouble(Console.ReadLine());
        Console.Write("Chemistry: ");
        double chemistry = Convert.ToDouble(Console.ReadLine());
        Console.Write("Maths: ");
        double maths = Convert.ToDouble(Console.ReadLine());
        ComputeGradeAndPercentage(physics, chemistry, maths);
        Console.WriteLine("\nCheck if a number is prime:");
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (IsPrime(number))
        {
            Console.WriteLine($"{number} is a Prime Number.");
        }
        else
        {
            Console.WriteLine($"{number} is not a Prime Number.");
        }
    }
    static void ComputeGradeAndPercentage(double physics, double chemistry, double maths)
    {
        double total = physics + chemistry + maths;
        double percentage = total / 3;
        string grade;
        string remarks;

        if (percentage >= 80)
        {
            grade = "A";
            remarks = "Level 4, above agency-normalized standards";
        }
        else if (percentage >= 70)
        {
            grade = "B";
            remarks = "Level 3, at agency-normalized standards";
        }
        else if (percentage >= 60)
        {
            grade = "C";
            remarks = "Level 2, below, but approaching agency-normalized standards";
        }
        else if (percentage >= 50)
        {
            grade = "D";
            remarks = "Level 1, well below agency-normalized standards";
        }
        else if (percentage >= 40)
        {
            grade = "E";
            remarks = "Level 1-, too below agency-normalized standards";
        }
        else
        {
            grade = "R";
            remarks = "Remedial standards";
        }
        Console.WriteLine($"\nAverage Percentage: {percentage:F2}%");
        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine($"Remarks: {remarks}");
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
