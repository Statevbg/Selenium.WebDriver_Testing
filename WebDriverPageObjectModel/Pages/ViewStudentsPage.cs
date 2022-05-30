using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverPOM_Example.Pages
{
    public class ViewStudentsPage : BasePage

    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {

        }
        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";

        public IReadOnlyCollection<IWebElement> listStudents =>
            driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudents()
        {
            var elementStudents = this.listStudents.Select(a => a.Text).ToArray();
            return elementStudents;
        }
    }
}
 