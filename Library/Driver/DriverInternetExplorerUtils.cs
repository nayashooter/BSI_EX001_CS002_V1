using System;
using UploadFileTest.Library.Proxy;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace UploadFileTest.Library.Driver
{
    public class DriverInternetExplorerUtils
    {
        private readonly IWebDriver _driver;

        public DriverInternetExplorerUtils(ProxyUtils proxy)
        {
            _driver = new InternetExplorerDriver(proxy.GetIeOptions());
        }

        public IWebDriver GetDriverInternet()
        {
            return _driver;
        }

        public void Wait(int during)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(during);
        }
    }
}
