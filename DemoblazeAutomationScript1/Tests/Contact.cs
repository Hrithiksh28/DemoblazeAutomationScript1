using DemoblazeAutomationScript1.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoblazeAutomationScript1.PageObjects;
using System.Data;
using ICSharpCode.SharpZipLib;
using System.Data.SqlClient;
using System.Collections;

namespace DemoblazeAutomationScript1.Tests
{
    internal class Contact : Base
    {
        [Test]
        public void ContactValid()
        {
            string query = "SELECT * FROM dbo.Contact";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Execute the query and get the results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Loop through the results and import them into your test automation project
                    while (reader.Read())
                    {
                        // For example, you could store the data in variables or objects
                        string email = reader["email"].ToString();
                        string name = reader["name"].ToString();
                        string message = reader["message"].ToString();

                        ContactPage contactPage = new ContactPage(driver);
                        contactPage.Contact(email, name, message);
                    }
                }
            }

            
        }


        /*private IEnumerable<object[]> GetTestData()
        {

            List<object[]> parameters = new List<object[]>();

            // Create a SQL query to select the data you want to import
            string query = "SELECT * FROM dbo.Contact";
            // Create a SqlCommand object using the query and connection
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Execute the query and get the results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Loop through the results and import them into your test automation project
                    while (reader.Read())
                    {
                        // For example, you could store the data in variables or objects
                        string email = reader["email"].ToString();
                        string name = reader["name"].ToString();
                        string message = reader["message"].ToString();

                        parameters.Add(new object[] { email, name, message });
                    }
                }
            }
            return parameters;
        }*/

    }
}
