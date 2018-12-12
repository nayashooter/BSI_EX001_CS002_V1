using System;
using UploadFileTest.Library.Proxy;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Extensions;

namespace UploadFileTest.Library.Driver
{
    public class DriverInternetExplorerUtils
    {
        private readonly IWebDriver _driver;

        public DriverInternetExplorerUtils(ProxyUtils proxy)
        {
            _driver = new InternetExplorerDriver(@"D:\S2H - POLE TEST ET CONFORMITE\Outils\IED\IEDriverServer_x64_3.14.0\", proxy.GetIeOptions());
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
