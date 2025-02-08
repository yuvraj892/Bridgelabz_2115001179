// Base class representing a Person
class Person
{
    // Properties for person details
    public string Name { get; private set; }
    public int Age { get; private set; }

    // Constructor to initialize a person
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Virtual method to display role
    public virtual void DisplayRole()
    {
        Console.WriteLine("This is a person in the school system.");
    }
}