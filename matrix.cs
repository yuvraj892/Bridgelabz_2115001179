using System;

class matrix
{
    static void Main()
    {
        // Get user input for the number of rows and columns
        Console.Write("Enter the number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int columns = Convert.ToInt32(Console.ReadLine());

        // Create a 2D array (matrix)
        int[,] matrix = new int[rows, columns];

        // Take user input to fill the matrix
        Console.WriteLine("\nEnter the elements of the matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Enter element [{i + 1}, {j + 1}]: ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Create a 1D array to store the elements of the 2D array
        int[] oneDArray = new int[rows * columns];
        int index = 0;

        // Copy elements from the 2D array to the 1D array
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                oneDArray[index] = matrix[i, j];
                index++; // Increment the index for the 1D array
            }
        }

        // Display the 1D array
        Console.WriteLine("\nElements copied to the 1D array:");
        for (int i = 0; i < oneDArray.Length; i++)
        {
            Console.Write(oneDArray[i] + " ");
        }
    }
}
