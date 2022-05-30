using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverPOM_Example.Pages;

namespace WebDriverPOM_Example.Tests
{
    public class ViewStudentTests
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
        public void TestViewStudents_Url_Heading_Title()
        {
            //Arrange
            var viewStudentPage = new ViewStudentsPage (driver);
            //Act
            viewStudentPage.Open();
            //Assert
            Assert.That(viewStudentPage.GetPageHeading(), Is.EqualTo("Registered Students"));
        }
        [Test]
        public void TestViewStudents_Url_Homelink()
        {   
            //Arrangre 
            var viewStudentPage = new ViewStudentsPage(driver);
            //Act
            viewStudentPage.Open();
            //get registered students
            var students = viewStudentPage.GetRegisteredStudents();
            var number = students.Length;
            //Assert
            Assert.That(number, Is.GreaterThanOrEqualTo(3));
        }
        
    }
}
