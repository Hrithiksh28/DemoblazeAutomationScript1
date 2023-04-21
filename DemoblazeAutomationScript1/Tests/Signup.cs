using DemoblazeAutomationScript1.PageObjects;
using DemoblazeAutomationScript1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V109.Network;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Data;
using System.Data.SqlClient;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoblazeAutomationScript1.Tests
{
    public class Signup:Base
    {
        [Test]
        public void SignUp()
        {
            /* driver.FindElement(By.XPath("//a[@id='signin2']")).Click();
             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
             wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='sign-username']")));
             driver.FindElement(By.XPath("//input[@id='sign-username']")).SendKeys("rocky");
             driver.FindElement(By.XPath("//input[@id='sign-password']")).SendKeys("rocky");
             driver.FindElement(By.XPath("//button[@onclick='register()']")).Click();
             */
            /*wait.Until(ExpectedConditions.AlertIsPresent());
            string strAlert = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine(strAlert);
            driver.SwitchTo().Alert().Accept();
*/

            string query = "SELECT * FROM dbo.userSignUp";

            using(SqlCommand command = new SqlCommand(query, connection))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();
                        string testID = reader["id"].ToString();

                        SignupPage signupPage = new SignupPage(driver);
                        signupPage.signUpValidWithTestID(username, password, testID);
                    }
                }
            }

            
            
        }

        /*public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData("rocky", "rocky");
            yield return new TestCaseData("rocky2", "rcoky2");
        }*/
    }
}