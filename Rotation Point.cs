using System;

class Program
{
    static void Main()
    {
        int[] arr = { 7, 8, 9, 1, 2, 3, 4, 5, 6 }; 

        int rotationIndex = FindRotationPoint(arr);
        Console.WriteLine("The rotation point is at index: " + rotationIndex);
    }

    static int FindRotationPoint(int[] arr)
    {
        int left = 0, right = arr.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;


            if (arr[mid] > arr[right])
                left = mid + 1;
            else
                right = mid;
        }

        return left; 
    }
}
