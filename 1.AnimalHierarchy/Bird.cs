// Derived class representing a Bird
class Bird : Animal
{
    // Constructor to initialize Bird using the base class constructor
    public Bird(string name, int age) : base(name, age) { }

    // Overriding MakeSound method to provide specific behavior
    public override void MakeSound()
    {
        Console.WriteLine("Bird chirps.");
    }
}
