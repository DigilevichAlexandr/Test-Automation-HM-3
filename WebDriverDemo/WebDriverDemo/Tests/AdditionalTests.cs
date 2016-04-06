using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Drawing.Imaging;

namespace WebDriverDemo.Tests
{
    public class AdditionalTests
    {
        [Test]
        public void JsTest()
        {
            string xpath = "//input[@value='Мне повезёт!']";
            string script = string.Format(@"var element = document.evaluate( ""{0}"" ,document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null ).singleNodeValue; element.click();", xpath);
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.google.ru/?gws_rd=ssl");
            driver.ExecuteJavaScript(script);
        }

        [Test]
        public void ScreenshotTest()
        {
            string xpath = "//input[@value='Мне повезёт!']";
            string script = string.Format(@"var element = document.evaluate( ""{0}"" ,document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null ).singleNodeValue; element.click();", xpath);
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.google.ru/?gws_rd=ssl");
            driver.ExecuteJavaScript(script);
             
            string fileName = string.Format(@"D:\Temp\Demo\{0}.png", DateTime.Now.ToString("MM-dd-yy HH_mm_ss"));
            driver.TakeScreenshot().SaveAsFile(fileName, ImageFormat.Png);
        }
    }
}
