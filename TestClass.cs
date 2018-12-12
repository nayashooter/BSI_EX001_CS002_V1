using UploadFileTest.Library.Driver;
using UploadFileTest.Library.Proxy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace UploadFileTest
{
    [TestFixture]
    public class TestClass
    {
        //private DriverInternetExplorerUtils _driverIe;
        //private ProxyUtils _proxy;


        private IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            //_proxy = new ProxyUtils("inetproxy:83");
            //_driverIe = new DriverInternetExplorerUtils(_proxy);
            //_driverIe.GetDriverInternet().Manage().Window.Maximize();
            var _proxyInstance = new OpenQA.Selenium.Proxy { HttpProxy = "inetproxy:83", SslProxy = "inetproxy:83", Kind = ProxyKind.Manual, IsAutoDetect = false };

            var options = new InternetExplorerOptions
            {
                Proxy = _proxyInstance,
                EnsureCleanSession = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true
            };


            driver = new RemoteWebDriver(new Uri("http://localhost:62750"), options);

        }


        [Test]
        public void TestMethod()
        {
            driver.Url = "http://nervgh.github.io/pages/angular-file-upload/examples/simple/";
            string File = "Y:\\Mes Documents\\Mes Images\\callapp.png";


            var inputFile = driver.FindElement(By.XPath("(//input[@type='file'])[2]"));
            inputFile.SendKeys(File);
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();

            Assert.IsTrue(true);



            //_driverIe.Wait(10);

            //// se rend à la page www.google.fr
            //_driverIe.GetDriverInternet().Navigate().GoToUrl("http://nervgh.github.io/pages/angular-file-upload/examples/simple/");
            //_driverIe.Wait(10);

            ////_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Click();
            ////_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Clear();
            //string File = "Y:\\Mes Documents\\Mes Images\\callapp.png";


            //var inputFile = _driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]"));
            //_driverIe.Wait(500);
            //inputFile.SendKeys(File);
            //_driverIe.Wait(50);
            //_driverIe.GetDriverInternet().FindElement(By.XPath("(//button[@type='button'])[4]")).Click();

            //Assert.IsTrue(true);
        }

        [TearDown]
        public void EndTest()
        {
            //if (_driverIe.GetDriverInternet() != null)
            //{
            //    _driverIe.GetDriverInternet().Close();
            //}

            if (driver != null)
            {
                driver.Close();
            }
        }
    }
}
