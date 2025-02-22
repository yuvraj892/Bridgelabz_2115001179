using NUnit.Framework;

namespace PerformanceTests
{
    [TestFixture]
    public class LongRunningTaskTests
    {
        private TaskManager _taskManager;

        // Setup method to initialize task manager
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }

        // Test with timeout attribute
        [Test]
        [Timeout(2000)]
        public void test_LongRunningTask()
        {
            // Act
            string result = _taskManager.LongRunningTask();

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
