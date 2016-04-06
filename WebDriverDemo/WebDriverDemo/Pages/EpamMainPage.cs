using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace WebDriverDemo.Pages
{
    public class EpamMainPage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='slide']/../../li[2]")]
        public IWebElement TestersLink { get; private set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='ТЕСТИРУЙТЕ ВМЕСТЕ С НАМИ']")]
        public IWebElement TestersVacanciesLink { get; private set; }

        public EpamMainPage()
        {
            PageFactory.InitElements(WebDriver.GetDriver(), this);
        }

        public void OpenTestersSection()
        {
            WebDriver.GetDriver().SwitchTo().Window(WebDriver.GetDriver().WindowHandles[1]);

            WebDriverWait wait = new WebDriverWait(WebDriver.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until(n => TestersLink.Displayed);
            Actions act = new Actions(WebDriver.GetDriver());
            act.MoveToElement(TestersLink).Build().Perform();

            wait.Until(n => TestersVacanciesLink.Displayed);
            TestersVacanciesLink.Click();
        }
    }
}
