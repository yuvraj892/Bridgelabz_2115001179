using System;

class ReverseNumber
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        // Find the number of digits and store them in an array
        int tempNumber = number;
        int count = 0;

        while (tempNumber != 0)
        {
            count++;
            tempNumber /= 10;
        }
        int[] digits = new int[count];
        int index = 0;
        tempNumber = number;
        while (tempNumber != 0)
        {
            digits[index] = tempNumber % 10; // Store each digit
            tempNumber /= 10;
            index++;
        }
        // Display the reversed number
        Console.Write("The reversed number is: ");
        for (int i = 0; i < count; i++)
        {
            Console.Write(digits[i]);
        }
        Console.WriteLine();
    }
}
