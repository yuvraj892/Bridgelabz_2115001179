using System;

class NestedTryCatch
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Enter the size of the array:");
            int size = int.Parse(Console.ReadLine());

            int[] arr = new int[size];

            Console.WriteLine("Enter the array elements:");
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the index of the element to divide:");
            int index = int.Parse(Console.ReadLine());

            try
            {
                int element = arr[index]; 
                
                Console.WriteLine("Enter the divisor:");
                int divisor = int.Parse(Console.ReadLine());

                try
                {
                    int result = element / divisor; 
                    Console.WriteLine("Result: " + result);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid array index!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter only integers.");
        }
    }
}
