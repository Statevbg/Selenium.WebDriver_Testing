using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace NUnit_WebDriverTests
{
    public class ShortURLs
    {
        private WebDriver driver;
        
        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://shorturl.nakov.repl.co/urls";
                      
        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
        [Test]
        public void Test1_ShortURLs()
        {

            //Check page title
            var page_title = driver.FindElement(By.CssSelector("body > main > h1"));
            Assert.That(page_title.Text, Is.EqualTo("Short URLs"));
            //Get all cells
            var allCells = driver.FindElements(By.CssSelector("table tr > td"));
            //Assert
            Assert.That(allCells[0].Text, Is.EqualTo("https://nakov.com"));
            Assert.That(allCells[1].Text, Is.EqualTo("http://shorturl.nakov.repl.co/go/nak"));


        }

        [Test]
        public void Test2_AddURL_InvalidCredentials()
        {   
            //Arrange
            driver.FindElement(By.CssSelector("body > header > a:nth-child(5)")).Click();
            var searchInput = driver.FindElement(By.Id("url"));
            var createButton = driver.FindElement(By.CssSelector("body > main > form > table > tbody > tr:nth-child(3) > td > button"));
            //Act
            searchInput.Click();
            searchInput.SendKeys("StormTrooper.Lucasverse");
            createButton.Click();   
            //Assert
            Assert.That(driver.FindElement(By.CssSelector("body > div")).Text, Is.EqualTo("Invalid URL!"));
        }
        [Test]
        public void Test3_AddURL_ValidCredentials()
        {
            driver.FindElement(By.CssSelector("body > header > a:nth-child(5)")).Click();

            var urlinput = driver.FindElement(By.Id("url"));
            urlinput.Click();
            urlinput.SendKeys("https://stackoverflow.com/");
            var shortcode = driver.FindElement(By.Id("code"));
            shortcode.Click();
            shortcode.Clear();
            shortcode.SendKeys("CreatedByDimitarStatev");

            var createButton = driver.FindElement(By.CssSelector("body > main > form > table > tbody > tr:nth-child(3) > td > button"));
            createButton.Click();
            driver.FindElement(By.CssSelector("body > header > a:nth-child(3)")).Click();
            var shortURLs = driver.FindElements(By.TagName("tr"));
         
            foreach (var url in shortURLs)
            {
                if (url.Text.Contains("CreatedByDimitarStatev"))
                {
                    Assert.That(url.Text.Contains("CreatedByDimitarStatev"));
                }
            }
        }   
        [Test]
        public void Test4_VisitExistingShortURL()
        {
            //Arrange
            var initialVisitors = driver.FindElement(By.CssSelector("body > main > table > tbody > tr:nth-child(1) > td:nth-child(4)"));
            var firstVisitors = initialVisitors.Text;
            var shortURLs = driver.FindElements(By.ClassName("shorturl"));
            //Act
            shortURLs.First().Click();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.FindElement(By.CssSelector("body > header > a:nth-child(3)")).Click();
            var lastVisitors = driver.FindElement(By.CssSelector("body > main > table > tbody > tr:nth-child(1) > td:nth-child(4)"));
            var updatedVisitors  =  lastVisitors.Text;
            //Assert
            Assert.That(updatedVisitors , Is.GreaterThan(firstVisitors));
          
        }
    }
}
