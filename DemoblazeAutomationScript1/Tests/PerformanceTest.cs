using DemoblazeAutomationScript1.PageObjects;
using DemoblazeAutomationScript1.Utilities;
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

namespace DemoblazeAutomationScript1.Tests
{
    
    internal class PerformanceTest:Base
    { 
        private string baseUrl = "https://www.demoblaze.com/index.html";
        private int numIterations = 10;
        [Test]
        public void UserLoadTesting5()
        {
            TestContext.Progress.WriteLine("TestID: FCN_055");
            string query = "SELECT * FROM dbo.ValidUsersLoad";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //open browser as different users
                        var newDriver = new ChromeDriver();
                        newDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        newDriver.Navigate().GoToUrl(baseUrl);
                        newDriver.Manage().Window.Maximize();

                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();

                        LoginPage loginPage = new LoginPage(newDriver);
                        loginPage.LoginWithoutTestID(username, password);                      
                        //Close browser for every user
                        newDriver.Quit();
                    }
                }
            }
        }
        [Test]
        public void UserLoadTesting10()
        {
            TestContext.Progress.WriteLine("TestID: FCN_056");
            string query = "SELECT * FROM dbo.ValidUsersLoad10";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //open browser as different users
                        var newDriver = new ChromeDriver();
                        newDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        newDriver.Navigate().GoToUrl(baseUrl);

                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();

                        LoginPage loginPage = new LoginPage(newDriver);
                        loginPage.LoginWithoutTestID(username, password);
                        //Close browser for every user
                        newDriver.Quit();
                    }
                }
            }
        }
        [Test]
        public void UserLoadTesting15()
        {
            TestContext.Progress.WriteLine("TestID: FCN_057");
            string query = "SELECT * FROM dbo.ValidUsersLoad15";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //open browser as different users
                        var newDriver = new ChromeDriver();
                        newDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        newDriver.Navigate().GoToUrl(baseUrl);

                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();

                        LoginPage loginPage = new LoginPage(newDriver);
                        loginPage.LoginWithoutTestID(username, password);
                        //Close browser for every user
                        newDriver.Quit();
                    }
                }
            }
        }
        [Test]
        public void UserLoadTesting20()
        {
            TestContext.Progress.WriteLine("TestID: FCN_058");
            string query = "SELECT * FROM dbo.ValidUsersLoad20";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //open browser as different users
                        var newDriver = new ChromeDriver();
                        newDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        newDriver.Navigate().GoToUrl(baseUrl);

                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();

                        LoginPage loginPage = new LoginPage(newDriver);
                        loginPage.LoginWithoutTestID(username, password);
                        //Close browser for every user
                        newDriver.Quit();
                    }
                }
            }
        }
        [Test]
        public void IterationLoadTesting()
        {
            TestContext.Progress.WriteLine("TestID: FCN_059");
            for (int i = 1; i <= numIterations; i++)
            {
                //open browser for each iterations
                driver.Navigate().GoToUrl(baseUrl);

                //perform one action
                //Adding products while logged out
                CartPage cartPage = new CartPage(driver);
                cartPage.ProductsAddedWhenLoggedOutSteps();

                Thread.Sleep(5000);

                //close browser after every iteration
                driver.Navigate().Refresh();
            }
        }
    }
}
