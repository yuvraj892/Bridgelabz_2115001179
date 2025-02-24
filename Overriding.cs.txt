using System;

namespace Overriding
{
    // Parent class with virtual method
    public class Animal
    {
        // Virtual method that can be overridden
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    // Child class that overrides the parent method
    public class Dog : Animal
    {
        // Override parent class method
        public override void MakeSound()
        {
            Console.WriteLine("Dog says: Woof!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instance of Dog
            Dog dog = new Dog();
            // Call the overridden method
            dog.MakeSound();
        }
    }
}