using NUnit.Framework;

namespace StringUtilsTests
{
    [TestFixture]
    public class StringUtilsTests
    {
        private StringUtils _stringUtils;

        // Setup method to initialize string utils before each test
        [SetUp]
        public void Setup()
        {
            _stringUtils = new StringUtils();
        }

        // Test for string reverse method
        [Test]
        public void test_Reverse()
        {
            // Arrange
            string input = "hello";

            // Act
            string result = _stringUtils.Reverse(input);

            // Assert
            Assert.That(result, Is.EqualTo("olleh"));
        }

        // Test for palindrome check method with palindrome
        [Test]
        public void test_IsPalindrome_True()
        {
            // Arrange
            string input = "radar";

            // Act
            bool result = _stringUtils.IsPalindrome(input);

            // Assert
            Assert.That(result, Is.True);
        }

        // Test for palindrome check method with non-palindrome
        [Test]
        public void test_IsPalindrome_False()
        {
            // Arrange
            string input = "hello";

            // Act
            bool result = _stringUtils.IsPalindrome(input);

            // Assert
            Assert.That(result, Is.False);
        }

        // Test for uppercase conversion method
        [Test]
        public void test_ToUpperCase()
        {
            // Arrange
            string input = "hello";

            // Act
            string result = _stringUtils.ToUpperCase(input);

            // Assert
            Assert.That(result, Is.EqualTo("HELLO"));
        }
    }
}
