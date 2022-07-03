using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.WebDriver_Tests
{
    public class WebDriver_Tests
    {
        
        private const string url = "https://taskboard.dimitarstatev.repl.co";
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
           driver.Quit();
        }

        [Test]
        public void Test1_Get_list_AllTasks()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);

            //Act
            var taskboard_button = driver.FindElement(By.CssSelector("body > aside > ul > li:nth-child(2) > a"));
            taskboard_button.Click();
            var title = driver.FindElement(By.CssSelector("#task1 > tbody > tr.title > td")).Text;

            //Assert
            Assert.That(title, Is.EqualTo("Project skeleton"));
            

        }
        [Test]
        public void Test2_Search_ByKeyword_Home()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);

            //Act
            var search_button = driver.FindElement(By.CssSelector("body > aside > ul > li:nth-child(4) > a"));
            search_button.Click();
            var search_bar = driver.FindElement(By.Id("keyword"));
            search_bar.Click();
            search_bar.SendKeys("Home");
            var search_bar_button = driver.FindElement(By.Id("search"));
            search_bar_button.Click();
            var title = driver.FindElement(By.CssSelector("#task2 > tbody > tr.title > td")).Text;

            //Assert
            Assert.That(title, Is.EqualTo("Home page"));
        }

        [Test]
        public void Test3_Search_Invalid_Task()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            //Act
            var search_button = driver.FindElement(By.CssSelector("body > aside > ul > li:nth-child(4) > a"));
            search_button.Click();
            var search_bar = driver.FindElement(By.Id("keyword"));
            search_bar.Click();
            search_bar.SendKeys("Empty task");
            var search_bar_button = driver.FindElement(By.Id("search"));
            search_bar_button.Click();
            var search_result = driver.FindElement(By.Id("searchResult")).Text;
            //Assert
            Assert.That(search_result, Is.EqualTo("No tasks found."));
        }
        [Test]
        public void Test4_Create_New_Task_Invalid_Data()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);

            //Acy
            var create_button = driver.FindElement(By.CssSelector("body > aside > ul > li:nth-child(3) > a"));
            create_button.Click();
            var description= driver.FindElement(By.Id("description"));
            description.Click();
            description.SendKeys("SoftUni_Tests");
            var create = driver.FindElement(By.Id("create"));
            create.Click();
            var result = driver.FindElement(By.CssSelector ("body > main > div")).Text;
            //Assert
            Assert.That(result, Is.EqualTo("Error: Title cannot be empty!"));
        }
        [Test]
        public void Test5_Create_New_Task_Valid_Data()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            //Act
            var create_button = driver.FindElement(By.CssSelector("body > aside > ul > li:nth-child(3) > a"));
            create_button.Click();
            
            var title = driver.FindElement(By.Id("title"));
            title.Click();
            title.SendKeys("SoftUni_Exam");

            var description = driver.FindElement(By.Id("description"));
            description.Click();
            description.SendKeys("This Task is created for exam purpose");

            var create = driver.FindElement(By.Id("create"));
            create.Click();

            IReadOnlyCollection<IWebElement> result = driver.FindElements(By.TagName("td"));
            //var lastResult = result[0].Text;

            //Assert
            // Assert.That(lastResult, Is.EqualTo("SoftUni_Exam"));
            var tasks = result.Select(t => t.Text).ToArray();
            Assert.That(tasks.Contains("SoftUni_Exam"));
        }
    }
}