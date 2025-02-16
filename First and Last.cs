using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 2, 2, 3, 4, 5, 5, 5, 6 };
        int target = 2;

        int firstOccurrence = FindOccurrence(arr, target, true);
        int lastOccurrence = FindOccurrence(arr, target, false);

        if (firstOccurrence != -1)
            Console.WriteLine($"First occurrence: {firstOccurrence}, Last occurrence: {lastOccurrence}");
        else
            Console.WriteLine("Target not found.");
    }

    static int FindOccurrence(int[] arr, int target, bool findFirst)
    {
        int left = 0, right = arr.Length - 1, result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                result = mid; 
                if (findFirst)
                    right = mid - 1;
                else
                    left = mid + 1; 
            }
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return result;
    }
}
