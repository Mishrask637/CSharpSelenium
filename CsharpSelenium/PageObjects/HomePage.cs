

using CsharpSelenium.Utility;
using OpenQA.Selenium;

namespace CsharpSelenium.PageObjects
{
    public class HomePage
    {

        IWebDriver driver = null;
        IWebElement homeLink => driver.FindElement(By.XPath("//a[text()='Home']"));
        IWebElement helloText => driver.FindElement(By.XPath("//a[text()='Hello admin!!']"));
        IWebElement employeeList => driver.FindElement(By.XPath("//a[text()='Employee List']"));

        public HomePage(IWebDriver driver) {
            this.driver = driver;
        }

        public string getTitle()
        {
            return driver.Title;
        }
        
        public void verifyLogin()
        {
            Assert.That(true, Is.EqualTo(helloText.Displayed));
        }

        public void clickOnEmployeeList()
        {
            employeeList.click();
        }
    }
}
