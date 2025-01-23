using System;
class RocketLaunch
{
    static void Main(string[] args)
    {
        Console.Write("Enter the starting number for the countdown: ");
        int counter = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Starting countdown:");
        while (counter >= 1) // Loop until the counter reaches 1
        {
            Console.WriteLine(counter);
            counter--; // Decrement the counter
        }
        Console.WriteLine("Liftoff");
    }
}