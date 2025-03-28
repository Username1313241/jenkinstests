namespace JenkinsTest
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.True(true);
        }
        [Fact]
        public void FailedTest()
        {
            Assert.True(false);
        }
    }
}