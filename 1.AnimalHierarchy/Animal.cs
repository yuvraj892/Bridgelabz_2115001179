
// Base class representing a general Animal
class Animal
{
    // Properties to store name and age of the animal
    public string Name { get; private set; }
    public int Age { get; private set; }

    // Constructor to initialize the animal with a name and age
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Virtual method to be overridden by subclasses (provides a default sound message)
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound.");
    }
}