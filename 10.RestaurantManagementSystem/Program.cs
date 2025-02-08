// Main Program
using System;

class Program
{
    public static void Main()
    {
        // Creating a Chef object
        Chef chef = new Chef("Subhash Gupta", 101);
        chef.DisplayRole();
        chef.PerformDuties();

        // Creating a Waiter object
        Waiter waiter = new Waiter("Chotu", 202);
        waiter.DisplayRole();
        waiter.PerformDuties();
    }
}
