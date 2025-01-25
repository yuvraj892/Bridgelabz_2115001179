using System;

class CompareElements
{
    static void Main()
    {
        int[] numbers = new int[5]; // Array to store 5 numbers

        // Loop to take user input for each number
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());

            // Check if the number is positive, negative, or zero
            if (numbers[i] > 0)
            {
                // Further check if the positive number is even or odd
                if (numbers[i] % 2 == 0)
                    Console.WriteLine(numbers[i] + " is positive and even.");
                else
                    Console.WriteLine(numbers[i] + " is positive and odd.");
            }
            else if (numbers[i] < 0)
            {
                Console.WriteLine(numbers[i] + " is negative.");
            }
            else
            {
                Console.WriteLine(numbers[i] + " is zero.");
            }
        }

        // Compare the first and last element of the array
        if (numbers[0] == numbers[4])
        {
            Console.WriteLine("The first and last elements are equal.");
        }
        else if (numbers[0] > numbers[4])
        {
            Console.WriteLine("The first element is greater than the last element.");
        }
        else
        {
            Console.WriteLine("The first element is less than the last element.");
        }
    }
}
