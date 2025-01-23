using System;
class multipleCheck
{
    static void Main()
    {
        // Get the input number from the user
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Loop backwards from 100 to 1
        Console.WriteLine("The multiples of " + number + " below 100 are:");
        for (int i = 100; i >= 1; i--)
        {
            if (i % number == 0) // Check if i is a multiple of the number
            {
                Console.WriteLine(i); // Print the multiple
            }
        }
    }
}
