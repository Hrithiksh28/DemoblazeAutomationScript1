using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoblazeAutomationScript1.Utilities;
using DemoblazeAutomationScript1.PageObjects;

namespace DemoblazeAutomationScript1.Tests
{
    internal class GUITestLogin:Base
    {

        public LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
        }
        [Test]
        public void BorderColourChangeUsername()
        {
            //LoginPage loginPage = new LoginPage(driver);
            loginPage.BorderColourChangeUsername();

        }
        [Test]
        public void BorderColourChangePassword()
        {
            //LoginPage loginPage = new LoginPage(driver);
            loginPage.BorderColourChangePassword();

        }
        /*[Test]
        public void BorderColourChangeButton()
        {
            //LoginPage loginPage = new LoginPage(driver);
            loginPage.BorderColourChangeButton();

        }*/
        [Test]
        public void BackgroundColourChangeButton()
        {
            //LoginPage loginPage = new LoginPage(driver);
            loginPage.BackgroundColourChangeButton();

        }
    }
}
