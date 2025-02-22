using NUnit.Framework;

namespace TemperatureConverterTests
{
    [TestFixture]
    public class TemperatureConverterTests
    {
        private TemperatureConverter _converter;

        // Setup method to initialize temperature converter
        [SetUp]
        public void Setup()
        {
            _converter = new TemperatureConverter();
        }

        // Test Celsius to Fahrenheit conversion
        [Test]
        public void test_CelsiusToFahrenheit()
        {
            // Arrange
            double celsius = 0;

            // Act
            double result = _converter.CelsiusToFahrenheit(celsius);

            // Assert
            Assert.That(result, Is.EqualTo(32));
        }

        // Test Fahrenheit to Celsius conversion
        [Test]
        public void test_FahrenheitToCelsius()
        {
            // Arrange
            double fahrenheit = 32;

            // Act
            double result = _converter.FahrenheitToCelsius(fahrenheit);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        // Test boiling point conversion
        [Test]
        public void test_BoilingPoint()
        {
            // Arrange
            double celsius = 100;

            // Act
            double result = _converter.CelsiusToFahrenheit(celsius);

            // Assert
            Assert.That(result, Is.EqualTo(212));
        }
    }
}