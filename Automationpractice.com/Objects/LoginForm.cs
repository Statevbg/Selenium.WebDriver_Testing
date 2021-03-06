using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Automationpractice.com.Objects
{
    public class LoginForm 
    {
        protected readonly IWebDriver driver;

        const string PageUrl = "http://automationpractice.com/index.php";
        public LoginForm(IWebDriver driver) 
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(PageUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
        }

        public IWebElement signIn => driver.FindElement(By.CssSelector("a.login"));
        public IWebElement userEmail => driver.FindElement(By.Id("email"));
        public IWebElement userPassword => driver.FindElement(By.Id("passwd"));
        public IWebElement signInButton => driver.FindElement(By.Id("SubmitLogin"));
        public IWebElement positiveResult => driver.FindElement(By.ClassName("info-account"));
        public IWebElement negativeResult => driver.FindElement(By.CssSelector("#center_column > div.alert.alert-danger > p"));

     
        public void Enter_Credentials(string user, string pass)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(signIn));
            signIn.Click();
            userEmail.Click();
            userEmail.SendKeys(user);
            userPassword.Click();
            userPassword.SendKeys(pass);
            signInButton.Click();
        }
    }

}
