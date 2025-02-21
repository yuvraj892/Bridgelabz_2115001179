using System;

class CustomException : Exception
{
    public CustomException(string message) : base(message){}
}

class AgeChcker
{
    public static void CheckAge(int age)
    {
        if(age < 18)
        {
            throw new CustomException("Age must be 18 or older");
        }
        Console.WriteLine("Access Granted");
    }
}

class Program
{
    public static void Main(string[] args)
    {
       try
       {
            Console.WriteLine("Enter the age: ");
            int age = int.Parse(Console.ReadLine());
            AgeChcker.CheckAge(age);
       }
       catch(CustomException ex)
       {
        Console.WriteLine(ex.Message);
       }
    }
}