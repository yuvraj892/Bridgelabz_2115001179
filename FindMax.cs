using System;
class FindMax
{
    static void Main()
    {
        int num1 = GetInput("Enter the first number: ");
        int num2 = GetInput("Enter the second number: ");
        int num3 = GetInput("Enter the third number: ");
        int max = FindMaximum(num1, num2, num3);
        // Display the result
        Console.WriteLine("The maximum of the three numbers is: "+ max);
    }
    static int GetInput(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }
    // Function to find the maximum of three numbers
    static int FindMaximum(int a, int b, int c)
    {
        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;
        return max;
    }
}
