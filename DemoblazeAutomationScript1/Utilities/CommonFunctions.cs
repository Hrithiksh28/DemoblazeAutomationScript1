using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoblazeAutomationScript1.Utilities
{
    internal class CommonFunctions
    {
        private IWebDriver driver;

        public CommonFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }
        public static IWebElement WaitForCondition(IWebDriver driver, IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void waitForDisplay(IWebDriver driver, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vjs-poster']")));
            //return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(element.GetAttribute("xpath"))));
        }

        public static void ImplicitWait(IWebDriver driver, int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
        public static bool WaitForAlert(IWebDriver driver, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            try
            {
                wait.Until(ExpectedConditions.AlertIsPresent());
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void InitBrowser(string browserName)
        {
            //Selection of browsers
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }
    }
}
