using AventStack.ExtentReports;
using CsharpSelenium.Base;
using CsharpSelenium.PageObjects;
using CsharpSelenium.Utility;
using OpenQA.Selenium;

[assembly:Parallelizable(ParallelScope.Fixtures)]
namespace CsharpSelenium
{
    [TestFixture("Chrome")]
    //[TestFixture("Edge")]
    public class Tests
    {
        IWebDriver? driver = null;
        LoginPage? login = null;
        HomePage? home = null;
        EmployeeListPage? employees = null;
        ExtentReports report = null;
        ExtentTest test = null;

        public Tests(string browser) { 
            BaseClass.browser.Value = browser;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            driver = BaseClass.initializeDriver();
            report = ExtentReportUtility.initExtent();
        }

        [Test, Order(0)]
        public void EASiteTest()
        {
            test = report.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
            login = new LoginPage(driver);
            if (login != null)
            {
                string url = "http://eaapp.somee.com/";
                login.navigateToUrl(url);
                ExtentReportUtility.extentInfo(test, "Navigated to url : "+url);
                login.clickOnLoginLink();
                ExtentReportUtility.extentInfo(test, "Clicked on Login Link");
                login.enterUserData();
                ExtentReportUtility.extentInfo(test, "User Data entered successfully..");
                login.clickOnLoginButton();
                ExtentReportUtility.extentInfo(test, "Clicked on login button");
            }
            else
            {
                Console.WriteLine("login Instance is null");
            }
        }

        [Test, Order(1)]
        public void EAHomePageTest()
        {
            test = report.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
            home = new HomePage(driver);
            home.verifyLogin();
            ExtentReportUtility.extentInfo(test, "HomePage Verified");
            home.clickOnEmployeeList();
            ExtentReportUtility.extentInfo(test, "Clicked on Employee List");
        }

        [Test, Order(2)]
        public void EmployeeListPageTest()
        {
            test = report.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
            employees = new EmployeeListPage(driver);
            employees.verifyEmployeeList();
            ExtentReportUtility.extentInfo(test, "Employee List Verified");
            employees.createNewEmployee();
            ExtentReportUtility.extentInfo(test, "New Employee Created");
            employees.searchAndDeleteEmployee();
            ExtentReportUtility.extentInfo(test, "Searched and deleted the employee");
        }

        [TearDown]
        public void checkIfFailed()
        {
            Console.WriteLine("Current Test Name is {0}", TestContext.CurrentContext.Test.Name);
            Console.WriteLine("Current Test Full Name is {0}", TestContext.CurrentContext.Test.FullName);
            Console.WriteLine("Current Test Method Name is {0}", TestContext.CurrentContext.Test.MethodName);
            Console.WriteLine("Current Test Result is {0}", TestContext.CurrentContext.Result.Outcome.Status);
            Console.WriteLine("Current Test Directory is {0}", TestContext.CurrentContext.TestDirectory);
            Console.WriteLine("Current Work Directory is {0}", TestContext.CurrentContext.WorkDirectory);

            string status = TestContext.CurrentContext.Result.Outcome.Status.ToString();

            if (status.Equals("Failed"))
            {
                Console.WriteLine("In ss");
                SeleniumCustomCommands.takeScreenshot(driver);
                ExtentReportUtility.extentFail(test," Test Failed : "+ TestContext.CurrentContext.Test.Name);
            }
            else
            {
                ExtentReportUtility.extentPass(test, "Test Passed");
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            report.Flush();
        }
    }
}