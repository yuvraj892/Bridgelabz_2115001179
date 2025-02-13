using System;
using System.Collections.Generic;

class ZeroSumSubarrays
{
    public static List<int[]> FindAllZeroSumSubarrays(int[] arr)
    {
        Dictionary<int, List<int>> sumMap = new Dictionary<int, List<int>>();
        List<int[]> result = new List<int[]>();
        int sum = 0;

        // Add initial entry for sum 0 at index -1 to handle subarrays starting at index 0
        sumMap[0] = new List<int> { -1 };

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i]; // Calculate the cumulative sum

            // If the sum is already in the map, it indicates a zero-sum subarray
            if (sumMap.ContainsKey(sum))
            {
                foreach (int startIndex in sumMap[sum])
                {
                    int[] subarray = new int[i - startIndex];
                    Array.Copy(arr, startIndex + 1, subarray, 0, i - startIndex);
                    result.Add(subarray);
                }
            }

            // Add the current index to the list of indices for this sum
            if (!sumMap.ContainsKey(sum))
            {
                sumMap[sum] = new List<int>();
            }
            sumMap[sum].Add(i);
        }

        return result;
    }

    public static void Main(string[] args)
    {
        int[] arr = { 3, 4, -7, 1, 3, -4, -2, 2, 5, -5 };
        List<int[]> zeroSumSubarrays = FindAllZeroSumSubarrays(arr);

        Console.WriteLine("Zero-sum subarrays:");
        foreach (int[] subarray in zeroSumSubarrays)
        {
            Console.WriteLine("[" + string.Join(", ", subarray) + "]");
        }
    }
}
