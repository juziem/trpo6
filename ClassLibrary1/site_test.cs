using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary1
{
    [TestFixture]
    class site_test
    {
        IWebDriver webDriver = new ChromeDriver();

        [TestCase]
        public void mainTitle()
        {
            webDriver.Url = "https://www.adobe.com/ru/";
            Assert.AreEqual("Adobe Россия: решения для творчества, маркетинга и работы с документами", webDriver.Title);
            webDriver.Close();
        }



        [TearDown]
        public void testEnd()
        {
            webDriver.Quit();
        }
    }
}
