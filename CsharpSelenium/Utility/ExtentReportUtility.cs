using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace CsharpSelenium.Utility
{
    public class ExtentReportUtility
    {
        private static ExtentReports extent = null;
        private static ExtentTest extentTest = null;
        private static string dateTimeDay = DateTime.Now.ToString("dd");
        private static string dateTimeMonth = DateTime.Now.ToString("MM");
        private static string dateTimeYear = DateTime.Now.ToString("yyyy");
        private static string dateTimeHour = DateTime.Now.ToString("HH");
        private static string dateTimeMin = DateTime.Now.ToString("mm");
        private static string dateTimeSec = DateTime.Now.ToString("ss");
        private static string reportPath="C:\\Users\\Namrata\\Documents\\CSharpProjects\\CsharpSelenium\\CsharpSelenium\\Reports\\"+dateTimeDay+"\\"+dateTimeMonth+"\\"+dateTimeYear+"\\"+dateTimeHour+"\\"+dateTimeMin+"_"+dateTimeSec+"\\";
        private static string reportName = TestContext.CurrentContext.Test.ClassName;

        public static ExtentReports extentReports { 
            get { return extent; } 
        }

        public static ExtentTest extentTests { 
            get { return extentTest; } 
        }

        public static ExtentReports initExtent()
        {
            extent = new ExtentReports();
            var sparkReport = new ExtentSparkReporter(reportPath+reportName+".html");
            extent.AttachReporter(sparkReport);
            return extent;
        }

        public static ExtentTest createTest(string testName)
        {
            extentTest = extent.CreateTest(testName);
            return extentTest;

        }

        public static void extentInfo(ExtentTest test,string info)
        {
            test.Info(info);
        }

        public static void extentPass(ExtentTest test, string pass)
        {
            test.Pass(pass);
        }

        public static void extentWarning(ExtentTest test, string warning)
        {
            test.Warning(warning);
        }

        public static void extentSkip(ExtentTest test, string skip)
        {
            test.Skip(skip);
        }

        public static void extentFail(ExtentTest test, string fail)
        {
            test.Fail(fail);
        }

        public static void attachReport(ExtentTest test, string ss)
        {
            test.AddScreenCaptureFromBase64String(ss);
        }
    }
}
