
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnit_WebDriverTests
{
    public class NumberCalculator
    {
        private WebDriver driver;
        IWebElement firstNumberField;
        IWebElement secondNumberField;
        IWebElement dropDownMenu;
        IWebElement calcButton;
        IWebElement resetButton;
        IWebElement result;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
            firstNumberField = driver.FindElement(By.Id("number1"));
            secondNumberField = driver.FindElement(By.Id("number2"));
            dropDownMenu = driver.FindElement(By.Id("operation"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));
            result = driver.FindElement(By.Id("result"));
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
        [TestCase("5", "+", "4", "Result: 9")]
        [TestCase("7", "+", "-1", "Result: 6")]
        [TestCase("12", "-", "4", "Result: 8")]
        [TestCase("15", "-", "-4", "Result: 19")]
        [TestCase("4", "*", "3", "Result: 12")]
        [TestCase("3", "*", "-3", "Result: -9")]
        [TestCase("21", "/", "7", "Result: 3")]
        [TestCase("15", "/", "3", "Result: 5")]
        [TestCase("15", "/", "-3", "Result: -5")]
        [TestCase("-6", "+", "-3", "Result: -9")]
        [TestCase("-15", "-", "-3", "Result: -12")]
        [TestCase("-19", "-", "6", "Result: -25")]
        [TestCase("-4", "*", "-3", "Result: 12")]
        [TestCase("-8", "/", "-2", "Result: 4")]

        public void Test_Valid_InputIntegers(string num1 , string operation, string num2,
               string expectedResult)
        {   
            //Arrange
            resetButton.Click();
            if (num1 != "") firstNumberField.SendKeys(num1);
            if (operation != "") dropDownMenu.SendKeys(operation);
            if (num2 != "") secondNumberField.SendKeys(num2);
            //Act
            calcButton.Click();
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
           

        }
        [TestCase("7.9", "+", "2.1", "Result: 10")]
        [TestCase("-3.4", "-", "-1", "Result: -2.4")]
        [TestCase("-5", "+", "0", "Result: -5")]
        [TestCase("9.5", "-", "-4", "Result: 13.5")]
        public void Test_Valid_InputDecimals(string num1, string operation, string num2,
               string expectedResult)
        {
            //Arrange
            resetButton.Click();
            if (num1 != "") firstNumberField.SendKeys(num1);
            if (operation != "") dropDownMenu.SendKeys(operation);
            if (num2 != "") secondNumberField.SendKeys(num2);
            //Act
            calcButton.Click();
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }
        [TestCase("7.9", "^", "2.1", "Result: invalid operation")]
        [TestCase("-3.4", "%", "-1", "Result: invalid operation")]
        [TestCase("-5", "&", "0", "Result: invalid operation")]
        [TestCase("9.5", "@", "-4", "Result: invalid operation")]
        public void Test_Invalid_Operation(string num1, string operation, string num2,
              string expectedResult)
        {
            //Arrange
            resetButton.Click();
            if (num1 != "") firstNumberField.SendKeys(num1);
            if (operation != "") dropDownMenu.SendKeys(operation);
            if (num2 != "") secondNumberField.SendKeys(num2);
            //Act
            calcButton.Click();
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }
        [TestCase("18", "-", "@", "Result: invalid input")]
        [TestCase("ASD", "+", "-1", "Result: invalid input")]
        [TestCase("-5", "/", "{}", "Result: invalid input")]
        [TestCase("!?", "*", "4", "Result: invalid input")]
        public void Test_Invalid_Input(string num1, string operation, string num2,
              string expectedResult)
        {
            //Arrange
            resetButton.Click();
            if (num1 != "") firstNumberField.SendKeys(num1);
            if (operation != "") dropDownMenu.SendKeys(operation);
            if (num2 != "") secondNumberField.SendKeys(num2);
            //Act
            calcButton.Click();
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }
    }    
}