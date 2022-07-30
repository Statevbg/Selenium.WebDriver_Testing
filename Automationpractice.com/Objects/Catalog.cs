using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automationpractice.com.Objects
{
    public class Catalog
    {
        protected readonly IWebDriver driver;
        private WebDriverWait wait;



        const string PageUrl = "http://automationpractice.com/index.php?id_category=8&controller=category&fbclid=IwAR0QRBlGpQ7IbL7N0_I9s8bW4G2sXi0CIcW-3srTOQAkoSYfRK31GaywsD8";
        public Catalog(IWebDriver driver)
        {
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            this.driver = driver;
            driver.Navigate().GoToUrl(PageUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public IReadOnlyCollection<IWebElement> addToCompare =>
            driver.FindElements(By.CssSelector("a.add_to_compare"));
        public IWebElement compareButton =>
            driver.FindElement(By.CssSelector("button.btn.btn-default.button.button-medium.bt_compare.bt_compare:nth-of-type(1)"));
        public IWebElement listView =>
            driver.FindElement(By.CssSelector("i.icon-th-list"));
        public IWebElement comparisonPage =>
            driver.FindElement(By.CssSelector("h1.page-heading"));
        public IWebElement product =>
           driver.FindElement(By.CssSelector("ul.color_to_pick_list.clearfix :nth-of-type(3)"));
        public IWebElement quickView =>
            driver.FindElement(By.LinkText("Quick view"));
        public IWebElement price =>
           driver.FindElement(By.XPath("//*[@id='our_price_display']"));
        public IWebElement model =>
            driver.FindElement(By.CssSelector("h1[itemprop=name]"));
        public IWebElement condition =>
            driver.FindElement(By.CssSelector("p#product_condition>span"));
        public IWebElement addToCartButton =>
            driver.FindElement(By.CssSelector("button.exclusive"));
        public IWebElement addQuantity =>
            driver.FindElement(By.CssSelector("i.icon-plus"));
        public IWebElement changeColorToBlack =>
            driver.FindElement(By.CssSelector("div>ul>li>a#color_11"));
        public IWebElement closePopUp =>
            driver.FindElement(By.CssSelector("span.cross"));

        public IWebElement itemName =>
            driver.FindElement(By.CssSelector("#layer_cart_product_title"));
        public IWebElement quantity =>
            driver.FindElement(By.CssSelector("#layer_cart_product_quantity"));
        public IWebElement colorAndSize =>
            driver.FindElement(By.CssSelector("div>span#layer_cart_product_attributes"));


        public void AddToCompareFunction()
        {
            listView.Click();
            for (int i = 0; i < 3; i++) //adding three items in comparison menu
            {
                Thread.Sleep(3000); //some times website's response is to slow , so we need extra time!
                addToCompare.ElementAt(i).Click();
            }
            compareButton.Click();
        }

        public void GetProduct()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(product).Build().Perform(); //hover mouse over 
            quickView.Click();
            driver.SwitchTo().Frame(0);
        }

        public void ChangeSize_Color_Quantity()
        {
            SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("select#group_1"))); // choose from dropdown menu
            select.SelectByText("L");
            changeColorToBlack.Click();

            for (int i = 0; i < 3; i++) // click to increase quantity 
            {
                addQuantity.Click();
            }

            addToCartButton.Click();
            driver.SwitchTo().ParentFrame();
        }
    }
}
