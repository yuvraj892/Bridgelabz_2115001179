using NUnit.Framework;

namespace UserRegistrationTests
{
    [TestFixture]
    public class UserRegistrationTests
    {
        private UserRegistration _registration;

        // Setup method to initialize user registration
        [SetUp]
        public void Setup()
        {
            _registration = new UserRegistration();
        }

        // Test valid user registration
        [Test]
        public void test_ValidRegistration()
        {
            // Arrange
            string username = "validuser";
            string email = "valid@email.com";
            string password = "ValidPass123";

            // Act & Assert
            Assert.DoesNotThrow(() => _registration.RegisterUser(username, email, password));
        }

        // Test invalid username
        [Test]
        public void test_InvalidUsername()
        {
            // Arrange
            string username = "";
            string email = "valid@email.com";
            string password = "ValidPass123";

            // Assert
            Assert.Throws<ArgumentException>(() => 
                _registration.RegisterUser(username, email, password));
        }

        // Test invalid email
        [Test]
        public void test_InvalidEmail()
        {
            // Arrange
            string username = "validuser";
            string email = "invalidemail";
            string password = "ValidPass123";

            // Assert
            Assert.Throws<ArgumentException>(() => 
                _registration.RegisterUser(username, email, password));
        }

        // Test invalid password
        [Test]
        public void test_InvalidPassword()
        {
            // Arrange
            string username = "validuser";
            string email = "valid@email.com";
            string password = "short";

            // Assert
            Assert.Throws<ArgumentException>(() => 
                _registration.RegisterUser(username, email, password));
        }
    }
}
