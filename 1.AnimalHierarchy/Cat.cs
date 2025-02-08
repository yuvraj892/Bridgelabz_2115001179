// Derived class representing a Cat
class Cat : Animal
{
    // Constructor to initialize Cat using the base class constructor
    public Cat(string name, int age) : base(name, age) { }

    // Overriding MakeSound method to provide specific behavior
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows.");
    }
}