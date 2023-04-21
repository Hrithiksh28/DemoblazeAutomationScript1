using DemoblazeAutomationScript1.Tests;
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

        public LogOutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='login2']")]
        private IWebElement logiNav;

        [FindsBy(How = How.XPath, Using = "//a[@id='signin2']")]
        private IWebElement signupNav;

        [FindsBy(How = How.XPath, Using = "//a[@onclick='logOut()']")]
        private IWebElement logOutNav;

        [FindsBy(How = How.XPath, Using = "//a[@id='nameofuser']")]
        private IWebElement welcomeNav;

        public void LogOutSteps()
        {
            logOutNav.Click();
        }

        public void NavigationDrawerTextChangeSteps()
        {
            TestContext.Progress.WriteLine("Test ID: FCN_019");

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithoutTestIDHardcoded("hrithik1", "hrithik");
            Thread.Sleep(5000);

            TestContext.Progress.WriteLine("Before Logging Out:");
            TestContext.Progress.WriteLine(logOutNav.Text);
            TestContext.Progress.WriteLine(welcomeNav.Text);

            LogOutSteps();

            TestContext.Progress.WriteLine("After Logging Out:");
            TestContext.Progress.WriteLine(logiNav.Text);
            TestContext.Progress.WriteLine(signupNav.Text);

        }
    }
}
