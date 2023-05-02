using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V109.Page;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoblazeAutomationScript1.Utilities
{
    public class Base
    {
        public SqlConnection connection;
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        //Report file

        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("host name", "local host");
            extent.AddSystemInfo("Environment", "QA");


        }

        [SetUp]
        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Initialize browser set up using ConfigurationManager. This will refer the data provided in app.config file
            string browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.demoblaze.com/index.html";
            // Create a connection string for database
            string connectionString = "Data Source=INPHWN157125\\UDEMYSERVER; Initial Catalog=UdemySQL; Integrated Security=SSPI;";
            // Create a SqlConnection object using the connection string
            connection = new SqlConnection(connectionString);

            // Open the connection
            connection.Open();
        }

        public void InitBrowser(string browserName)
        {
            //Selection of browsers
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void AfterTest()
        {

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            if (status == TestStatus.Failed)
            {
                test.Fail("Test Failed", CaptureScreenshot(driver, fileName));
                test.Log(Status.Fail, "Test failed with log trace: "+ stackTrace);

            }
            else if(status == TestStatus.Passed)
            {

            }

            //Flush report
            extent.Flush();
            //Quit after every test
            driver.Quit();
        }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenShot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenShotName).Build();
        }


    }
}
