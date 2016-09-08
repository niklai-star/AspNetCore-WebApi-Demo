using Xunit;

namespace WebApiDemo.Test
{
    public class DemoTest
    {
        private readonly DemoModel _demo;

        public DemoTest()
        {
            _demo = new DemoModel();
        }

        [Fact]
        public void AddTest()
        {
            int result = _demo.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void IsOdd(int num)
        {
            bool result = _demo.IsOdd(num);
            Assert.True(result, $"{num} is not odd.");
        }
    }

    public class DemoModel
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public bool IsOdd(int num)
        {
            return num % 2 == 1;
        }
    }
}