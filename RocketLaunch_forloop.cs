using System;
class RocketLaunch
{
    static void Main(string[] args)
    {
        Console.Write("Enter the starting number for the countdown: ");
        int counter = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Starting countdown:");
        for(int i=counter;i>=1;i--) // Loop until the counter reaches 1
        {
            Console.WriteLine(counter);
            counter--; // Decrement the counter
        }
        Console.WriteLine("Liftoff");
    }
}