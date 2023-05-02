using DemoblazeAutomationScript1.PageObjects;
using DemoblazeAutomationScript1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.Tests
{
    internal class LogOut:Base
    {
        public LogOutPage logOutPage;

        [SetUp]
        public void SetUp()
        {
            logOutPage = new LogOutPage(driver);
        }
        [Test]
        public void LoggingOut()
        {
            TestContext.Progress.WriteLine("TestID: FCN_018");

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithoutTestID("hrithik1", "hrithik");

            //LogOutPage logOutPage = new LogOutPage(driver);
            logOutPage.LogOutSteps();
        }

        [Test]
        public void NavigationDrawerTextChange()
        {
            //LogOutPage logOut = new LogOutPage(driver);
            logOutPage.NavigationDrawerTextChangeSteps();
        }
        
    }
}
