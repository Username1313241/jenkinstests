using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace JenkinsTest
{
    public class UnitTest1 : IClassFixture<WebDriverFixture>
    {
        private readonly ITestOutputHelper output;
        private readonly WebDriverFixture webDriverFixture;
        private readonly RemoteWebDriver chromeDriver;

        public UnitTest1(ITestOutputHelper output, WebDriverFixture webDriverFixture)
        {
            this.output = output;
            this.webDriverFixture = webDriverFixture;
            this.chromeDriver = webDriverFixture.ChromeDriver;
        }

        [Fact]
        public void UITest()
        {
            chromeDriver.Navigate().GoToUrl("http://google.com");
            var searchField = chromeDriver.FindElement(By.CssSelector("textarea[name='q']"));
            Assert.True(searchField.Displayed);
        }

        [Fact]
        public void UIFailingTest()
        {
            chromeDriver.Navigate().GoToUrl("http://google.com");
            var searchField = chromeDriver.FindElement(By.CssSelector("textarea[name='qdfdfdfdf']"));
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