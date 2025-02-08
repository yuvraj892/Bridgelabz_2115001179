// Subclass representing a Waiter
class Waiter : Person, IWorker
{
    // Constructor to initialize a waiter
    public Waiter(string name, int id) : base(name, id)
    {
    }

    // Overriding method to display role
    public override void DisplayRole()
    {
        Console.WriteLine($"Waiter - Name: {Name}, ID: {Id}");
    }

    // Implementing PerformDuties method from IWorker interface
    public void PerformDuties()
    {
        Console.WriteLine("Waiter is serving customers.");
    }
}
