using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverDemo
{
    class WebDriver
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = new FirefoxDriver();
                _driver.Manage().Window.Maximize();
            }

            return _driver;
        }

        
    }
}
