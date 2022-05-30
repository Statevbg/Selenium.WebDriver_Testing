using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace NUnit_WebDriverTests
{
    public class WikipediaTesting
    {
        private WebDriver driver;
        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://www.wikipedia.org/";
            
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
        [Test]
        public void Testing_SearchBar()
        {
            //Arrange
            var searchField = driver.FindElement(By.Id("searchInput"));
            //Act
            searchField.Click();
            searchField.SendKeys("QA");
            searchField.SendKeys(Keys.Enter);
            string expectedUrl = "https://en.wikipedia.org/wiki/QA";
            //Assert
            Assert.That(driver.Url, Is.EqualTo(expectedUrl));
        }

    }
}