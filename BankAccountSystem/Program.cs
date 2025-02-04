using System;

class BankAccount
{
    private static int totalAccounts = 0;
    public static string bankName = "Global Bank";
    public readonly int AccountNumber;
    public string AccountHolderName;

    public BankAccount(string AccountHolderName, int AccountNumber)
    {
        this.AccountHolderName = AccountHolderName;
        this.AccountNumber = AccountNumber;
        totalAccounts++;
    }

    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts: " + totalAccounts);
    }

    public void DisplayAccountDetails()
    {
        if (this is BankAccount)
        {
            Console.WriteLine("Bank Name: " + bankName);
            Console.WriteLine("Account Holder: " + AccountHolderName);
            Console.WriteLine("Account Number: " + AccountNumber);
        }
    }

    static void Main()
    {
        Console.Write("Enter account holder name: ");
        string name1 = Console.ReadLine();
        Console.Write("Enter account number: ");
        int number1 = int.Parse(Console.ReadLine());

        Console.Write("Enter account holder name: ");
        string name2 = Console.ReadLine();
        Console.Write("Enter account number: ");
        int number2 = int.Parse(Console.ReadLine());

        BankAccount acc1 = new BankAccount(name1, number1);
        BankAccount acc2 = new BankAccount(name2, number2);

        acc1.DisplayAccountDetails();
        acc2.DisplayAccountDetails();

        BankAccount.GetTotalAccounts();
    }
}
