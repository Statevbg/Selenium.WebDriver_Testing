using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverPOM_Example.Pages
{
    public class AddStudentPage : BasePage

    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {

        }
        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement enterName => driver.FindElement(By.Id("name"));

        public IWebElement  enterEmail => driver.FindElement(By.Id("email"));

        public IWebElement addStudent => driver.FindElement(By.CssSelector("body > form > button"));

        public void AddStudentFunction (string name, string email)
        {
            this.enterName.SendKeys(name);
            this.enterEmail.SendKeys(email);
            this.addStudent.Click();
        }

    }
}
 