﻿using AngleSharp.Dom;
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
    internal class LoginPage
    {
        private IWebDriver driver;

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Defining web elements into page objects using PageFactory
        [FindsBy(How = How.XPath, Using = "//a[@id='login2']")]
        private IWebElement logiNav;

        [FindsBy(How = How.XPath, Using = "//a[@id='signin2']")]
        private IWebElement signupNav;

        [FindsBy(How = How.XPath, Using = "//a[@onclick='logOut()']")]
        private IWebElement logOutNav;

        [FindsBy(How = How.XPath, Using = "//a[@id='nameofuser']")]
        private IWebElement welcomeNav;

        [FindsBy(How = How.XPath, Using = "//input[@id='loginusername']")]
        private IWebElement loginUsername;

        [FindsBy(How = How.XPath, Using = "//input[@id='loginpassword']")]
        private IWebElement loginPassword;

        [FindsBy(How = How.XPath, Using = "//button[@onclick='logIn()']")]
        private IWebElement loginButton;

        //Explicit wait using WebDriverWait
        public void WaitForDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='loginusername']")));
        }

        public void LoginWithoutTestID(string username, string password)
        {

            //Login page steps
            logiNav.Click();
            WaitForDisplay();
            loginUsername.SendKeys(username);
            loginPassword.SendKeys(password);
            loginButton.Click();
            TestContext.Progress.WriteLine("Username: " + username);
            TestContext.Progress.WriteLine("password: " + password);
            Thread.Sleep(3000);
            try
            {
                //If alert is present, print alert message
                string strAlert = driver.SwitchTo().Alert().Text;
                TestContext.Progress.WriteLine("Outcome: "+strAlert);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                driver.Navigate().Refresh();
            }
            catch (NoAlertPresentException)
            {
                // If an alert is not present, print "login successful"
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
                wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@onclick='logOut()']")));

                LogOutPage logOut = new LogOutPage(driver);
                logOut.LogOutSteps();

                TestContext.Progress.WriteLine("Outcome: Login Successful!");
            }


        }

        public void LoginWithTestID(string username, string password, string testID)
        {

            //Login page steps
            logiNav.Click();
            WaitForDisplay();
            loginUsername.SendKeys(username);
            loginPassword.SendKeys(password);
            loginButton.Click();
            TestContext.Progress.WriteLine("Test ID: " + testID);
            TestContext.Progress.WriteLine("Username: " + username);
            TestContext.Progress.WriteLine("password: " + password);
            Thread.Sleep(3000);
            try
            {
                //If alert is present, print alert message
                string strAlert = driver.SwitchTo().Alert().Text;
                TestContext.Progress.WriteLine("Outcome: " + strAlert);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                driver.Navigate().Refresh();
            }
            catch (NoAlertPresentException)
            {
                // If an alert is not present, print "login successful"
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
                wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@onclick='logOut()']")));

                LogOutPage logOut = new LogOutPage(driver);
                logOut.LogOutSteps();

                TestContext.Progress.WriteLine("Outcome: Login Successful!");
            }


        }

        public void LoginWithoutTestIDHardcoded(string username, string password)
        {

            //Login page steps
            logiNav.Click();
            WaitForDisplay();
            loginUsername.SendKeys(username);
            loginPassword.SendKeys(password);
            loginButton.Click();
            Thread.Sleep(3000);
            try
            {
                //If alert is present, print alert message
                string strAlert = driver.SwitchTo().Alert().Text;
                TestContext.Progress.WriteLine("Outcome: " + strAlert);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                driver.Navigate().Refresh();
            }
            catch (NoAlertPresentException)
            {
                // If an alert is not present, print "login successful"
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
                wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@onclick='logOut()']")));

            }


        }

        public void NavigationDrawerTextChangeSteps()
        {
            TestContext.Progress.WriteLine("Test ID: FCN_016");

            TestContext.Progress.WriteLine("Before Logging in:");
            TestContext.Progress.WriteLine(logiNav.Text);
            TestContext.Progress.WriteLine(signupNav.Text);

            LoginWithoutTestIDHardcoded("hrithik1", "hrithik");
            Thread.Sleep(5000);

            TestContext.Progress.WriteLine("After Logging in:");
            TestContext.Progress.WriteLine(logOutNav.Text);
            TestContext.Progress.WriteLine(welcomeNav.Text);

        }
        public void BorderColourChangeUsername()
        {
            TestContext.Progress.WriteLine("TestID: GUI_009");
            logiNav.Click();
            string beforeColor = loginUsername.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            loginUsername.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = loginUsername.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangePassword()
        {
            TestContext.Progress.WriteLine("TestID: GUI_010");
            logiNav.Click();
            string beforeColor = loginPassword.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            loginPassword.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = loginPassword.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_017");
            logiNav.Click();
            string beforeColor = loginButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            loginButton.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = loginButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BackgroundColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_068");
            logiNav.Click();
            string beforeColor = loginButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(loginButton).Perform();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = loginButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }

        
        /*
                private bool IsAlertPresent()
                {
                    try
                    {
                        IAlert alert = driver.SwitchTo().Alert();
                        alert.Accept();
                        // If an alert is present, return true
                        return true;
                    }
                    catch (NoAlertPresentException)
                    {
                        // If an alert is not present, return false
                        return false;
                    }
                }*/
    }
}
