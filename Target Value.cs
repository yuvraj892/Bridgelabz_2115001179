using System;

class Program
{
    static void Main()
    {
        int[,] matrix =
        {
            { 1, 4, 7, 11 },
            { 2, 5, 8, 12 },
            { 3, 6, 9, 16 },
            { 10, 13, 14, 17 }
        };

        int target = 16;
        bool found = SearchMatrix(matrix, target);

        Console.WriteLine(found ? "Target found in the matrix." : "Target not found.");
    }

    static bool SearchMatrix(int[,] matrix, int target)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int left = 0, right = (rows * cols) - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int midValue = matrix[mid / cols, mid % cols]; 

            if (midValue == target)
                return true;
            else if (midValue < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }
}
