using CsharpSelenium.Utility;
using OpenQA.Selenium;

namespace CsharpSelenium.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver;
        IWebElement loginLink => driver.FindElement(By.LinkText("Loginn"));
        IWebElement userName => driver.FindElement(By.Name("UserName"));
        IWebElement password => driver.FindElement(By.Id("Password"));
        IWebElement rememberMe => driver.FindElement(By.Id("RememberMe"));
        IWebElement loginButton => driver.FindElement(By.ClassName("btn"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void navigateToUrl(string url)
        {
            driver.Url = url;
        }

        public void clickOnLoginLink()
        {
            loginLink.click();
        }

        public void enterUserData()
        {
            userName.sendKeys("admin");
            password.sendKeys("password");
            rememberMe.click();
        }

        public void clickOnLoginButton()
        {
            loginButton.click();
        }

    }
}
