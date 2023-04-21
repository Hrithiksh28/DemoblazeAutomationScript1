using DemoblazeAutomationScript1.Tests;
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
    internal class ContactPage
    {

        private IWebDriver driver;

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@data-target='#exampleModal']")]
        private IWebElement contactNav;
        [FindsBy(How = How.XPath, Using = "//input[@id='recipient-email']")]
        private IWebElement receipentEmail;
        [FindsBy(How = How.XPath, Using = "//input[@id='recipient-name']")]
        private IWebElement receipentName;
        [FindsBy(How = How.XPath, Using = "//textarea[@id='message-text']")]
        private IWebElement receipentMessage;
        [FindsBy(How = How.XPath, Using = "//button[@onclick='send()']")]
        private IWebElement sendButton;

        public void WaitForDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='recipient-email']")));
        }

        public void Contact(string email, string name, string message)
        {
            contactNav.Click();
            WaitForDisplay();
            receipentEmail.SendKeys(email);
            receipentName.SendKeys(name);
            receipentMessage.SendKeys(message);
            TestContext.Progress.WriteLine("TestID: FCN_020");
            TestContext.Progress.WriteLine("Email: "+ email);
            TestContext.Progress.WriteLine("Name: "+ name);
            TestContext.Progress.WriteLine("Message: "+ message);
            sendButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000));
            wait.Until(ExpectedConditions.AlertIsPresent());
            string strAlert = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine("Outcome: "+ strAlert);
            driver.SwitchTo().Alert().Accept();
        }
        public void BorderColourChangeEmail()
        {
            TestContext.Progress.WriteLine("TestID: GUI_089");
            contactNav.Click();
            string beforeColor = receipentEmail.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            receipentEmail.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = receipentEmail.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeName()
        {
            TestContext.Progress.WriteLine("TestID: GUI_070");
            contactNav.Click();
            string beforeColor = receipentName.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            receipentName.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = receipentName.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeMessage()
        {
            TestContext.Progress.WriteLine("TestID: GUI_071");
            contactNav.Click();
            string beforeColor = receipentMessage.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            receipentMessage.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = receipentMessage.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_072");
            contactNav.Click();
            string beforeColor = sendButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            sendButton.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = sendButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BackgroundColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_073");
            contactNav.Click();
            string beforeColor = sendButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(sendButton).Perform();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = sendButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }

    }
}
