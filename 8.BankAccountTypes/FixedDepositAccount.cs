// Subclass representing a Fixed Deposit Account
class FixedDepositAccount : BankAccount
{
    // Additional attribute for fixed deposit account
    public string Duration { get; private set; }

    // Constructor to initialize a fixed deposit account
    public FixedDepositAccount(int accountNumber, double balance, string duration) : base(accountNumber, balance)
    {
        Duration = duration;
    }

    // Overriding method to display account type
    public override void DisplayAccountType()
    {
        Console.WriteLine($"Fixed Deposit Account - Account Number: {AccountNumber}, Balance: {Balance}, Duration: {Duration}");
    }
}
