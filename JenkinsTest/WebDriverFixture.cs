using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest
{
    public class WebDriverFixture : IDisposable
    {
        public RemoteWebDriver ChromeDriver { get; private set; }
        public WebDriverFixture() 
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("('--ignore-ssl-errors=yes')");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            ChromeDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
        }
        public void Dispose()
        {
            ChromeDriver.Quit();
            ChromeDriver.Dispose();
        }
    }
}
