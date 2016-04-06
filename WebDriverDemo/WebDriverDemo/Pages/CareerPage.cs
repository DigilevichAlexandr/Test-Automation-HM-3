using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriverDemo.Pages
{
    public class CareerPage
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Minsk')]")]
        public IWebElement LocationLabel { get; private set; }

        [FindsBy(How = How.XPath, Using = "//span[@title='Горячие вакансии']")]
        public IWebElement HotVacancies { get; private set; }
        
        public CareerPage()
        {
            PageFactory.InitElements(WebDriver.GetDriver(), this);
        }

        public void FilterByLocation()
        {
            HotVacancies.Click();
            Actions act = new Actions(WebDriver.GetDriver());
            act.MoveToElement(LocationLabel).Build().Perform();
        }


    }
}
