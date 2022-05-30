using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverPOM_Example.Pages;

namespace WebDriverPOM_Example.Tests
{
    public class AddStudentTests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
        }
        [OneTimeTearDown]
        public void ShutDownBrowser()
        {
            driver.Quit();
        }
        [Test]
        public void Test_AddStudent_Url_Heading_And_Title()
        {
            //Arrange
            var add_student = new AddStudentPage(driver);
            //Act
            add_student.Open();
            //Assert
            Assert.That(add_student.GetPageHeading(), Is.EqualTo("Register New Student"));
            Assert.That(add_student.GetPageTitle(), Is.EqualTo("Add Student"));
        }
        [Test]
        public void Test_AddStudent_HomeLink()
        {
            //Arrange
            var add_student = new AddStudentPage(driver);
            //Act
            add_student.Open();
            add_student.HomeLink.Click();
            //Assert
            Assert.That(add_student.GetPageTitle(), Is.EqualTo("MVC Example"));
        }
        [Test]
        public void Test_AddStudent_Function()
        {
            //Arrange
            var add_student = new AddStudentPage(driver);
            var home_page = new HomePage(driver);
            //Act
            add_student.Open();
            add_student.AddStudentFunction("John", "Mohn@gmail.com");
            add_student.HomeLink.Click();
            home_page.GetStudentCount();
            //Assert
            // go check are registred students are more than 3
            Assert.That(home_page.GetStudentCount, Is.GreaterThan(3));
        }
        [Test]
        public void Test_AddStudentEmptyFields_Function()
        {   
            //Arrange
            var add_student = new AddStudentPage(driver);
            //Act
            add_student.Open();
            add_student.AddStudentFunction("", "");
            // check response message
            var errorResponse = driver.FindElement(By.CssSelector("body > div"));
            //Assert
            // go check are registred students are more than 3
            Assert.That(errorResponse.Text, Is.EqualTo("Cannot add student. Name and email fields are required!"));
        }


    }
}