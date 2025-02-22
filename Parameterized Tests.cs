using NUnit.Framework;

namespace NumberTests
{
    [TestFixture]
    public class EvenNumberTests
    {
        private NumberChecker _numberChecker;

        // Setup method to initialize number checker
        [SetUp]
        public void Setup()
        {
            _numberChecker = new NumberChecker();
        }

        // Test multiple values for even number check
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(6)]
        public void test_IsEven_True(int number)
        {
            // Act
            bool result = _numberChecker.IsEven(number);

            // Assert
            Assert.That(result, Is.True);
        }

        // Test multiple values for odd number check
        [TestCase(7)]
        [TestCase(9)]
        public void test_IsEven_False(int number)
        {
            // Act
            bool result = _numberChecker.IsEven(number);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
