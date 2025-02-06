//Main
using System;
using System.Collections.Generic;
class BankAccountinfo
{
    static void Main()
    {
        // Creating bank object
        Bank bank1 = new Bank("National Bank");

        // Creating customers
        Customer customer1 = new Customer("Yuvraj Srivastvava");
        Customer customer2 = new Customer("Prasoon Shah");
        // Opening accounts for customers
        bank1.OpenAcc(customer1, 8000);
        bank1.OpenAcc(customer2, 6000);
        bank1.DisplayCustomers();
    }
}
//Class Bank
using System;
using System.Collections.Generic;
class Bank
{
    // Stores the bank's name
    public string Name { get; set; }

    // List of customers associated with the bank
    public List<Customer> Customers { get; set; } = new List<Customer>();

    // Constructor to initialize the bank with a name
    public Bank(string name)
    {
        Name = name;
    }
    // Opens a new account for a customer with an initial balance
    public void OpenAcc(Customer customer, double initialBalance)
    {
        Account newAcc = new Account(this, initialBalance); // Creates a new account linked to this bank
        customer.AddAccount(newAcc); // Adds the account to the customer

        // If the customer is not already registered with the bank, add them
        if (!Customers.Contains(customer))
        {
            Customers.Add(customer);
        }
    }

    // Displays all customers and their account details
    public void DisplayCustomers()
    {
        Console.WriteLine($"Bank: {Name}");
        // Loop through each customer and display their details
        foreach (var customer in Customers)
        {
            customer.ViewBalance();
        }
    }
}
//Class Customer
using System;
using System.Collections.Generic;



// Represents a bank customer who owns multiple accounts
class Customer
{
    // Stores the customer's name
    public string Name { get; set; }

    // List of accounts associated with the customer
    public List<Account> Accounts { get; set; } = new List<Account>();

    // Constructor to initialize the customer with a name
    public Customer(string name)
    {
        Name = name;
    }
    // Adds a new account to the customer's account list
    public void AddAccount(Account account)
    {
        Accounts.Add(account);
    }


    // Displays the customer's name and all associated account balances
    public void ViewBalance()
    {
        Console.WriteLine($"Customer: {Name}");
        // Loop through each account and display its details
        foreach (var account in Accounts)
        {
            account.Display();
        }
    }
}

//Class Account
using System;
// Represents a bank account that links a customer to a bank
class Account
{
    // The bank where this account is held
    public Bank Bank { get; set; }

    // The current balance in the account
    public double Balance { get; set; }

    // Constructor to initialize an account with a bank and an initial balance
    public Account(Bank bank, double initialBalance)
    {
        Bank = bank;
        Balance = initialBalance;
    }

    // Displays account details, including the bank name and balance
    public void Display()
    {
        Console.WriteLine($"Bank: {Bank.Name}, Balance: Rs.{Balance}");
    }
}
