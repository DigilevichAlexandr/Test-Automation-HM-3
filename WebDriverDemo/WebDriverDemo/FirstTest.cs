using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace WebDriverDemo
{
    public class FirstTest
    {
        [Test]
        public void MainTestFirst()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.ru/?gws_rd=ssl");
            
            IWebElement searchInput = driver.FindElement(By.XPath("//input[@id='lst-ib']"));
            searchInput.SendKeys("epam");
            searchInput.SendKeys(Keys.Enter); 

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            IWebElement firstLink = driver.FindElement(By.XPath("//a[text()='EPAM | Разработка ПО']"));
            firstLink.Click();

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            IWebElement testersBlock = driver.FindElement(By.XPath("//a[text()='ТЕСТИРУЙТЕ ВМЕСТЕ С НАМИ']/../../../.."));
            Actions act = new Actions(driver);
            act.MoveToElement(testersBlock).Build().Perform();

            IWebElement testersLink = driver.FindElement(By.XPath("//a[text()='ТЕСТИРУЙТЕ ВМЕСТЕ С НАМИ']"));
            testersLink.Click();

            IWebElement hotVacancies = driver.FindElement(By.XPath("//span[@title='Горячие вакансии']"));
            hotVacancies.Click();

            IWebElement minskText = driver.FindElement(By.XPath("//*[contains(text(), 'Minsk')]"));
            Actions act2 = new Actions(driver);
            act2.MoveToElement(minskText).Build().Perform();


        }
    }
}
