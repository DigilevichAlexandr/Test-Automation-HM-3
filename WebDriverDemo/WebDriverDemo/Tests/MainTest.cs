using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WebDriverDemo.Pages;

namespace WebDriverDemo.Tests
{
    [TestFixture]
    public class MainTest
    {
        [TestCase]
        public void FindVacancies()
        {
            GoogleMainPage.OpenGoogle();

            GoogleMainPage googleMainPage = new GoogleMainPage();
            googleMainPage.SearchByText("epam вакансии");
            googleMainPage.ClickMainRelevantLink();

            EpamMainPage epamMainPage = new EpamMainPage();
            epamMainPage.SearchJobByText("automation testing");
            epamMainPage.ClickFirstRelevantLink();
        }
    }
}
