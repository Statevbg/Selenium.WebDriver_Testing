using Automationpractice.com.Objects;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automationpractice.com.Tests
{
    public class TS_OS_002 : Base_Test
    {
        [TestCase("onlineshopping@abv.bg", "123456")]
        public void Test_Add_Item_To_Shopping_Cart_RegisteredUser(string username, string password) 
        {
            //Arrange
            var cart = new LoginForm(driver);
            //Act
            cart.Enter_Credentials(username, password);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Thread.Sleep(2000);
            var cart2 = new AddToShoppingCart(driver);
            cart2.GetFirstProduct();
            var result = cart2.checkCart.Text;
            //Assert
            Assert.That(result, Is.GreaterThan("0"));
        }
        [TestCase("onlineshopping@abv.bg", "123456")]
        public void Test_Proceed_To_Payment_RegisteredUser(string username, string password)
        {

            //Arrange
            var cart = new LoginForm(driver);
            //Act
            cart.Enter_Credentials(username, password);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Thread.Sleep(3000);
            var cart2 = new AddToShoppingCart(driver);
            cart2.GetFirstProduct();
            cart2.ProceedToPayment();
            var result = cart2.checkOrder.Text;
            //Assert
            Assert.That(result, Is.EqualTo("Your order on My Store is complete."));


        }
        [Test]
        public void Test_Add_Item_To_Shopping_Cart_NotRegisteredUser()
        {

            //Arrange
            var cart = new AddToShoppingCart(driver);
            //Act
            cart.GetFirstProduct();
            var result = cart.checkCart.Text;
            //Assert
            Assert.That(result, Is.GreaterThan("0"));
        }
        [Test]
        public void Test_Proceed_To_Payment_NotRegisteredUser()
        {
            //Arrange
            var cart = new AddToShoppingCart(driver);
            //Act
            cart.GetFirstProduct();
            cart.proceedToOne.Click();
            var result = cart.checkAuthentication.Text;
            //Assert
            Assert.That(result, Is.EqualTo("Please enter your email address to create an account."));

        }
    }
}
