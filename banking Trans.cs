using NUnit.Framework;

namespace BankingTests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount _account;

        // Setup method to initialize bank account
        [SetUp]
        public void Setup()
        {
            _account = new BankAccount();
        }

        // Test deposit functionality
        [Test]
        public void test_Deposit()
        {
            // Arrange
            double amount = 100.00;

            // Act
            _account.Deposit(amount);

            // Assert
            Assert.That(_account.GetBalance(), Is.EqualTo(100.00));
        }

        // Test successful withdrawal
        [Test]
        public void test_Withdraw_Success()
        {
            // Arrange
            _account.Deposit(100.00);

            // Act
            _account.Withdraw(50.00);

            // Assert
            Assert.That(_account.GetBalance(), Is.EqualTo(50.00));
        }

        // Test withdrawal with insufficient funds
        [Test]
        public void test_Withdraw_InsufficientFunds()
        {
            // Arrange
            _account.Deposit(50.00);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(100.00));
        }

        // Test get balance
        [Test]
        public void test_GetBalance()
        {
            // Arrange
            _account.Deposit(75.00);

            // Act
            double balance = _account.GetBalance();

            // Assert
            Assert.That(balance, Is.EqualTo(75.00));
        }
    }
}
