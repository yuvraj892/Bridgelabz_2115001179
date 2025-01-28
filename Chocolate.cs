using System;
class Chocolate {
    static void Main(string[] args) {
        // Input
        Console.WriteLine("number of chocolates:");
        int noOfChocolates = Convert.ToInt32(Console.ReadLine());
        // Input the number of children
        Console.WriteLine("Enter the number of children:");
        int noOfChildren = Convert.ToInt32(Console.ReadLine());
        // Call the method to find quotient and remainder
        int[] result = RemainderAndQuotient(noOfChocolates, noOfChildren);
        Console.WriteLine("Each child gets: " + result[1] + " chocolates");
        Console.WriteLine("Remaining chocolates: " + result[0]);
    }
    public static int[] RemainderAndQuotient(int num, int div) {
        int rem = num % divisor; // Remaining chocolates
        int quot = number / divisor; // Chocolates each child gets
        return new int[] { rem, quot };
    }
}
