using System;

class evenOddNum
{
    static void Main()
    {
        // Get user input for the number
        Console.Write("Enter a natural number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check if the entered number is a valid natural number
        if (number <= 0)
        {
            Console.WriteLine("Please enter a valid natural number greater than 0.");
            return;
        }

        // Arrays to store odd and even numbers
        int[] oddNumbers = new int[number / 2 + 1];
        int[] evenNumbers = new int[number / 2 + 1];

        // Index variables for odd and even arrays
        int oddIndex = 0;
        int evenIndex = 0;

        // Loop from 1 to the entered number
        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                // Even number
                evenNumbers[evenIndex] = i;
                evenIndex++;
            }
            else
            {
                // Odd number
                oddNumbers[oddIndex] = i;
                oddIndex++;
            }
        }

        // Display odd numbers
        Console.WriteLine("\nOdd numbers:");
        for (int i = 0; i < oddIndex; i++)
        {
            Console.Write(oddNumbers[i] + " ");
        }

        // Display even numbers
        Console.WriteLine("\nEven numbers:");
        for (int i = 0; i < evenIndex; i++)
        {
            Console.Write(evenNumbers[i] + " ");
        }
    }
}
