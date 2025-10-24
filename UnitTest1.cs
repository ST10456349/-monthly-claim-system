using Xunit;

namespace MonthlyClaimSystem.Tests
{
    public class SimpleTests
    {
        [Fact]
        public void Test_Addition()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            int result = a + b;

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Test_StringComparison()
        {
            // Arrange
            string expected = "Hello World";

            // Act
            string actual = "Hello " + "World";

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_BooleanLogic()
        {
            // Arrange & Act
            bool isTrue = true;
            bool isFalse = false;

            // Assert
            Assert.True(isTrue);
            Assert.False(isFalse);
        }

        [Fact]
        public void Test_ObjectNotNull()
        {
            // Arrange & Act
            object obj = new object();

            // Assert
            Assert.NotNull(obj);
        }

        [Fact]
        public void Test_CollectionCount()
        {
            // Arrange
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            // Assert
            Assert.Equal(5, numbers.Length);
        }
    }
}