using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        [SetUp]
        public void StartBrowser()
        {
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
            //Quit after every test
            driver.Quit();
        }
    }
}
