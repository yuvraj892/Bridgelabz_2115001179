using System;
class factor
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        // Loop to find factors
        Console.WriteLine("The factors of " + number + " are:");
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0) // Check if i is a factor of the number
            {
                Console.WriteLine(i);
            }
        }
    }
}
