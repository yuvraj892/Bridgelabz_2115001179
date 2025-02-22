using NUnit.Framework;

namespace FileProcessorTests
{
    [TestFixture]
    public class FileProcessorTests
    {
        private FileProcessor _fileProcessor;
        private string _testFileName;
        private string _testContent;

        // Setup method to initialize file processor
        [SetUp]
        public void Setup()
        {
            _fileProcessor = new FileProcessor();
            _testFileName = "test.txt";
            _testContent = "Hello, World!";
        }

        // Test for writing to file
        [Test]
        public void test_WriteToFile()
        {
            // Act
            _fileProcessor.WriteToFile(_testFileName, _testContent);

            // Assert
            Assert.That(File.Exists(_testFileName), Is.True);
        }

        // Test for reading from file
        [Test]
        public void test_ReadFromFile()
        {
            // Arrange
            _fileProcessor.WriteToFile(_testFileName, _testContent);

            // Act
            string result = _fileProcessor.ReadFromFile(_testFileName);

            // Assert
            Assert.That(result, Is.EqualTo(_testContent));
        }

        // Test for reading non-existent file
        [Test]
        public void test_ReadNonExistentFile()
        {
            // Assert
            Assert.Throws<IOException>(() => _fileProcessor.ReadFromFile("nonexistent.txt"));
        }

        // Cleanup after tests
        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(_testFileName))
            {
                File.Delete(_testFileName);
            }
        }
    }
}
