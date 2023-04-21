using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using DemoblazeAutomationScript1.Utilities;
using DemoblazeAutomationScript1.PageObjects;
using System.Data.SqlClient;

namespace DemoblazeAutomationScript1.Tests
{
    internal class Login:Base
    {
        [Test]
        public void LoginAllTest()
        {
            /*driver.FindElement(By.XPath("//a[@id='login2']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='loginusername']")));
            driver.FindElement(By.XPath("//input[@id='loginusername']")).SendKeys("pqpwqp");
            driver.FindElement(By.XPath("//input[@id='loginpassword']")).SendKeys("pqpqp");
            driver.FindElement(By.XPath("//button[@onclick='logIn()']")).Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait2.Until(ExpectedConditions.AlertIsPresent());
            string strAlert = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine(strAlert);
            driver.SwitchTo().Alert().Accept();*/


            //Query to print all the data from table Users
            string query = "SELECT * FROM dbo.UserLogin";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Execute the query and get the results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Loop through the results and import them into your test automation project
                    while (reader.Read())
                    {
                        //store the data in variables or objects
                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();
                        string testID = reader["id"].ToString();

                        //Calling Login Page object and passing username and password parameters defined above
                        LoginPage loginPage = new LoginPage(driver);
                        loginPage.LoginWithTestID(username, password, testID);
                        
                    }
                }
            }

            
        }

        [Test]
        public void NavigationDrawerTextChange()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.NavigationDrawerTextChangeSteps();
        }
        /*[Test]
        public void LoginValid()
        {
            *//*driver.FindElement(By.XPath("//a[@id='login2']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='loginusername']")));
            driver.FindElement(By.XPath("//input[@id='loginusername']")).SendKeys("pqpqp");
            driver.FindElement(By.XPath("//input[@id='loginpassword']")).SendKeys("pqpqp");
            driver.FindElement(By.XPath("//button[@onclick='logIn()']")).Click();*//*

            string query = "SELECT * FROM dbo.Users";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Execute the query and get the results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Loop through the results and import them into your test automation project
                    while (reader.Read())
                    {
                        // For example, you could store the data in variables or objects
                        string username = reader["username"].ToString();
                        string password = reader["pass"].ToString();

                        LoginPage loginPage = new LoginPage(driver);
                        loginPage.Login(username, password);
                        
                    }
                }
            }

        }*/
    }
}
