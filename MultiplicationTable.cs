using System;
class MultiplicationTable
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine($"Multiplication table of {number} from 6 to 9:");
        for (int i = 6; i <= 9; i++)
        {
            Console.WriteLine($"{number} * {i} = {number * i}");
        }
    }
}
