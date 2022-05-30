using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace WebDDriver_WaitExamplesTesting
{
    public class WaitTests
    {
        private WebDriver driver;
        private WebDriverWait wait;
        [SetUp]
        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void ShutDown()
        {
            driver.Close();
        }
        
        [Test]
        public void TestWait_ThreadSleepWait()
        {
            //Act
            driver.FindElement(By.PartialLinkText("This is")).Click();
            Thread.Sleep(15000);
            var element = driver.FindElement(By.ClassName("ContactUs")).Text;
            //Assert
            Assert.IsNotEmpty(element);
         }
        [Test]
        public void TestWait_ImplicitWait()
        {
            //Arrange
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //Act
            driver.FindElement(By.PartialLinkText("This is")).Click();
            var element = driver.FindElement(By.ClassName("ContactUs")).Text;
            //Assert
            Assert.IsNotEmpty(element);
        }
        [Test]
        public void TestWait_ExplicitWait()
        {
            //Arrange
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //Act
            driver.FindElement(By.PartialLinkText("This is")).Click();
            var element = this.wait.Until(a =>
            {
                return a.FindElement(By.ClassName("ContactUs")).Text;
            });
            //Assert
            Assert.IsNotEmpty(element);
        }
        [Test]
        public void TestWait_ExpectedConditions()
        {   
            //Arrange
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //Act
            driver.FindElement(By.PartialLinkText("This is")).Click();
            var element = this.wait.Until(
                ExpectedConditions.ElementIsVisible(By.ClassName("ContactUs"))
            );
            //Assert
            Assert.IsNotEmpty(element.Text);
        }
    }
}

