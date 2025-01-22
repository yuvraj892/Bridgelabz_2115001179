using System;
class chocolate
{
    static void Main()
    {
        Console.Write("Enter the number of chocolates: ");
        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the number of children: ");
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());
        // Calculate chocolates each child gets and the remainder
        int chocolatesPerChild = numberOfChocolates / numberOfChildren;
        int remainingChocolates = numberOfChocolates % numberOfChildren;
        // Output the results
        Console.WriteLine("The number of chocolates each child gets is"+chocolatesPerChild+" and the number of remaining chocolates is "+remainingChocolates);
    }
}
