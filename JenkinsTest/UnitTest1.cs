using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace JenkinsTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;
        private readonly ChromeDriver chromeDriver;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
            var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            chromeDriver = new ChromeDriver();
        }

        [Fact]
        public void UITest()
        {
            chromeDriver.Navigate().GoToUrl("http://google.com");
            var searchField = chromeDriver.FindElement(By.CssSelector("textarea[name='q']"));
            Assert.True(searchField.Displayed);
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