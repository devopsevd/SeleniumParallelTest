using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumParallelTest
{

    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }


    //[TestFixture]
    public class Hooks : Base
    {
        private BrowserType _browserType;

        public Hooks(BrowserType browserType)
        {
            _browserType = browserType;
        }


        //public Hooks(BrowserType browser)
        //{
        //    _browserType = browser;
        //}

        [SetUp]
        public void InitializeTest()
        {
            ChooseDriverInstance(_browserType);
        }

        private void ChooseDriverInstance(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                //Driver = new ChromeDriver();
                DesiredCapabilities cap = DesiredCapabilities.Chrome();
                cap.SetCapability("version", "");
                cap.SetCapability("platform", "LINUX");
                Driver = new RemoteWebDriver(new Uri("http://10.144.2.237:4444/wd/hub"), cap);
            }
            else if (browserType == BrowserType.Firefox)
            {
                //Driver = new FirefoxDriver();
                DesiredCapabilities cap = DesiredCapabilities.Firefox();
                cap.SetCapability("version", "");
                cap.SetCapability("platform", "LINUX");
                Driver = new RemoteWebDriver(new Uri("http://10.144.2.237:4444/wd/hub"), cap);
            }
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }
                
    }
}
