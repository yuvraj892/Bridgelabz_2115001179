using System;
using System.Collections.Generic;
using System.Linq;

class BankingSystem
{
    // Account class to store account information
    class Account
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }
        public string AccountType { get; set; }
       
        public override string ToString()
        {
            return String.Format("Account #{0}: {1} ({2}) - Balance: ${3:F2}",
                AccountNumber, CustomerName, AccountType, Balance);
        }
    }
   
    // Withdrawal request class
    class WithdrawalRequest
    {
        public int AccountNumber { get; set; }
        public double Amount { get; set; }
        public DateTime RequestTime { get; set; }
       
        public override string ToString()
        {
            return String.Format("Withdrawal: ${0:F2} from Account #{1} at {2}",
                Amount, AccountNumber, RequestTime.ToString("MM/dd/yyyy HH:mm:ss"));
        }
    }
   
    // Dictionary to store account balances
    private Dictionary<int, Account> accounts;
   
    // Queue to process withdrawal requests
    private Queue<WithdrawalRequest> withdrawalQueue;
   
    // Transaction log
    private List<string> transactionLog;

    public BankingSystem()
    {
        // Initialize collections
        accounts = new Dictionary<int, Account>();
        withdrawalQueue = new Queue<WithdrawalRequest>();
        transactionLog = new List<string>();
    }

    // Create a new account
    public void CreateAccount(int accountNumber, string customerName, double initialDeposit, string accountType)
    {
        // Check if account already exists
        if (accounts.ContainsKey(accountNumber))
        {
            LogTransaction(String.Format("Error: Account #{0} already exists", accountNumber));
            return;
        }
       
        // Create new account
        Account newAccount = new Account
        {
            AccountNumber = accountNumber,
            CustomerName = customerName,
            Balance = initialDeposit,
            AccountType = accountType
        };
       
        // Add to accounts dictionary
        accounts.Add(accountNumber, newAccount);
       
        // Log the transaction
        LogTransaction(String.Format("Created new {0} account #{1} for {2} with initial balance ${3:F2}",
            accountType, accountNumber, customerName, initialDeposit));
    }

    // Deposit money into an account
    public void Deposit(int accountNumber, double amount)
    {
        // Check if the account exists
        if (!accounts.ContainsKey(accountNumber))
        {
            LogTransaction(String.Format("Error: Account #{0} not found", accountNumber));
            return;
        }
       
        // Get the account
        Account account = accounts[accountNumber];
       
        // Update balance
        account.Balance += amount;
       
        // Log transaction
        LogTransaction(String.Format("Deposited ${0:F2} to Account #{1}. New balance: ${2:F2}",
            amount, accountNumber, account.Balance));
    }

    // Request a withdrawal
    public void RequestWithdrawal(int accountNumber, double amount)
    {
        // Check if the account exists
        if (!accounts.ContainsKey(accountNumber))
        {
            LogTransaction(String.Format("Error: Account #{0} not found", accountNumber));
            return;
        }
       
        // Create withdrawal request
        WithdrawalRequest request = new WithdrawalRequest
        {
            AccountNumber = accountNumber,
            Amount = amount,
            RequestTime = DateTime.Now
        };
       
        // Add to withdrawal queue
        withdrawalQueue.Enqueue(request);
       
        // Log transaction
        LogTransaction(String.Format("Withdrawal request for ${0:F2} from Account #{1} queued",
            amount, accountNumber));
    }

    // Process withdrawal requests in queue
    public void ProcessWithdrawalRequests()
    {
        Console.WriteLine("\nProcessing withdrawal requests...");
       
        // Check if queue is empty
        if (withdrawalQueue.Count == 0)
        {
            Console.WriteLine("No withdrawal requests in queue");
            return;
        }
       
        // Process each request in queue
        int requestCount = withdrawalQueue.Count;
        for (int i = 0; i < requestCount; i++)
        {
            // Get next request from queue
            WithdrawalRequest request = withdrawalQueue.Dequeue();
           
            Console.WriteLine(String.Format("Processing: {0}", request));
           
            // Check if account exists
            if (!accounts.ContainsKey(request.AccountNumber))
            {
                LogTransaction(String.Format("Error: Account #{0} not found for withdrawal",
                    request.AccountNumber));
                continue;
            }
           
            // Get the account
            Account account = accounts[request.AccountNumber];
           
            // Check if sufficient funds
            if (account.Balance < request.Amount)
            {
                LogTransaction(String.Format("Error: Insufficient funds in Account #{0}. Requested: ${1:F2}, Available: ${2:F2}",
                    request.AccountNumber, request.Amount, account.Balance));
                continue;
            }
           
            // Process withdrawal
            account.Balance -= request.Amount;
           
            // Log transaction
            LogTransaction(String.Format("Withdrew ${0:F2} from Account #{1}. New balance: ${2:F2}",
                request.Amount, request.AccountNumber, account.Balance));
        }
    }

    // Check account balance
    public double GetBalance(int accountNumber)
    {
        // Check if account exists
        if (!accounts.ContainsKey(accountNumber))
        {
            LogTransaction(String.Format("Error: Account #{0} not found", accountNumber));
            return -1;
        }
       
        // Return balance
        return accounts[accountNumber].Balance;
    }

    // Display accounts sorted by balance
    public void DisplayAccountsSortedByBalance()
    {
        Console.WriteLine("\nAccounts Sorted by Balance (Highest to Lowest):");
        Console.WriteLine("-----------------------------------------------");
       
        // Sort accounts by balance (descending)
        var sortedAccounts = accounts.Values
            .OrderByDescending(a => a.Balance)
            .ToList();
       
        // Display sorted accounts
        foreach (var account in sortedAccounts)
        {
            Console.WriteLine(account);
        }
    }

    // Display accounts by account type
    public void DisplayAccountsByType(string accountType)
    {
        Console.WriteLine(String.Format("\n{0} Accounts:", accountType));
        Console.WriteLine("-----------------------------------------------");
       
        // Filter accounts by type
        var filteredAccounts = accounts.Values
            .Where(a => a.AccountType.Equals(accountType, StringComparison.OrdinalIgnoreCase))
            .OrderBy(a => a.AccountNumber)
            .ToList();
       
        // Check if any accounts found
        if (filteredAccounts.Count == 0)
        {
            Console.WriteLine(String.Format("No {0} accounts found", accountType));
            return;
        }
       
        // Display filtered accounts
        foreach (var account in filteredAccounts)
        {
            Console.WriteLine(account);
        }
    }

    // Log a transaction
    private void LogTransaction(string message)
    {
        // Get current timestamp
        string timestamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
       
        // Create log entry
        string logEntry = String.Format("[{0}] {1}", timestamp, message);
       
        // Add to transaction log
        transactionLog.Add(logEntry);
       
        // Output to console
        Console.WriteLine(logEntry);
    }

    // Display transaction history
    public void DisplayTransactionHistory()
    {
        Console.WriteLine("\nTransaction History:");
        Console.WriteLine("-----------------------------------------------");
       
        // Display each log entry
        foreach (string entry in transactionLog)
        {
            Console.WriteLine(entry);
        }
    }

    // Transfer funds between accounts
    public void TransferFunds(int fromAccountNumber, int toAccountNumber, double amount)
    {
        // Check if source account exists
        if (!accounts.ContainsKey(fromAccountNumber))
        {
            LogTransaction(String.Format("Error: Source account #{0} not found", fromAccountNumber));
            return;
        }
       
        // Check if destination account exists
        if (!accounts.ContainsKey(toAccountNumber))
        {
            LogTransaction(String.Format("Error: Destination account #{0} not found", toAccountNumber));
            return;
        }
       
        // Get accounts
        Account fromAccount = accounts[fromAccountNumber];
        Account toAccount = accounts[toAccountNumber];
       
        // Check if sufficient funds
        if (fromAccount.Balance < amount)
        {
            LogTransaction(String.Format("Error: Insufficient funds in Account #{0}. Requested: ${1:F2}, Available: ${2:F2}",
                fromAccountNumber, amount, fromAccount.Balance));
            return;
        }
       
        // Process transfer
        fromAccount.Balance -= amount;
        toAccount.Balance += amount;
       
        // Log transaction
        LogTransaction(String.Format("Transferred ${0:F2} from Account #{1} to Account #{2}. New balances: ${3:F2}, ${4:F2}",
            amount, fromAccountNumber, toAccountNumber, fromAccount.Balance, toAccount.Balance));
    }
   
    // Calculate interest for savings accounts
    public void CalculateInterest(double interestRate)
    {
        Console.WriteLine(String.Format("\nCalculating interest at {0:P2} for savings accounts...", interestRate));
       
        // Filter for savings accounts
        var savingsAccounts = accounts.Values
            .Where(a => a.AccountType.Equals("Savings", StringComparison.OrdinalIgnoreCase))
            .ToList();
       
        // Apply interest to each savings account
        foreach (var account in savingsAccounts)
        {
            double interestAmount = account.Balance * interestRate;
            account.Balance += interestAmount;
           
            // Log transaction
            LogTransaction(String.Format("Applied interest of ${0:F2} to Account #{1}. New balance: ${2:F2}",
                interestAmount, account.AccountNumber, account.Balance));
        }
    }
   
    // Get total bank assets
    public double GetTotalAssets()
    {
        return accounts.Values.Sum(a => a.Balance);
    }

    static void Main(string[] args)
    {
        // Create instance of banking system
        BankingSystem bank = new BankingSystem();
       
        Console.WriteLine("Welcome to the Banking System!");
        Console.WriteLine("------------------------------\n");
       
        // Create sample accounts
        bank.CreateAccount(1001, "John Smith", 5000.00, "Checking");
        bank.CreateAccount(1002, "Jane Doe", 10000.00, "Savings");
        bank.CreateAccount(1003, "Robert Johnson", 25000.00, "Investment");
        bank.CreateAccount(1004, "Maria Garcia", 7500.00, "Checking");
        bank.CreateAccount(1005, "David Lee", 15000.00, "Savings");
       
        // Perform sample transactions
        bank.Deposit(1001, 1000.00);
        bank.RequestWithdrawal(1002, 500.00);
        bank.RequestWithdrawal(1003, 1000.00);
        bank.RequestWithdrawal(1004, 10000.00); // Insufficient funds
        bank.RequestWithdrawal(1006, 100.00);   // Non-existent account
       
        // Process withdrawal requests
        bank.ProcessWithdrawalRequests();
       
        // Perform transfer between accounts
        bank.TransferFunds(1003, 1001, 2500.00);
       
        // Calculate interest on savings accounts
        bank.CalculateInterest(0.03); // 3% interest
       
        // Display accounts in different ways
        bank.DisplayAccountsSortedByBalance();
        bank.DisplayAccountsByType("Checking");
        bank.DisplayAccountsByType("Savings");
       
        // Display total bank assets
        Console.WriteLine(String.Format("\nTotal Bank Assets: ${0:F2}", bank.GetTotalAssets()));
       
        // Display transaction history
        bank.DisplayTransactionHistory();
       
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
