
// Derived class representing a Dog
class Dog : Animal
{
    // Constructor to initialize Dog using the base class constructor
    public Dog(string name, int age) : base(name, age) { }

    // Overriding MakeSound method to provide specific behavior
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks.");
    }
}