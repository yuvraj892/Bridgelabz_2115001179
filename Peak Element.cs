using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 3, 20, 4, 1, 0 }; 

        int peakIndex = FindPeakElement(arr);
        Console.WriteLine($"Peak element is {arr[peakIndex]} at index {peakIndex}");
    }

    static int FindPeakElement(int[] arr)
    {
        int left = 0, right = arr.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;


            if (arr[mid] > arr[mid + 1])
                right = mid;
            else
                left = mid + 1;
        }

        return left; 
    }
}
