using System;
public class SumOfNaturalNum
{
	    public static int CalSum(int n)
    {
        int sum = 0;
        // Use a loop to add all numbers
        for (int i = 1; i <= n; i++)
        {
            sum = sum + i;
        }
        return sum;
    }
    public static void Main()
    {
        Console.WriteLine("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Check if the number is valid
        if (n < 1)
        {
            Console.WriteLine("Please enter a positive number!");
        }
        else
        {
            // Call the method to calculate the sum
            int sum = CalSum(n);
            Console.WriteLine("The sum of the first " + n + " natural numbers is: " + sum);
        }
    }   

}
