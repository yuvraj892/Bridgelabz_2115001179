// Base class representing a Person
class Person
{
    // Properties for person details
    public string Name { get; private set; }
    public int Id { get; private set; }

    // Constructor to initialize a person
    public Person(string name, int id)
    {
        Name = name;
        Id = id;
    }

    // Virtual method to display role
    public virtual void DisplayRole()
    {
        Console.WriteLine("This is a person in the restaurant system.");
    }
}