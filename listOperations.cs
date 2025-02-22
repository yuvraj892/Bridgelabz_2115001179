using NUnit.Framework;

namespace ListManagerTests
{
    [TestFixture]
    public class ListManagerTests
    {
        private ListManager _listManager;
        private List<int> _testList;

        // Setup method to initialize list manager before each test
        [SetUp]
        public void Setup()
        {
            _listManager = new ListManager();
            _testList = new List<int>();
        }

        // Test for adding element to list
        [Test]
        public void test_AddElement()
        {
            // Arrange
            int element = 5;

            // Act
            _listManager.AddElement(_testList, element);

            // Assert
            Assert.That(_testList.Contains(element), Is.True);
            Assert.That(_testList.Count, Is.EqualTo(1));
        }

        // Test for removing element from list
        [Test]
        public void test_RemoveElement()
        {
            // Arrange
            int element = 5;
            _testList.Add(element);

            // Act
            _listManager.RemoveElement(_testList, element);

            // Assert
            Assert.That(_testList.Contains(element), Is.False);
            Assert.That(_testList.Count, Is.EqualTo(0));
        }

        // Test for getting list size
        [Test]
        public void test_GetSize()
        {
            // Arrange
            _testList.Add(1);
            _testList.Add(2);
            _testList.Add(3);

            // Act
            int size = _listManager.GetSize(_testList);

            // Assert
            Assert.That(size, Is.EqualTo(3));
        }
    }
}
