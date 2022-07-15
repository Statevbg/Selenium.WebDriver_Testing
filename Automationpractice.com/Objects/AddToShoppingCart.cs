using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automationpractice.com.Objects
{
    public class AddToShoppingCart : LoginForm

    {
        public AddToShoppingCart(IWebDriver driver) : base(driver)
        {

        }
        public IWebElement firstProduct => driver.FindElement(By.CssSelector("a[class=product-name][title='Faded Short Sleeve T-shirts']"));
        public IWebElement addButton => driver.FindElement(By.CssSelector("a.button.ajax_add_to_cart_button.btn.btn-default"));
        public IWebElement proceedToOne => driver.FindElement(By.LinkText("Proceed to checkout"));
        public IWebElement proceedToTwo => driver.FindElement(By.CssSelector("button.btn.btn-default.button.button-medium"));
        public IWebElement checkCart => driver.FindElement(By.CssSelector("#summary_products_quantity"));
        public IWebElement checkBox => driver.FindElement(By.CssSelector("input[id='addressesAreEquals']"));
        public IWebElement termsOfService => driver.FindElement(By.CssSelector("input[id='cgv']"));
        public IWebElement paymentMethodBank => driver.FindElement(By.CssSelector("a.bankwire"));
        public IWebElement checkOrder => driver.FindElement(By.CssSelector("p.cheque-indent>strong"));
        public IWebElement checkAuthentication => driver.FindElement(By.CssSelector("#create-account_form>div>p"));

        public void GetFirstProduct()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(firstProduct).Build().Perform();
            addButton.Click();
            proceedToOne.Click();
        }
        public void CheckCheckBox()
        {
            if (checkBox.Selected)
            {
                proceedToOne.Click();
            }
            else
            {
                checkBox.Click();
                proceedToOne.Click();
            }

        }
        public void ProceedToPayment()
        {
            proceedToOne.Click();
            proceedToTwo.Click();
            termsOfService.Click();
            proceedToTwo.Click();
            paymentMethodBank.Click();
            proceedToTwo.Click();
        }
       
    }
}
