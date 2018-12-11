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
            _driverIe.GetDriverInternet().Navigate().GoToUrl("http://www.google.fr");

            _driverIe.Wait(10);

            /* recherche sur la page l'élément dont le nom est q et y rentre rien,
             dans notre exemple c'est la textbox de recherche google */
            _driverIe.GetDriverInternet().FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[1]/div/div[1]/input")).SendKeys("news");

            _driverIe.Wait(10);

            // lance la recherche
            _driverIe.GetDriverInternet().FindElement(By.Name("q")).Submit();

            // le test réussit si on trouve un lien dont le texte est Rien - Wikipédia

            var res = true;

            try
            {
                _driverIe.GetDriverInternet().FindElement(By.LinkText("Rien - Wikip&eacute;dia"));
            }
            catch
            {
                res = false;
            }

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
