using DemoblazeAutomationScript1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.Tests
{
    internal class Homepage : Base
    {
        [Test]
        public void HomepageLogo()
        {
            TestContext.Progress.WriteLine("TestID: FCN_046");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='navbar-brand']")));
            driver.FindElement(By.XPath("//a[@class='navbar-brand']")).Click();
        }
        [Test]
        public void HomepageCarouselLeft()
        {
            TestContext.Progress.WriteLine("TestID: GUI_048");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//span[@class='carousel-control-prev-icon']")).Click();

        }
        [Test]
        public void HomepageCarouselRight()
        {
            TestContext.Progress.WriteLine("TestID: GUI_047");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//span[@class='carousel-control-next-icon']")).Click();

        }

        [Test]
        public void FilterPhone()
        {
            TestContext.Progress.WriteLine("TestID: FCN_049");
            driver.FindElement(By.XPath("//a[@onclick=\"byCat('phone')\"]")).Click();
        }
        [Test]
        public void FilterLaptop()
        {
            TestContext.Progress.WriteLine("TestID: FCN_050");
            driver.FindElement(By.XPath("//a[@onclick=\"byCat('notebook')\"]")).Click();
        }
        [Test]
        public void FilterTV()
        {
            TestContext.Progress.WriteLine("TestID: FCN_051");
            driver.FindElement(By.XPath("//a[@onclick=\"byCat('monitor')\"]")).Click();
        }
        [Test]
        public void NextButton()
        {
            TestContext.Progress.WriteLine("TestID: FCN_053");
            driver.FindElement(By.XPath("//button[@id='next2']")).Click();
        }
        [Test]
        public void PrevButton()
        {
            TestContext.Progress.WriteLine("TestID: FCN_054");
            driver.FindElement(By.XPath("//button[@id='prev2']")).Click();
        }
        [Test]
        public void HomeNavBar()
        {
            TestContext.Progress.WriteLine("TestID: FCN_052");
            driver.FindElement(By.XPath("//*[@id=\"navbarExample\"]/ul/li[1]/a")).Click();
        }
    }
}
