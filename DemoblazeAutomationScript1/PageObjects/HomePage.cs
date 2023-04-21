using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

        }
        public void FooterContent()
        {
            TestContext.Progress.WriteLine("TestID: GUI_081");
            IWebElement footerContent = footer;
            TestContext.Progress.WriteLine(footerContent.Text);
        }

    }
}
