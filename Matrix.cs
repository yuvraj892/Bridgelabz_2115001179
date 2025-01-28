using System;
class Matrix
{
    static Random rand = new Random();
    // Method to generate a random matrix
    static double[,] GenerateMatrix(int rows, int cols)
    {
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(1, 10); // Random values from 1 to 9
            }
        }
        return matrix;
    }
    // Method to display a matrix
    static void DisplayMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    
    // Method to add two matrices
    static double[,] AddMatrices(double[,] A, double[,] B)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = A[i, j] + B[i, j];
            }
        }
        return result;
    }
    // Method to subtract two matrices
    static double[,] SubtractMatrices(double[,] A, double[,] B)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = A[i, j] - B[i, j];
            }
        }
        return result;
    }
    // Method to multiply two matrices
    static double[,] MultiplyMatrices(double[,] A, double[,] B)
    {
        int rowsA = A.GetLength(0);
        int colsA = A.GetLength(1);
        int colsB = B.GetLength(1);
        double[,] result = new double[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                for (int k = 0; k < colsA; k++)
                {
                    result[i, j] += A[i, k] * B[k, j];
                }
            }
        }
        return result;
    }
    // Method to find the transpose of a matrix
    static double[,] TransposeMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] transpose = new double[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transpose[j, i] = matrix[i, j];
            }
        }
        return transpose;
    }
    // Method to find the determinant of a 2x2 or 3x3 matrix
    static double Determinant(double[,] matrix)
    {
        int size = matrix.GetLength(0);

        if (size == 2)
        {
            return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
        }
        else if (size == 3)
        {
            return matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                 - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                 + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
        }
        else
        {
            throw new Exception("Determinant calculation is supported only for 2x2 and 3x3 matrices.");
        }
    }
    // Method to find the inverse of a 2x2 matrix
    static double[,] InverseMatrix(double[,] matrix)
    {
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            throw new Exception("Inverse calculation is only implemented for 2x2 matrices.");
        }
        double det = Determinant(matrix);
        if (det == 0)
        {
            throw new Exception("Matrix is singular and cannot be inverted.");
        }
        double[,] inverse = new double[2, 2];
        inverse[0, 0] = matrix[1, 1] / det;
        inverse[0, 1] = -matrix[0, 1] / det;
        inverse[1, 0] = -matrix[1, 0] / det;
        inverse[1, 1] = matrix[0, 0] / det;
        return inverse;
    }
    static void Main()
    {
        int rows = 3, cols = 3;
        // Generate two random matrices
        double[,] matrixA = GenerateMatrix(rows, cols);
        double[,] matrixB = GenerateMatrix(rows, cols);
        Console.WriteLine("Matrix A:");
        DisplayMatrix(matrixA);
        Console.WriteLine("Matrix B:");
        DisplayMatrix(matrixB);
        // Addition
        Console.WriteLine("Matrix Addition (A + B):");
        DisplayMatrix(AddMatrices(matrixA, matrixB));
        // Subtraction
        Console.WriteLine("Matrix Subtraction (A - B):");
        DisplayMatrix(SubtractMatrices(matrixA, matrixB));
        // Multiplication
        Console.WriteLine("Matrix Multiplication (A * B):");
        DisplayMatrix(MultiplyMatrices(matrixA, matrixB));
        // Transpose
        Console.WriteLine("Transpose of Matrix A:");
        DisplayMatrix(TransposeMatrix(matrixA));
        if (rows == cols)
        {
            Console.WriteLine("Determinant of Matrix A: " + Determinant(matrixA));
        }
        // Inverse (only for 2x2 matrices)
        if (rows == 2 && cols == 2)
        {
            Console.WriteLine("Inverse of Matrix A:");
            DisplayMatrix(InverseMatrix(matrixA));
        }
    }
}
