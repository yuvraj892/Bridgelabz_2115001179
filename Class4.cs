using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class BankAccountS
{
    protected int AccountNumber;
    protected string HolderName;
    protected double Balance;

    public BankAccountS(int accountNumber, string holderName, double balance)
    {
        AccountNumber = accountNumber;
        HolderName = holderName;
        Balance = balance;
    }

    public void Deposit(double amount) => Balance += amount;
    public void Withdraw(double amount) => Balance -= amount;
    public abstract double CalculateInterest();
}

interface ILoanable
{
    bool ApplyForLoan(double amount);
    double CalculateLoanEligibility();
}

class SavingsAccountS : BankAccountS, ILoanable
{
    public SavingsAccountS(int accountNumber, string holderName, double balance) : base(accountNumber, holderName, balance) { }
    public override double CalculateInterest() => Balance * 0.04;
    public bool ApplyForLoan(double amount) => Balance > 5000;
    public double CalculateLoanEligibility() => Balance * 10;
}

// Main Program
class Program
{
    static void Main()
    {
        BankAccountS acc = new SavingsAccountS(101, "John Doe", 10000);
        Console.WriteLine($"Interest Earned: {acc.CalculateInterest()}");
    }
