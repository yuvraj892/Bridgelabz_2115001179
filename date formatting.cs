using NUnit.Framework;

namespace DateFormatterTests
{
    [TestFixture]
    public class DateFormatterTests
    {
        private DateFormatter _formatter;

        // Setup method to initialize date formatter
        [SetUp]
        public void Setup()
        {
            _formatter = new DateFormatter();
        }

        // Test valid date format conversion
        [Test]
        public void test_ValidDateFormat()
        {
            // Arrange
            string inputDate = "2024-02-22";

            // Act
            string result = _formatter.FormatDate(inputDate);

            // Assert
            Assert.That(result, Is.EqualTo("22-02-2024"));
        }

        // Test invalid date format
        [Test]
        public void test_InvalidDateFormat()
        {
            // Arrange
            string inputDate = "2024/02/22";

            // Assert
            Assert.Throws<FormatException>(() => _formatter.FormatDate(inputDate));
        }

        // Test invalid date values
        [Test]
        public void test_InvalidDateValues()
        {
            // Arrange
            string inputDate = "2024-13-45";

            // Assert
            Assert.Throws<ArgumentException>(() => _formatter.FormatDate(inputDate));
        }
    }
}