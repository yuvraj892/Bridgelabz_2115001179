// Subclass representing a Chef
class Chef : Person, IWorker
{
    // Constructor to initialize a chef
    public Chef(string name, int id) : base(name, id)
    {
    }

    // Overriding method to display role
    public override void DisplayRole()
    {
        Console.WriteLine($"Chef - Name: {Name}, ID: {Id}");
    }

    // Implementing PerformDuties method from IWorker interface
    public void PerformDuties()
    {
        Console.WriteLine("Chef is preparing delicious meals.");
    }
}

