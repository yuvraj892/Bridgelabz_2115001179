using System;
class GenerateGuess
{
    static Random random = new Random();
    static void Main()
    {
        Console.WriteLine("Think of a number between 1 and 100, and I'll try to guess it!");
        int lowerBound = 1;
        int upperBound = 100;
        bool CorrectlyGuessed = false;
        while (!CorrectlyGuessed)
        {
            int guess = Generate(lowerBound, upperBound);
            Console.WriteLine($"Is your number {guess}? (Enter 'high', 'low', or 'correct')");
            string feedback = GetUserFeedback();
            if (feedback == "correct")
            {
                Console.WriteLine("Yay! I guessed it!");
                CorrectlyGuessed = true;
            }
            else if (feedback == "low")
            {
                lowerBound = guess + 1;
            }
            else if (feedback == "high")
            {
                upperBound = guess - 1;
            }
        }
    }
    static int Generate(int lower, int upper)
    {
        return random.Next(lower, upper + 1);
    }
    static string GetUserFeedback()
    {
        string feedback = Console.ReadLine().ToLower();
        while (feedback != "high" && feedback != "low" && feedback != "correct")
        {
            Console.WriteLine("Please enter 'high', 'low', or 'correct':");
            feedback = Console.ReadLine().ToLower();
        }
        return feedback;
    }
}
