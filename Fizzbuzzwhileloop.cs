using System;
class Fizzbuzzwhileloop
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        int number = int.Parse(Console.ReadLine());
        if (number > 0)
        {
            int i = 1;
            // Use while loop to iterate from 1 to the entered number
            while (i <= number)
            {
                // Check if the number is divisible by both 3 and 5
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                // Check if the number is divisible by 3
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                // Check if the number is divisible by 5
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
                i++;
            }
        }
        else
        {
            Console.WriteLine("Please enter a positive integer.");
        }
    }
}
