using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
    public static int FindLongestConsecutiveSequence(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        HashSet<int> numSet = new HashSet<int>(nums);
        int longestStreak = 0;

        foreach (int num in numSet)
        {
            // Check if the current number is the start of a sequence
            if (!numSet.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;

                // Count the length of the sequence
                while (numSet.Contains(currentNum + 1))
                {
                    currentNum += 1;
                    currentStreak += 1;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }

        return longestStreak;
    }

    public static void Main(string[] args)
    {
        int[] nums = { 100, 4, 200, 1, 3, 2 };
        int longestSequence = FindLongestConsecutiveSequence(nums);
        Console.WriteLine("Length of the longest consecutive sequence: " + longestSequence);
    }
}
