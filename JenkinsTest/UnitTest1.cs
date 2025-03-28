using Xunit.Abstractions;

namespace JenkinsTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void PassingTest()
        {
            output.WriteLine("This is passing test!");
            Assert.True(true);
        }
        [Fact]
        public void FailedTest()
        {
            output.WriteLine("This is failing test!");
            Assert.True(false);
        }
    }
}