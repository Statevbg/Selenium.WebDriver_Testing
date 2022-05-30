using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnit_WebDriverTests
{
    public class SummatorOfNumbers
    {
        private WebDriver driver;
        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://sum-numbers.nakov.repl.co/";
            
        }
        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
       
        
        [TestCase("5", "1", "Sum: 6")]
        [TestCase("5", "-1", "Sum: 4")]
        [TestCase("@", "№", "Sum: invalid input")]
        
        public void Testing_SummatorOfNumbers(string numb1, string numb2, string expectedResult)
        {
            //Arrange
            var num1 = driver.FindElement(By.Id("number1"));
            var num2 = driver.FindElement(By.Id("number2"));
            var calcButton = driver.FindElement(By.Id("calcButton"));
            var result = driver.FindElement(By.Id("result"));
            //Act
            num1.Click();
            num1.SendKeys(numb1);
            num2.Click();
            num2.SendKeys(numb2);
            calcButton.Click();
            //Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Testing_SummatorOfNumbers_ResetButton()
        {   
            //Arrange
            driver.FindElement(By.Id("number1")).SendKeys("5");
            driver.FindElement(By.Id("number2")).SendKeys("4");
            //Act
            var num1 = driver.FindElement(By.Id("number1")).GetAttribute("value");
            Assert.IsNotEmpty(num1);
            var num2 = driver.FindElement(By.Id("number2")).GetAttribute("value");
            Assert.IsNotEmpty(num2);
            var reset = driver.FindElement(By.Id("resetButton"));
            reset.Click();
            //Assert
            num1 = driver.FindElement(By.Id("number1")).GetAttribute("value");
            Assert.AreEqual("", num1);
            num2 = driver.FindElement(By.Id("number2")).GetAttribute("value");
            Assert.IsEmpty("", num2);

        }
    }
}
