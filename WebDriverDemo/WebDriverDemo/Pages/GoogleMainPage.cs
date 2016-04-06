using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverDemo.Pages
{
    class GoogleMainPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='lst-ib']")]
        public IWebElement SearchInput { get; private set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='EPAM | Разработка ПО']")]
        public IWebElement MostRelevantLink { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='search']")]
        public IWebElement SearchResultsContainer { get; private set; }

        public GoogleMainPage()
        {
            PageFactory.InitElements(WebDriver.GetDriver(), this);
            WebDriver.GetDriver().Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }

        public void SearchByText(string text)
        {
            SearchInput.Click();
            SearchInput.SendKeys(text);
            SearchInput.SendKeys(Keys.Enter);
        }

        public void ClickMainRelevantLink()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until(n => MostRelevantLink.Displayed);
            MostRelevantLink.Click();
        }

        public static void OpenGoogle()
        {
            WebDriver.GetDriver().Navigate().GoToUrl("https://www.google.ru/?gws_rd=ssl");
        }
    }
}
