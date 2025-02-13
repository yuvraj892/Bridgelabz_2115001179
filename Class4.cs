using System;
using System.Collections.Generic;

class SlidingWindowMaximum
{
    public static List<int> FindMaxInSlidingWindow(int[] nums, int k)
    {
        List<int> result = new List<int>();
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // Remove elements out of the current window
            if (deque.Count > 0 && deque.First.Value == i - k)
            {
                deque.RemoveFirst();
            }

            // Remove all elements smaller than the current element
            while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i])
            {
                deque.RemoveLast();
            }

            // Add the current element index to the deque
            deque.AddLast(i);

            // Add the maximum of the current window to the result
            if (i >= k - 1)
            {
                result.Add(nums[deque.First.Value]);
            }
        }

        return result;
    }

    public static void Display(List<int> arr)
    {
        foreach (int value in arr)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;

        Console.WriteLine("Array:");
        Display(new List<int>(nums));

        List<int> result = FindMaxInSlidingWindow(nums, k);

        Console.WriteLine($"Maximum elements in each sliding window of size {k}:");
        Display(result);
    }
}
