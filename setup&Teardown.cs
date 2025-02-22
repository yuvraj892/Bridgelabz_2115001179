using NUnit.Framework;

namespace DatabaseTests
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        private DatabaseConnection _dbConnection;

        // Setup method runs before each test
        [SetUp]
        public void Setup()
        {
            _dbConnection = new DatabaseConnection();
            _dbConnection.Connect();
        }

        // Teardown method runs after each test
        [TearDown]
        public void Teardown()
        {
            _dbConnection.Disconnect();
        }

        // Test for successful connection
        [Test]
        public void test_Connect()
        {
            // Assert
            Assert.That(_dbConnection.IsConnected, Is.True);
        }

        // Test for successful disconnection
        [Test]
        public void test_Disconnect()
        {
            // Act
            _dbConnection.Disconnect();

            // Assert
            Assert.That(_dbConnection.IsConnected, Is.False);
        }
    }
}
