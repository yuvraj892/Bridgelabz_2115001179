using NUnit.Framework;

namespace DivisionTests
{
    [TestFixture]
    public class DivisionTests
    {
        private MathOperations _mathOperations;

        // Setup method to initialize math operations before each test
        [SetUp]
        public void Setup()
        {
            _mathOperations = new MathOperations();
        }

        // Test for successful division
        [Test]
        public void test_DivideSuccess()
        {
            // Arrange
            int a = 10;
            int b = 2;

            // Act
            int result = _mathOperations.Divide(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        // Test for division by zero exception
        [Test]
        public void test_DivideByZeroException()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Assert
            Assert.Throws<ArithmeticException>(() => _mathOperations.Divide(a, b));
        }
    }
}
