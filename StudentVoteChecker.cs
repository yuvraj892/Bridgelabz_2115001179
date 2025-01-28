using System;
public class StudentVoteChecker
{
    // Method to check if the student can vote
    public static bool CanStudentVote(int age)
    {
        if (age < 0)
        {
            // Invalid age, cannot vote
            return false;
        }
        return age >= 18;
    }
    static void Main()
    {
        int[] studentAges = new int[10];
        Console.WriteLine("Enter the ages of 10 students:");
        for (int i = 0; i < studentAges.Length; i++)
        {
            Console.Write($"Enter age for student {i + 1}: ");
            bool validInput = int.TryParse(Console.ReadLine(), out studentAges[i]);
            // Validate input
            if (!validInput || studentAges[i] < 0)
            {
                Console.WriteLine("Invalid age entered. Please enter a valid non-negative number.");
                i--; // Decrement index to re-enter age for the student
                continue;
            }
            // Call CanStudentVote and display the result
            bool canVote = CanStudentVote(studentAges[i]);
            if (canVote)
                Console.WriteLine($"Student {i + 1} (Age {studentAges[i]}) is eligible to vote.");
            else
                Console.WriteLine($"Student {i + 1} (Age {studentAges[i]}) is NOT eligible to vote.");
        }
    }
}
