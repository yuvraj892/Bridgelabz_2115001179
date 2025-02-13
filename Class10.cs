using System;
using System.Collections.Generic;

class Program
{
    public static int[] TwoSum(int[] nums, int target)
    {
        // Dictionary to store the value and its index
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            // Check if the complement exists in the map
            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }

            // Add the current number and its index to the map
            map[nums[i]] = i;
        }

        // If no solution found, return an empty array
        return new int[0];
    }

    static void Main(string[] args)
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        int[] result = TwoSum(nums, target);

        if (result.Length == 2)
        {
            Console.WriteLine($"Indices: {result[0]}, {result[1]}");
        }
        else
        {
            Console.WriteLine("No two numbers add up to the target.");
        }
    }
}
