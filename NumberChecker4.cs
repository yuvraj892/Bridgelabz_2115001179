using System;
class NumberChecker4
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        //Check if the number is prime
        bool isPrime = IsPrime(number);
        Console.WriteLine($"Is the number a prime number? {isPrime}");
        //Check if the number is a neon number
        bool isNeon = IsNeonNumber(number);
        Console.WriteLine($"Is the number a neon number? {isNeon}");
        //Check if the number is a spy number
        bool isSpy = skyNum(number);
        Console.WriteLine($"Is the number a spy number? {isSpy}");
        //Check if the number is an automorphic number
        bool isAutomorphic = automorphic(number);
        Console.WriteLine($"Is the number an automorphic number? {isAutomorphic}");
        //Check if the number is a buzz number
        bool isBuzz = IsBuzzNumber(number);
        Console.WriteLine($"Is the number a buzz number? {isBuzz}");
    }
    //Method to check if a number is a prime number
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
    //Method to check if a number is a neon number
    public static bool IsNeonNumber(int number)
    {
        int square = number * number;
        int sumOfDigits = 0;
        while (square > 0)
        {
            sumOfDigits += square % 10;
            square /= 10;
        }
        return sumOfDigits == number;
    }
    //Method to check if a number is a spy number
    public static bool skyNum(int number)
    {
        int sum = 0, product = 1;
        while (number > 0)
        {
            int digit = number % 10;
            sum += digit;
            product *= digit;
            number /= 10;
        }
        return sum == product;
    }
    //Method to check if a number is an automorphic number
    public static bool automorphic(int number)
    {
        int square = number * number;
        string numStr = number.ToString();
        string squareStr = square.ToString();
        return squareStr.EndsWith(numStr);
    }
    //Method to check if a number is a buzz number
    public static bool IsBuzzNumber(int number)
    {
        return number % 7 == 0 || number % 10 == 7;
    }
}