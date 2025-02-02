using System;
class BankAccount
{
    // Public: Can be accessed from anywhere
    public string accNum;

    // Protected: Can be accessed within this class and by subclasses
    protected string accHolder;

    // Private: Can only be accessed inside this class
    private double balance;

    // Constructor to initialize account details
    public BankAccount(string accNum, string accHolder, double balance)
    {
        this.accNum = accNum;
        this.accHolder = accHolder;
        this.balance = balance;
    }

    // Public method to get balance
    public double GetBalance()
    {
        return balance;
    }

    // Public method to deposit money
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited: ${amount}. New Balance: ${balance}");
        }
        else
        {
            Console.WriteLine("Amount must be positive!");
        }
    }

    // Public method to withdraw money
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew: ${amount}. New Balance: ${balance}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount!");
        }
    }

    // Method to display account details
    public void DisplayAccountDetails()
    {
        Console.WriteLine("Account Number: " + accNum);
        Console.WriteLine("Account Holder: " + accHolder);
        Console.WriteLine("Balance: $" + balance);
    }
}

// Subclass demonstrating protected and public access
class SavingsAccount : BankAccount
{
    private double interestRate; // Interest rate for the savings account

    // Constructor
    public SavingsAccount(string accNum, string accHolder, double balance, double interestRate)
        : base(accNum, accHolder, balance)  // Calling base class constructor
    {
        this.interestRate = interestRate;
    }

    // Method to display savings account details
    public void DisplaySavingsAccountDetails()
    {
        Console.WriteLine("Account Number: " + accNum);  // Accessing public member
        Console.WriteLine("Account Holder: " + accHolder);  // Accessing protected member
        Console.WriteLine("Interest Rate: " + interestRate + "%");
    }

    // Method to calculate interest
    public void CalculateInterest()
    {
        double interest = (GetBalance() * interestRate) / 100;
        Console.WriteLine($"Interest: ${interest} at {interestRate}% rate.");
    }
}

class Account
{
    static void Main()
    {
        // Creating a BankAccount object
        BankAccount account1 = new BankAccount("123456789", "yuvraj", 1000);
        Console.WriteLine("Bank Account Details:");
        account1.DisplayAccountDetails();

        // Deposit and withdraw money
        account1.Deposit(500);
        account1.Withdraw(200);

        // Creating a SavingsAccount object
        SavingsAccount savingsAccount = new SavingsAccount("987654321", "Bharat", 1500, 5);
        Console.WriteLine("\nSavings Account Details:");
        savingsAccount.DisplaySavingsAccountDetails();
        savingsAccount.CalculateInterest();
    }
}
