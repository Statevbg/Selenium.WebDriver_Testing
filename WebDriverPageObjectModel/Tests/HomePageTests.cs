using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverPOM_Example.Pages;

namespace WebDriverPOM_Example.Tests
{
    public class HomePageTests
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
        public void TestHomePage_Url_Heading_Title()
        {   
            //Arrange
            var home_page = new HomePage(driver);
            //Act
            home_page.Open();
            //Assert
            Assert.That(this.driver.Url, Is.EqualTo(home_page.GetPageUrl()));
            Assert.That(home_page.GetPageHeading(), Is.EqualTo("Students Registry"));
            Assert.That(home_page.GetPageTitle(), Is.EqualTo("MVC Example"));
        }
        [Test]
        public void TestHomePage_HomeLink()
        {
            //Arrange
            var home_page = new HomePage(driver);
            //Act
            home_page.Open();
            home_page.HomeLink.Click();
            //Assert
            Assert.That(home_page.GetPageTitle(), Is.EqualTo("MVC Example"));
        }

        [Test]
        public void TestHomePage_ViewStudentCount()
        {
            //Arrange
            var home_page = new HomePage(driver);
            //Act
            home_page.Open();
            home_page.HomeLink.Click();
            //Assert
            Assert.Greater(home_page.GetStudentCount(), 0);
        }
        [Test]
        public void TestHomePage_ViewStudentLink()
        {
            //Arrange
            var view_student = new ViewStudentsPage(driver);
            var home_page = new HomePage(driver);
            //Act
            home_page.Open();
            home_page.ViewStudentsLink.Click();
            //Assert
            Assert.That(new ViewStudentsPage(driver).GetPageTitle, Is.EqualTo("Students"));
            Assert.That(driver.Url, Is.EqualTo(view_student.GetPageUrl()));
        }
        [Test]
        public void TestHomePage_AddStudentLink()
        {
            //Arrange
            var view_student = new ViewStudentsPage(driver);
            var home_page = new HomePage(driver);
            //Act
            home_page.Open();
            home_page.AddStudentLink.Click();
            //Assert
            Assert.That(new ViewStudentsPage(driver).GetPageTitle, Is.EqualTo("Add Student"));
            Assert.That(driver.Url, Is.EqualTo(view_student.GetPageUrl()));

        }
    }

}