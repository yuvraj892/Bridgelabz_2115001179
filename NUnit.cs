using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        // Setup method to initialize calculator before each test
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        // Test for addition method
        [Test]
        public void test_Add()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        // Test for subtraction method
        [Test]
        public void test_Subtract()
        {
            // Arrange
            int a = 10;
            int b = 4;

            // Act
            int result = _calculator.Subtract(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(6));
        }

        // Test for multiplication method
        [Test]
        public void test_Multiply()
        {
            // Arrange
            int a = 6;
            int b = 4;

            // Act
            int result = _calculator.Multiply(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(24));
        }

        // Test for division method
        [Test]
        public void test_Divide()
        {
            // Arrange
            int a = 10;
            int b = 2;

            // Act
            int result = _calculator.Divide(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        // Test for division by zero
        [Test]
        public void test_DivideByZero()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
        }
    }
}
