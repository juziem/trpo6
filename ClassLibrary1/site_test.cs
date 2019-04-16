using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

        //public static void WaitForElementToBecomeVisibleWithinTimeout(IWebDriver driver, IWebElement element, int timeout)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ElementIsVisible(element));
        //}



        [TestCase]
        public void adobe_request()
        {
            webDriver.Url = "https://www.adobe.com/ru/";
            // IWebElement search = webDriver.FindElement(By.XPath("//*[@id=\"AdobePrimaryNav\"]/nav/div[2]/a[1]"));

            //ожидаем до 30сек пока элементы прогрузятся
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));
            //ждать до тех пор пока
            var element = wait.Until(condition =>
            {
                try
                {
                    //если элемент прогрузился и видим, закончить ожидание
                    var elementToBeDisplayed = webDriver.FindElement(By.XPath("//*[@id=\"AdobePrimaryNav\"]/nav/div[2]/a[1]"));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    //ошибка ссылки
                    return false;
                }
                catch (NoSuchElementException)
                {
                    //если такого элемента нет
                    return false;
                }
            });

            //поиск элемента (он точно уже видим)
            IWebElement search = webDriver.FindElement(By.XPath("//*[@id=\"AdobePrimaryNav\"]/nav/div[2]/a[1]"));
            search.Click();

            var waitS = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));
            //ждать до тех пор пока
            var elementS = waitS.Until(condition =>
            {
                try
                {
                    //если элемент прогрузился и видим, закончить ожидание
                    var elementToBeDisplayed = webDriver.FindElement(By.XPath("//*[@id=\"AdobePrimaryNav\"]/nav/div[1]/div/aside/form/input"));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    //ошибка ссылки
                    return false;
                }
                catch (NoSuchElementException)
                {
                    //если такого элемента нет
                    return false;
                }
            });

            IWebElement text = webDriver.FindElement(By.XPath("//*[@id=\"AdobePrimaryNav\"]/nav/div[1]/div/aside/form/input"));
            text.SendKeys("Тест");
            
            var waitB = new WebDriverWait(webDriver, new TimeSpan(0, 0, 60));
            var elementB = waitB.Until(condition =>
            {
                try
                {
                    //если элемент прогрузился и видим, закончить ожидание
                    var elementToBeDisplayed = webDriver.FindElement(By.XPath("//*[@id=\"AdobePrimaryNav\"]/nav/div[1]/div/aside/form/div/svg"));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    //ошибка ссылки
                    return false;
                }
                catch (NoSuchElementException)
                {
                    //если такого элемента нет
                    return false;
                }
            });

            IWebElement bt = webDriver.FindElement(By.XPath("//*[@id=\"AdobePrimaryNav\"]/nav/div[1]/div/aside/form/div/svg"));
            bt.Click();

            //*[@id="AdobePrimaryNav"]/nav/div[1]/div/aside/form/div/svg/path

            //search.SendKeys("Функциональное тестирование");

            //IWebElement bt = webDriver.FindElement(By.XPath("/html/body/main/section/figure[1]/article/section/ul/li[1]/a"));
            //bt.Click();
        }
        ////*[@id="AdobePrimaryNav"]/nav/div[1]/div/aside

        [TestCase]
        public void adobe_link()
        {
            var waitL = new WebDriverWait(webDriver, new TimeSpan(0, 0, 60));
            var elementL = waitL.Until(condition =>
            {
                try
                {
                    //если элемент прогрузился и видим, закончить ожидание
                    var elementToBeDisplayed = webDriver.FindElement(By.XPath("//*[@id=\"Globalnav.copyright.Privacy\"]/a"));
                    return elementToBeDisplayed.Displayed;
                }

                catch (StaleElementReferenceException)
                {
                    //ошибка ссылки
                    return false;
                }
                catch (NoSuchElementException)
                {
                    //если такого элемента нет
                    return false;
                }
            });

            IWebElement bt1 = webDriver.FindElement(By.XPath("//*[@id=\"Globalnav.copyright.Privacy\"]/a"));
            bt1.Click();
        }

        [TearDown]
        public void testEnd()
        {
         //   webDriver.Quit();
        }
    }
}
