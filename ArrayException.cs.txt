using System;

class ArrayException
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the size of the array: ");
            int size = int.Parse(Console.ReadLine());

            int[] arr = new int [size];

            Console.WriteLine("Enter the array elements: ");
            for(int i = 0 ; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the index to find the element: ");
            int index = int.Parse(Console.ReadLine());

            Console.WriteLine("Value at index " + index + ": " + arr[index]);
        }
        catch(IndexOutOfRangeException )
        {
            Console.WriteLine("Invalid Index");
        }
        catch(NullReferenceException )
        {
            Console.WriteLine("Array is not initialized");
        }
    }
}