using Automationpractice.com.Objects;


namespace Automationpractice.com.Tests
{
   public class TS_OS_001 : Base_Test
    {
      [TestCase("onlineshopping@abv.bg", "123456")]
      public void Test_Login_Valid_Data(string username, string password)
        {
            //Arrange
            var login = new LoginForm(driver);
            //Act
            login.Enter_Credentials(username, password);
            var loginResult = login.positiveResult.Text;
            //Assert
            Assert.That(loginResult, Is.EqualTo("Welcome to your account. Here you can manage all of your personal information and orders."));


        }
        [TestCase("onlineshopping@abv.bg", "xxxxxx")]
        [TestCase("xxxxxx", "onlineshopping@abv.bg")]
        [TestCase("xxxxxx", "xxxxxxxxxxxxxxxxxxxxx")]
        public void Test_Login_Invalid_Data(string username, string password)
        {
            //Arrange
            var login = new LoginForm(driver);
            //Act
            login.Enter_Credentials(username, password);
            var loginResult = login.negativeResult.Text;
            //Assert
            Assert.That(loginResult, Is.EqualTo("There is 1 error"));

        }
    }

   
}
