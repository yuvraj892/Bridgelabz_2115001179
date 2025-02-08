// Base class representing a Bank Account
class BankAccount
{
    // Properties for account details
    public int AccountNumber { get; private set; }
    public double Balance { get; private set; }

    // Constructor to initialize a bank account
    public BankAccount(int accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    // Virtual method to display account type
    public virtual void DisplayAccountType()
    {
        Console.WriteLine("This is a general bank account.");
    }
}
