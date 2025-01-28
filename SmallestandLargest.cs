using System;
class SmallestAndLargest {
    static void Main(string[] args) {
        // ask user input for 3 numbers
        Console.WriteLine("first number:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("second number:");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("third number:");
        int num3 = Convert.ToInt32(Console.ReadLine());
        // Find smallest and largest numbers
        int[] result = arr(num1, num2, num3);
        Console.WriteLine("Smallest number is: " + result[0]);
        Console.WriteLine("Largest number is: " + result[1]);
    }
    public static int[] arr(int num1, int num2, int num3) {
        int smallest = num1;
        int largest = num1;
        // Check for smallest
        if (num2 < smallest) {
            smallest = num2;
        }
        if (num3 < smallest) {
            smallest = num3;
        }
        // Check for largest
        if (num2 > largest) {
            largest = num2;
        }
        if (num3 > largest) {
            largest = num3;
        }
        // Return smallest and largest as an array
        return new int[] { smallest, largest };
    }
}
