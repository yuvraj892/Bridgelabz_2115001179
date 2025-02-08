// Subclass representing a Checking Account
class CheckingAccount : BankAccount
{
    // Additional attribute for checking account
    public double WithdrawalLimit { get; private set; }

    // Constructor to initialize a checking account
    public CheckingAccount(int accountNumber, double balance, double withdrawalLimit) : base(accountNumber, balance)
    {
        WithdrawalLimit = withdrawalLimit;
    }

    // Overriding method to display account type
    public override void DisplayAccountType()
    {
        Console.WriteLine($"Checking Account - Account Number: {AccountNumber}, Balance: {Balance}, Withdrawal Limit: {WithdrawalLimit}");
    }
}