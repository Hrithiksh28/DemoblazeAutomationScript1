using DemoblazeAutomationScript1.Tests;
using DemoblazeAutomationScript1.Utilities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.PageObjects
{
    internal class SignupPage
    {
        private IWebDriver driver;
        public CommonFunctions function;
        public IWebDriver GetDriver()
        {
            return driver;
        }

        public SignupPage(IWebDriver driver)
        {
            this.driver = driver;
            function = new CommonFunctions(driver);
            PageFactory.InitElements(driver, this);
                
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='signin2']")]
        private IWebElement signupNav;

        [FindsBy(How = How.XPath, Using = "//input[@id='sign-username']")]
        private IWebElement signUsername;

        [FindsBy(How = How.XPath, Using = "//input[@id='sign-password']")]
        private IWebElement signPassword;

        [FindsBy(How = How.XPath, Using = "//button[@onclick='register()']")]
        private IWebElement signButton;

        /*public void WaitForDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='sign-username']")));

        }*/

        public void signUpValidWithTestID(string username, string password, string testID)
        {
            signupNav.Click();
            //WaitForDisplay();
            CommonFunctions.WaitForCondition(driver,signUsername, 5);
            signUsername.SendKeys(username);
            signPassword.SendKeys(password);
            signButton.Click();
            TestContext.Progress.WriteLine("Test ID: " + testID);
            TestContext.Progress.WriteLine("Username: " + username);
            TestContext.Progress.WriteLine("Password: " + password);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
            wait.Until(ExpectedConditions.AlertIsPresent());
            string strAlert = driver.SwitchTo().Alert().Text;
            Assert.IsTrue(driver.SwitchTo().Alert().Text.Contains(strAlert));
            TestContext.Progress.WriteLine("Outcome: "+strAlert);
            driver.SwitchTo().Alert().Accept();
            driver.Navigate().Refresh();

           

        }
        public void signUpValidWithoutTestID(string username, string password)
        {
            signupNav.Click();
            //WaitForDisplay();
            CommonFunctions.WaitForCondition(driver,signUsername, 5);
            signUsername.SendKeys(username);
            signPassword.SendKeys(password);
            signButton.Click();
            TestContext.Progress.WriteLine("Username: " + username);
            TestContext.Progress.WriteLine("Password: " + password);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
            wait.Until(ExpectedConditions.AlertIsPresent());
            string strAlert = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine("Outcome: " + strAlert);
            driver.SwitchTo().Alert().Accept();
            driver.Navigate().Refresh();

            Assert.IsTrue(driver.SwitchTo().Alert().Text.Contains(strAlert));

        }
        public void BorderColourChangeUsername()
        {
            TestContext.Progress.WriteLine("TestID: GUI_009");
            signupNav.Click();
            CommonFunctions.WaitForCondition(driver,signUsername, 5);
            string beforeColor = signUsername.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            signUsername.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = signUsername.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void BorderColourChangePassword()
        {
            TestContext.Progress.WriteLine("TestID: GUI_010");
            signupNav.Click();
            CommonFunctions.WaitForCondition(driver,signUsername, 5);
            string beforeColor = signPassword.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            signPassword.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = signPassword.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void BorderColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_011");
            signupNav.Click();
            CommonFunctions.WaitForCondition(driver,signUsername, 5);
            string beforeColor = signButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            signButton.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = signButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void BackgroundColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_067");
            signupNav.Click();
            CommonFunctions.WaitForCondition(driver,signUsername, 5);
            string beforeColor = signButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(signButton).Perform();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = signButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
    }
}
