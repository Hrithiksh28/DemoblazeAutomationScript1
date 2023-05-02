using DemoblazeAutomationScript1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.PageObjects
{
    internal class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='signin2']")]
        private IWebElement signupNav;
        [FindsBy(How = How.XPath, Using = "//*[@id=\"navbarExample\"]/ul/li[1]/a")]
        private IWebElement homeNav;
        [FindsBy(How = How.XPath, Using = "//a[@id='login2']")]
        private IWebElement loginNav;
        [FindsBy(How = How.XPath, Using = "//a[@data-target='#videoModal']")]
        private IWebElement aboutUsNav;
        [FindsBy(How = How.XPath, Using = "//a[@data-target='#exampleModal']")]
        private IWebElement contactNav;
        [FindsBy(How = How.XPath, Using = "//a[@href='cart.html']")]
        private IWebElement cartNav;
        [FindsBy(How = How.XPath, Using = "//img[@src='imgs/Lumia_1520.jpg']")]
        private IWebElement productHref;
        [FindsBy(How = How.XPath, Using = "//button[@id='next2']")]
        private IWebElement nextButton;
        [FindsBy(How = How.XPath, Using = "//button[@id='prev2']")]
        private IWebElement prevButton;
        [FindsBy(How = How.XPath, Using = "//div[@id='footc']")]
        private IWebElement footer;
        [FindsBy(How = How.XPath, Using = "//a[@onclick=\"byCat('monitor')\"]")]
        private IWebElement filterTV;
        [FindsBy(How = How.XPath, Using = "//a[@onclick=\"byCat('phone')\"]")]
        private IWebElement filterPhone;
        [FindsBy(How = How.XPath, Using = "//a[@onclick=\"byCat('notebook')\"]")]
        private IWebElement filterLaptop;
        [FindsBy(How = How.XPath, Using = "//span[@class='carousel-control-prev-icon']")]
        private IWebElement carouselLeft;
        [FindsBy(How = How.XPath, Using = "//span[@class='carousel-control-next-icon']")]
        private IWebElement carouselRight;
        [FindsBy(How = How.XPath, Using = "//a[@class='navbar-brand']")]
        private IWebElement homepageLogo;

        public void NavbuttonColourChangeSignUpNav()
        {
            TestContext.Progress.WriteLine("TestID: GUI_008");
            IWebElement element = signupNav;
            string beforeColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void NavbuttonColourChangeHomeNav()
        {
            TestContext.Progress.WriteLine("TestID: GUI_008");
            IWebElement element = homeNav;
            string beforeColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void NavbuttonColourChangeContactNav()
        {
            TestContext.Progress.WriteLine("TestID: GUI_021");
            IWebElement element = contactNav;
            string beforeColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void NavbuttonColourChangeAboutUsNav()
        {
            TestContext.Progress.WriteLine("TestID: GUI_028");
            IWebElement element = aboutUsNav;
            string beforeColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void NavbuttonColourChangeCartNav()
        {
            TestContext.Progress.WriteLine("TestID: GUI_044");
            IWebElement element = cartNav;
            string beforeColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void NavbuttonColourChangeLoginNav()
        {
            TestContext.Progress.WriteLine("TestID: GUI_015");
            IWebElement element = loginNav;
            string beforeColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = element.GetCssValue("color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void ProductCardUnderline()
        {
            TestContext.Progress.WriteLine("TestID: GUI_080");
            Thread.Sleep(5000);
            IWebElement element = productHref;
            string beforeColor = element.GetCssValue("text-decoration");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = element.GetCssValue("text-decoration");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void BackgroundColourChangeNext()
        {
            TestContext.Progress.WriteLine("TestID: GUI_078");
            Thread.Sleep(5000);
            IWebElement element = nextButton;
            string beforeColor = element.GetCssValue("background-color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = element.GetCssValue("background-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }

        public void BackgroundColourChangePrevious()
        {
            TestContext.Progress.WriteLine("TestID: GUI_079");
            Thread.Sleep(5000);
            IWebElement element = prevButton;
            string beforeColor = element.GetCssValue("background-color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = element.GetCssValue("background-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);

        }
        public void FooterContent()
        {
            TestContext.Progress.WriteLine("TestID: GUI_081");
            IWebElement footerContent = footer;
            TestContext.Progress.WriteLine(footerContent.Text);
            Assert.IsTrue(footer.Displayed, "footer content is not displayed.");

        }


        public void HomepageLogo()
        {
            TestContext.Progress.WriteLine("TestID: FCN_046");
            CommonFunctions.WaitForCondition(driver, homepageLogo, 5);
            homepageLogo.Click();
            Assert.IsTrue(homepageLogo.Displayed, "HomePage logo is not displayed.");


        }
        public void HomepageCarouselLeft()
        {
            TestContext.Progress.WriteLine("TestID: GUI_048");
            CommonFunctions.WaitForCondition(driver, carouselLeft, 5);
            carouselLeft.Click();
            Assert.IsTrue(carouselLeft.Displayed, "Carousel Left button is not displayed.");


        }
        public void HomepageCarouselRight()
        {
            TestContext.Progress.WriteLine("TestID: GUI_047");
            CommonFunctions.WaitForCondition(driver, carouselRight, 5);
            carouselRight.Click();
            Assert.IsTrue(carouselRight.Displayed, "Carousel Right button is not displayed.");
        }
        public void FilterPhone()
        {
            TestContext.Progress.WriteLine("TestID: FCN_049");
            CommonFunctions.WaitForCondition(driver, filterPhone, 5);
            filterPhone.Click();
            Assert.IsTrue(filterPhone.Displayed, "Filter Phone button is not displayed.");
        }
        public void FilterLaptop()
        {
            TestContext.Progress.WriteLine("TestID: FCN_050");
            CommonFunctions.WaitForCondition(driver, filterLaptop, 5);
            filterLaptop.Click();
            Assert.IsTrue(filterLaptop.Displayed, "Filter Laptop button is not displayed.");
        }
        public void FilterTV()
        {
            TestContext.Progress.WriteLine("TestID: FCN_051");
            CommonFunctions.WaitForCondition(driver, filterTV, 5);
            filterTV.Click();
            Assert.IsTrue(filterTV.Displayed, "Filter TV button is not displayed.");
        }
        public void NextButton()
        {
            TestContext.Progress.WriteLine("TestID: FCN_053");
            CommonFunctions.WaitForCondition(driver, nextButton, 5);
            nextButton.Click();
            Assert.IsTrue(nextButton.Displayed, "Next button is not displayed.");
        }
        public void PrevButton()
        {
            TestContext.Progress.WriteLine("TestID: FCN_054");
            CommonFunctions.WaitForCondition(driver, prevButton, 5);
            prevButton.Click();
            Assert.IsTrue(prevButton.Displayed, "Previous button is not displayed.");
        }
        public void HomeNavBar()
        {
            TestContext.Progress.WriteLine("TestID: FCN_052");
            CommonFunctions.WaitForCondition(driver, homeNav, 5);
            homeNav.Click();
            Assert.IsTrue(homeNav.Displayed, "Home Navigation button is not displayed.");
        }

    }
}
