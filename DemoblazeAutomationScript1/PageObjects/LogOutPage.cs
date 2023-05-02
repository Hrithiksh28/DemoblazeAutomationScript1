using DemoblazeAutomationScript1.Tests;
using DemoblazeAutomationScript1.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.PageObjects
{
    internal class LogOutPage
    {
        private IWebDriver driver;
        public CommonFunctions function;

        public LogOutPage(IWebDriver driver)
        {
            this.driver = driver;
            function = new CommonFunctions(driver);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='login2']")]
        private IWebElement logiNav;

        [FindsBy(How = How.XPath, Using = "//a[@id='signin2']")]
        private IWebElement signupNav;

        [FindsBy(How = How.XPath, Using = "//a[@id='logout2']")]
        private IWebElement logOutNav;

        [FindsBy(How = How.XPath, Using = "//a[@id='nameofuser']")]
        private IWebElement welcomeNav;

        public void LogOutSteps()
        {
            //Thread.Sleep(3000);
            CommonFunctions.WaitForCondition(driver,logOutNav, 5);
            logOutNav.Click();
            TestContext.Progress.WriteLine("Logout Successful");
        }

        public void NavigationDrawerTextChangeSteps()
        {
            TestContext.Progress.WriteLine("Test ID: FCN_019");

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithoutTestIDHardcoded("hrithik1", "hrithik");
            CommonFunctions.WaitForCondition(driver, logOutNav, 5);

            TestContext.Progress.WriteLine("Before Logging Out:");
            TestContext.Progress.WriteLine(logOutNav.Text);
            TestContext.Progress.WriteLine(welcomeNav.Text);

            Assert.AreEqual("Log out", logOutNav.Text);
            Assert.AreEqual("Welcome hrithik1", welcomeNav.Text);

            LogOutSteps();

            TestContext.Progress.WriteLine("After Logging Out:");
            TestContext.Progress.WriteLine(logiNav.Text);
            TestContext.Progress.WriteLine(signupNav.Text);

            Assert.AreEqual("Log in", logiNav.Text);
            Assert.AreEqual("Sign up", signupNav.Text);


        }
    }
}
