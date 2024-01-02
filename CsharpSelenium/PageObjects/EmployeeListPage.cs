
using CsharpSelenium.Utility;
using OpenQA.Selenium;

namespace CsharpSelenium.PageObjects
{
    public class EmployeeListPage
    {
        IWebDriver driver;
        IWebElement createNew => driver.FindElement(By.XPath("//a[text()='Create New']"));
        IWebElement searchField => driver.FindElement(By.Name("searchTerm"));
        IWebElement searchButton => driver.FindElement(By.XPath("//input[contains(@class,'btn')]"));
        IWebElement name => driver.FindElement(By.Id("Name"));
        IWebElement salary => driver.FindElement(By.Id("Salary"));
        IWebElement durationWorked => driver.FindElement(By.Id("DurationWorked"));
        IWebElement grade => driver.FindElement(By.Id("Grade"));
        IWebElement email => driver.FindElement(By.Id("Email"));
        IWebElement createButton => driver.FindElement(By.XPath("//input[contains(@class,'btn')]"));
        IWebElement delete => driver.FindElement(By.XPath("//a[text()='Delete']"));
        IWebElement deleteButton => driver.FindElement(By.ClassName("btn"));


        public EmployeeListPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void verifyEmployeeList()
        {
            Assert.That(createNew.Displayed, Is.EqualTo(true));
        }

        public void createNewEmployee()
        {
            createNew.click();
            name.sendKeys("Nams");
            salary.sendKeys("50");
            durationWorked.sendKeys("8");
            grade.selectByText("Senior");
            email.sendKeys("test@gmail.com");
            createButton.click();
        }

        public void searchAndDeleteEmployee()
        {
            searchField.sendKeys("Nams");
            searchButton.click();
            delete.click();
            deleteButton.click();
        }
    }
}
