using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace CsharpSelenium.Base
{
    public class BaseClass
    {
        private static ThreadLocal<IWebDriver> threadLocalDriver = new ThreadLocal<IWebDriver>();

        private static ThreadLocal<string> threadLocalBrowser = new ThreadLocal<string>();

        public static ThreadLocal<string> browser
        {
            set
            {
                if (value != null)
                {
                    BaseClass.threadLocalBrowser = value;
                }
            }
            get{return BaseClass.threadLocalBrowser; }
        }

        public static ThreadLocal<IWebDriver> driver
        {
            set {
                if(value!=null)
                {
                    BaseClass.threadLocalDriver = value; 
                }
            }
            get { return BaseClass.threadLocalDriver; }
        }

        public static IWebDriver? initializeDriver()
        {
            Console.WriteLine("Browser Value is {0}", browser.Value);
            if (browser.Value != null && browser.Value != "")
            {
                if (browser.Value.Equals("Chrome"))
                {
                    driver.Value = new ChromeDriver();
                }
                else if (browser.Value.Equals("Firefox"))
                {
                    driver.Value = new FirefoxDriver();
                }
                else if (browser.Value.Equals("Edge"))
                {
                    driver.Value = new EdgeDriver();
                }
                driver.Value.Manage().Window.Maximize();
                driver.Value.Manage().Cookies.DeleteAllCookies();
                driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return driver.Value;
            }
            else
            {
                Console.WriteLine("Enter a valid browser value....");
                return null;
            }
        }
    }
}
