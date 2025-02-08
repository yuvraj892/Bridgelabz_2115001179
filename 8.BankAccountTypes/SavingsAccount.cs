// Subclass representing a Savings Account
class SavingsAccount : BankAccount
{
    // Additional attribute for savings account
    public double InterestRate { get; private set; }

    // Constructor to initialize a savings account
    public SavingsAccount(int accountNumber, double balance, double interestRate) : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    // Overriding method to display account type
    public override void DisplayAccountType()
    {
        Console.WriteLine($"Savings Account - Account Number: {AccountNumber}, Balance: {Balance}, Interest Rate: {InterestRate}%");
    }
}
