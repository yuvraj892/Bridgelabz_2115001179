using System;
using System.Collections.Generic;

class PairWithGivenSum
{
    public static bool HasPairWithSum(int[] arr, int targetSum)
    {
        HashSet<int> seenNumbers = new HashSet<int>();

        foreach (int num in arr)
        {
            int complement = targetSum - num;

            // Check if the complement is already in the hash set
            if (seenNumbers.Contains(complement))
            {
                Console.WriteLine($"Pair found: ({complement}, {num})");
                return true;
            }

            // Add the current number to the set
            seenNumbers.Add(num);
        }

        return false;
    }

    public static void Main(string[] args)
    {
        int[] arr = { 1, 4, 7, 12, 5, 9 };
        int targetSum = 16;

        if (!HasPairWithSum(arr, targetSum))
        {
            Console.WriteLine("No pair found with the given sum.");
        }
    }
}
