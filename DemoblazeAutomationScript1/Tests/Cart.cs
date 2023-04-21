using DemoblazeAutomationScript1.PageObjects;
using DemoblazeAutomationScript1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.Tests
{
    internal class Cart:Base
    {
        [Test]
        public void ProductAddedWhenLoggedout()
        {
            TestContext.Progress.WriteLine("TestID: FCN_029");
            //Adding products while logged out
            CartPage cartPage = new CartPage(driver);
            cartPage.ProductsAddedWhenLoggedOutSteps();
        }

        [Test]
        public void ProductAddedWhenloggedIn()
        {
            TestContext.Progress.WriteLine("TestID: FCN_029");
            //Hardcoded login values to check whether cache retention for one user exists
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithoutTestID("hrithik1", "hrihtik");
            CartPage cartPage = new CartPage(driver);
            cartPage.ProductsAddedWhenLoggedOutSteps();
        }

        [Test]
        public void CacheRemovalAfterLoggingout()
        {
            TestContext.Progress.WriteLine("TestID: FCN_030");
            //Verify whether cache is cleared after logging out
            CartPage cartPage = new CartPage(driver);
            cartPage.CacheRemovalAfterLoggingoutSteps();
        }

        [Test]
        public void CacheRetention()
        {
            TestContext.Progress.WriteLine("TestID: FCN_031");
            //Verify whether cache is restored after re logging in
            CartPage cartPage = new CartPage(driver);
            cartPage.CacheRetentionSteps();

        }

        [Test]
        public void PlaceOrder()
        {
            //Query to print all data from table UserOrderDetails
            string query = "SELECT * FROM dbo.UserOrderDetails";

            using(SqlCommand command = new SqlCommand(query, connection))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        string country = reader["country"].ToString();
                        string city = reader["city"].ToString();
                        string card = reader["card"].ToString();
                        string month = reader["months"].ToString();
                        string year = reader["years"].ToString();
                        string testID = reader["id"].ToString();

                        CartPage cartPage = new CartPage(driver);
                        cartPage.PlaceOrderSteps(name, country, city, card, month, year, testID);
                    }
                }
            }
            
        }

        [Test]
        public void DeleteOrder()
        {
            TestContext.Progress.WriteLine("TestID: FCN_045");
            //Delete products in cart using Delelte hyperlink
            CartPage cartPage = new CartPage(driver);
            cartPage.DeleteOrderSteps();

        }
    }
}
