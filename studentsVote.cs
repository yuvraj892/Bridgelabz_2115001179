using System;
class studentsVote
{
    static void Main()
    {
        int[] ages = new int[10]; // Array to store ages of 10 students

        // Loop to take user input for each student's age
        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write("Enter the age of student " + (i + 1) + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            // Check if the age is valid
            if (ages[i] < 0)
            {
                Console.WriteLine("Invalid age entered.");
            }
            else if (ages[i] >= 18)
            {
                Console.WriteLine("The student with age " + ages[i] + " can vote.");
            }
            else
            {
                Console.WriteLine("The student with age " + ages[i] + " cannot vote.");
            }
        }
    }
}
