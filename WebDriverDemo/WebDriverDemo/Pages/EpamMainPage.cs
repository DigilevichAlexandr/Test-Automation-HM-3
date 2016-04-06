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
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Ключевые слова (не обязательно):']")]
        public IWebElement JobSearch { get; private set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='link']")]
        public IWebElement RelevantLink { get; private set; }

        public void SearchJobByText(string text)
        {
            JobSearch.Click();
            JobSearch.SendKeys(text);
            JobSearch.SendKeys(Keys.Enter);
        }

        public void ClickFirstRelevantLink()
        {
            RelevantLink.Click();
        }
    }
}
