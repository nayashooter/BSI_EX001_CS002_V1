using UploadFileTest.Library.Driver;
using UploadFileTest.Library.Proxy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace UploadFileTest
{
    [TestFixture]
    public class TestClass
    {
        private DriverInternetExplorerUtils _driverIe;
        private ProxyUtils _proxy;

        [SetUp]
        public void Initialize()
        {
            _proxy = new ProxyUtils("inetproxy:83");
            _driverIe = new DriverInternetExplorerUtils(_proxy);
            _driverIe.GetDriverInternet().Manage().Window.Maximize();
        }


        [Test]
        public void TestMethod()
        {
            _driverIe.Wait(10);

            // se rend à la page www.google.fr
            _driverIe.GetDriverInternet().Navigate().GoToUrl("http://nervgh.github.io/pages/angular-file-upload/examples/simple/");
            _driverIe.Wait(10);

            //_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Click();
            //_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Clear();
            string File = AppDomain.CurrentDomain.BaseDirectory + "callapp.png";

            var inputFile = _driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]"));
            _driverIe.Wait(50);
            inputFile.SendKeys(File);
            _driverIe.Wait(50);
            _driverIe.GetDriverInternet().FindElement(By.XPath("(//button[@type='button'])[4]")).Click();

            Assert.IsTrue(true);
        }

        [TearDown]
        public void EndTest()
        {
            if (_driverIe.GetDriverInternet() != null)
            {
                _driverIe.GetDriverInternet().Close();
            }
        }
    }
}
