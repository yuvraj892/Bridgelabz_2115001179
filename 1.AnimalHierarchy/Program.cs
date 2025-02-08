// Main Program
using System;
class Program
{
    public static void Main()
    {
        // Creating object for a dog
        Dog dog = new Dog("Tommy", 3);
        // Creating object for a cat
        Cat cat = new Cat("Simba", 2);
        // Creating object for a bird
        Bird bird = new Bird("Mitthu", 1);

        // Calling MakeSound method of Dog
        dog.MakeSound();
        // Calling MakeSound method of Cat
        cat.MakeSound();
        // Calling MakeSound method of Bird
        bird.MakeSound();
    }
}
