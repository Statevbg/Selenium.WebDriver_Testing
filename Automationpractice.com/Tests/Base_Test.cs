using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automationpractice.com.Tests
{
    public class Base_Test
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}
