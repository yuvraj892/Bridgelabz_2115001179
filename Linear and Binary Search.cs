using System;

class Program
{
    static void Main()
    {
        int[] arr = { 3, 4, -1, 1 };
        int target = 3;

        // Find the first missing positive integer using Linear Search
        int missing = FindFirstMissingPositive(arr);
        Console.WriteLine($"First missing positive integer: {missing}");

        // Sort the array before Binary Search
        Array.Sort(arr);
        int index = BinarySearch(arr, target);
        Console.WriteLine(index != -1 ? $"Target {target} found at index {index}" : "Target not found.");
    }

    // Function to find the first missing positive integer using Linear Search
    static int FindFirstMissingPositive(int[] nums)
    {
        int n = nums.Length;

       
        for (int i = 0; i < n; i++)
        {
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
            {
                Swap(nums, i, nums[i] - 1);
             
            }
        }

    
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i + 1)
                return i + 1;
        }

        return n + 1; // If all are in place, return next possible positive number
    }

    // Function to perform Binary Search on sorted array
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    // Helper function to swap elements
    static void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
