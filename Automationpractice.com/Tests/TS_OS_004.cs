using Automationpractice.com.Objects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automationpractice.com_2.Tests
{
    public class TS_OS_004
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void OnetimeSetup()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.driver.Quit();
        }


        [Test]

        public void AddThreeProducts_ToComparison()
        {
            //Arrange
            var catalog = new Catalog (driver);
            //Act
            catalog.AddToCompareFunction(); // function to add up to three items in compare menu
            string title = driver.Title;
            //Assert
            Assert.That(title, Is.EqualTo("Products Comparison - My Store"));
          

        }
        [Test]
        public void QuickView_Panel()
        {
            //Arrange
            var quickView = new Catalog(driver);
            //Act
            quickView.GetProduct(); // function get first product in shop page
            var price = quickView.price.Text;
            var model = quickView.model.Text;
            var condition = quickView.condition.Text;
            //Assert
            Assert.That(price, Is.EqualTo("$28.98"));
            Assert.That(model, Is.EqualTo("Printed Summer Dress"));
            Assert.That(condition, Is.EqualTo("New"));
        }
        [Test]
        public void QuickView_Panel_ChangeSizeQuantityAndColor()
        {
           
            //Arrange
            var quickView = new Catalog(driver);
            //Act
            quickView.GetProduct(); // function get first product in shop page
            quickView.ChangeSize_Color_Quantity(); 
            this.wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("div#layer_cart>div.clearfix")));
            var quantity = quickView.quantity.Text;
            var itemName = quickView.itemName.Text;
            var colorAndSize = quickView.colorAndSize.Text;
            //Assert
            Assert.That(quantity, Is.EqualTo("4"));
            Assert.That(itemName, Is.EqualTo("Printed Summer Dress"));
            Assert.That(colorAndSize, Is.EqualTo("Black, L"));

        }


    }
}
