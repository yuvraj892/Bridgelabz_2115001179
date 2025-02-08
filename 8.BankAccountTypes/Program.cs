// Main Program
using System;
class Program
{
    public static void Main()
    {
        // Creating a SavingsAccount object
        SavingsAccount savings = new SavingsAccount(101, 5000, 3.5);
        savings.DisplayAccountType();

        // Creating a CheckingAccount object
        CheckingAccount checking = new CheckingAccount(102, 3000, 1000);
        checking.DisplayAccountType();

        // Creating a FixedDepositAccount object
        FixedDepositAccount fixedDeposit = new FixedDepositAccount(103, 10000, "1 Year");
        fixedDeposit.DisplayAccountType();
    }
}