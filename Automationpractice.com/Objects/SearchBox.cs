using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automationpractice.com.Objects
{
    public class SearchBox : LoginForm
    {
        

        public SearchBox(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement searchBar => driver.FindElement(By.CssSelector("input#search_query_top"));
        public IWebElement searchIcon => driver.FindElement(By.CssSelector("button[name=submit_search]"));
        public IWebElement checkResult => driver.FindElement(By.CssSelector("span.heading-counter"));

        public void Search_Keyword(string keyword)
        {
            searchBar.Click();
            searchBar.SendKeys(keyword);
            searchIcon.Click(); 
        }

    }
}
