using System;
class Swapping
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int number1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int number2 = Convert.ToInt32(Console.ReadLine());
        int temp = number1;
        number1 = number2;
        number2 = temp;
        Console.WriteLine("The swapped numbers are "+number1+" and "+number2);
    }
}
