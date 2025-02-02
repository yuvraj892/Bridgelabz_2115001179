using System;
class Person
{
    private string name;
    private int age;
    // Default constructor
    public Person()
    {
        name = "Unknown";
        age = 0;
    }

    // Parameterized constructor
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Copy constructor
    public Person(Person other)
    {
        this.name = other.name;
        this.age = other.age;
    }

    // Method to display person details
    public void DisplayPerson()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
    }
}
class CopyConstructor
{
    static void Main()
    {
        Person p1 = new Person("Yuvraj", 22);  // Original person
        Person p2 = new Person(p1);  // Cloned person (copy constructor)

        Console.WriteLine("Original Person:");
        p1.DisplayPerson();

        Console.WriteLine("\nCloned Person:");
        p2.DisplayPerson();
    }
}
