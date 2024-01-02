using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace CsharpSelenium.Utility
{
    public static class SeleniumCustomCommands
    {
        static string screenShotPath = "C:/Users/Namrata/Documents/CSharpProjects/CsharpSelenium/CsharpSelenium/Screenshot/";

        public static void click(this IWebElement element)
        {
            element.Click();
        }

        public static void sendKeys(this IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void clear(this IWebElement element, By locator)
        {
            element.Clear();
        }

        public static void clickAndSendKeys(this IWebElement element, string text)
        {
            element.Click();
            element.SendKeys(text);
        }

        public static void clearAndSendKeys(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void selectByText(this IWebElement element, string text)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public static void selectByValue(this IWebElement element, string value)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public static void selectByIndex(this IWebElement element, int index)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByIndex(index);
        }

        public static void multiSelectByText(this IWebElement element, string[] texts)
        {
            SelectElement multiSelectElement = new SelectElement(element);
            foreach (string text in texts)
            {
                multiSelectElement.SelectByText(text);
            }
        }

        public static void multiSelectByValue(this IWebElement element, string[] values)
        {
            SelectElement multiSelectElement = new SelectElement(element);
            foreach (string value in values)
            {
                multiSelectElement.SelectByValue(value);
            }
        }

        public static void multiSelectByText(this IWebElement element, int[] indexes)
        {
            SelectElement multiSelectElement = new SelectElement(element);
            foreach (int index in indexes)
            {
                multiSelectElement.SelectByIndex(index);
            }
        }

        public static void acceptAlert(this IWebDriver driver) {
            driver.SwitchTo().Alert().Accept();
        }

        public static void dismissAlert(this IWebDriver driver)
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public static string getAlertText(this IWebDriver driver)
        {
            string alertText = "";
            alertText = driver.SwitchTo().Alert().Text;
            return alertText;
        }

        public static void takeScreenshot(IWebDriver driver)
        {
            DateTime now = DateTime.Now;
            string dateTimeDay = DateTime.Now.ToString("dd");
            string dateTimeMonth = DateTime.Now.ToString("MM");
            string dateTimeYear = DateTime.Now.ToString("yyyy");
            string dateTimeHour = DateTime.Now.ToString("hh");
            string dateTimeMin = DateTime.Now.ToString("mm");
            string dateTimeSec = DateTime.Now.ToString("ss");
            string dateTime = now.ToString("dd-MM-yyyy-HH-ss");
            string testName = TestContext.CurrentContext.Test.Name;
            Screenshot ts = ((ITakesScreenshot)driver).GetScreenshot();
            Directory.CreateDirectory(screenShotPath + "/" + dateTimeDay + "/" + dateTimeMonth + "/" + dateTimeYear + "/" + dateTimeHour + "_" + dateTimeMin + "_" + dateTimeSec);
            ts.SaveAsFile(screenShotPath +"/"+ dateTimeDay+"/"+ dateTimeMonth+"/"+ dateTimeYear +"/"+dateTimeHour+"_"+dateTimeMin+"_"+dateTimeSec+"/"+testName+"_"+dateTime+".png");
        }
    }
}
