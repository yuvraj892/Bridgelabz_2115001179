using System;
class CheckPrime
{
    static void Main()
    {
        // Take input from the user
        Console.Write("Enter a number to check if it's prime: ");
        int number = int.Parse(Console.ReadLine());
        // Check if the number is prime
        bool isPrime = IsPrime(number);
        if (isPrime)
        {
            Console.WriteLine(number +" is a prime number.");
        }
        else
        {
            Console.WriteLine(number+" is not a prime number.");
        }
    }
    // Function to check if a number is prime
    static bool IsPrime(int num)
    {
        if (num <= 1) return false; // Numbers <= 1 are not prime

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0) return false; // If divisible, not prime
        }
        return true;
    }
}
