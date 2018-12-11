using UploadFileTest.Library.Driver;
using UploadFileTest.Library.Proxy;
using NUnit.Framework;
using OpenQA.Selenium;

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
            _driverIe = new DriverInternetExplorerUtils(@"D:\S2H - POLE TEST ET CONFORMITE\Outils\IED\IEDriverServer_Win32_3.14.0\", _proxy);
            _driverIe.GetDriverInternet().Manage().Window.Maximize();
        }


        [Test]
        public void TestMethod()
        {
            _driverIe.Wait(10);

            // se rend à la page www.google.fr
            _driverIe.GetDriverInternet().Navigate().GoToUrl("http://nervgh.github.io/pages/angular-file-upload/examples/simple/");
            _driverIe.Wait(20);

            //_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Click();
            //_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Clear();
            _driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).SendKeys(@"D:\S2H - POLE TEST ET CONFORMITE\Workspace\NUnit\UploadFileTest\Data\Files\callapp.png");
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
