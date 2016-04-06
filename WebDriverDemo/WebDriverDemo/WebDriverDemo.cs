using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace WebDriverDemo
{
    [TestFixture]
    public class UiTests
    {
        [TestCase]
        public void OpenNews()
        {
            FirefoxDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            driver.Navigate().GoToUrl("https://www.google.ru/?gws_rd=ssl");

            IWebElement searchInput = driver.FindElement(By.XPath("//input[@id='lst-ib']"));
            searchInput.Click();
            searchInput.SendKeys("epam");
            searchInput.SendKeys(Keys.Enter);

            IWebElement mostRelevantLink = driver.FindElement(By.XPath("//a[text()='EPAM | Разработка ПО']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(n => mostRelevantLink.Displayed);
            mostRelevantLink.Click();

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            IWebElement testersLink = driver.FindElement(By.XPath("//div[@class='slide']/../../li[2]"));
            wait.Until(n => testersLink.Displayed);
            Actions act = new Actions(driver);
            act.MoveToElement(testersLink).Build().Perform();

            IWebElement testersVacanciesLink = driver.FindElement(By.XPath("//a[text()='ТЕСТИРУЙТЕ ВМЕСТЕ С НАМИ']"));
            wait.Until(n => testersVacanciesLink.Displayed);
            testersVacanciesLink.Click();

            IWebElement hotVacancies = driver.FindElement(By.XPath("//span[@title='Горячие вакансии']"));
            hotVacancies.Click();

            IWebElement locationLabel = driver.FindElement(By.XPath("//div[contains(text(), 'Minsk')]"));
            Actions act2 = new Actions(driver);
            act2.MoveToElement(locationLabel).Build().Perform();
            
        }
    }
}
