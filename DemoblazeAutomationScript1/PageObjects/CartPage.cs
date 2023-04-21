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
    internal class CartPage
    {
        IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//img[@src='imgs/Lumia_1520.jpg']")]
        private IWebElement productCard;

        [FindsBy(How = How.XPath, Using = "//a[@onclick='addToCart(2)']")]
        private IWebElement addToCartButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='cart.html']")]
        private IWebElement cartNav;

        [FindsBy(How = How.XPath, Using = "//tbody[@id='tbodyid']")]
        private IWebElement cartDetails;

        [FindsBy(How = How.XPath, Using = "//button[@data-target='#orderModal']")]
        private IWebElement placeOrderButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='name']")]
        private IWebElement nameTextField;

        [FindsBy(How = How.XPath, Using = "//input[@id='country']")]
        private IWebElement countryTextField;

        [FindsBy(How = How.XPath, Using = "//input[@id='city']")]
        private IWebElement cityTextField;

        [FindsBy(How = How.XPath, Using = "//input[@id='card']")]
        private IWebElement cardTextField;

        [FindsBy(How = How.XPath, Using = "//input[@id='month']")]
        private IWebElement monthTextField;

        [FindsBy(How = How.XPath, Using = "//input[@id='year']")]
        private IWebElement yearTextField;

        [FindsBy(How = How.XPath, Using = "//button[@onclick='purchaseOrder()']")]
        private IWebElement confirmOrderButton;

        [FindsBy(How = How.XPath, Using = "//p[@class='lead text-muted ']")]
        private IWebElement purchaseReceipt;

        [FindsBy(How = How.XPath, Using = "//button[@class='confirm btn btn-lg btn-primary']")]
        private IWebElement receiptButtonOK;

        [FindsBy(How = How.LinkText, Using = "Delete")]
        private IWebElement deleteLinkText;

        [FindsBy(How = How.XPath, Using = "//a[@onclick='logOut()']")]
        private IWebElement logOutNav;

        public void ProductsAddedWhenLoggedOutSteps()
        {
            Thread.Sleep(3000);
            productCard.Click();
            Thread.Sleep(3000);
            string childWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(childWindow);
            addToCartButton.Click();
            Thread.Sleep(3000);
            string strAlert = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine(strAlert);
            driver.SwitchTo().Alert().Accept();
            cartNav.Click();
            TestContext.Progress.WriteLine("products in Cart:");
            Thread.Sleep(5000);
            TestContext.Progress.WriteLine(cartDetails.Text);
        }

        public void PlaceOrderSteps(string name, string country, string city, string card, string month, string year, string testID)
        {
            cartNav.Click();
            placeOrderButton.Click();
            Thread.Sleep(3000);
            nameTextField.SendKeys(name);
            countryTextField.SendKeys(country);
            cityTextField.SendKeys(city);
            cardTextField.SendKeys(card);
            monthTextField.SendKeys(month);
            yearTextField.SendKeys(year);
            TestContext.Progress.WriteLine("TestID: "+ testID);
            TestContext.Progress.WriteLine("Name: " + name);
            TestContext.Progress.WriteLine("Country: " + country);
            TestContext.Progress.WriteLine("City: " + city);
            TestContext.Progress.WriteLine("Card: " + card);
            TestContext.Progress.WriteLine("Month: " + month);
            TestContext.Progress.WriteLine("Year: " + year);
            confirmOrderButton.Click();

            try
            {
                //If alert is present, print alert message
                //TestContext.Progress.WriteLine("When name or card details are not filled:");
                string strAlert = driver.SwitchTo().Alert().Text;
                TestContext.Progress.WriteLine("Outcome: "+strAlert);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                driver.Navigate().Refresh();
                driver.FindElement(By.XPath("//a[@href='index.html']")).Click();
                Thread.Sleep(5000);
            }
            catch (NoAlertPresentException)
            {
                //if alert is not present, print Thank you for your purchase and display order receipt
                //TestContext.Progress.WriteLine("When name or card details are filled:");
                TestContext.Progress.WriteLine("Outcome: Thank you for your purchase!");
                TestContext.Progress.WriteLine(purchaseReceipt.Text);
                Thread.Sleep(3000);
                receiptButtonOK.Click();
            }
            


        }

        public void DeleteOrderSteps()
        {
            Thread.Sleep(3000);
            productCard.Click();
            Thread.Sleep(3000);
            string childWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(childWindow);
            addToCartButton.Click();
            Thread.Sleep(3000);
            string strAlert = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine(strAlert);
            driver.SwitchTo().Alert().Accept();
            cartNav.Click();
            TestContext.Progress.WriteLine("products in Cart before delete:");
            Thread.Sleep(5000);
            TestContext.Progress.WriteLine(cartDetails.Text);
            deleteLinkText.Click();
            Thread.Sleep(5000);
            TestContext.Progress.WriteLine("products in Cart after delete:");
            Thread.Sleep(5000);
            TestContext.Progress.WriteLine(cartDetails.Text);
        }

        public void CacheRetentionSteps()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithoutTestID("hrithik1", "hrithik");

            CartPage cartPage = new CartPage(driver);
            cartPage.ProductsAddedWhenLoggedOutSteps();

            LogOutPage logOut = new LogOutPage(driver);
            logOut.LogOutSteps();
            Thread.Sleep(3000);

            loginPage.LoginWithoutTestID("hrithik1", "hrithik");
            Thread.Sleep(3000);

            cartNav.Click();

            TestContext.Progress.WriteLine("products after re-logging in:");
            Thread.Sleep(5000);
            TestContext.Progress.WriteLine(cartDetails.Text);
        }

        public void CacheRemovalAfterLoggingoutSteps()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithoutTestID("hrithik1", "hrithik");

            CartPage cartPage = new CartPage(driver);
            cartPage.ProductsAddedWhenLoggedOutSteps();

            logOutNav.Click();

            cartNav.Click();
            TestContext.Progress.WriteLine("products when logged out:");
            Thread.Sleep(5000);
            TestContext.Progress.WriteLine(cartDetails.Text);
        }

        public void BorderColourChangeName()
        {
            TestContext.Progress.WriteLine("TestID: GUI_037");
            cartNav.Click();
            string beforeColor = nameTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            nameTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = nameTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeCountry()
        {
            TestContext.Progress.WriteLine("TestID: GUI_038");

            cartNav.Click();
            string beforeColor = countryTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            countryTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = countryTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeCity()
        {
            TestContext.Progress.WriteLine("TestID: GUI_039");

            cartNav.Click();
            string beforeColor = cityTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            cityTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = cityTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeCard()
        {
            TestContext.Progress.WriteLine("TestID: GUI_040");

            cartNav.Click();
            string beforeColor = cardTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            cardTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = cardTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeMonth()
        {
            TestContext.Progress.WriteLine("TestID: GUI_041");

            cartNav.Click();
            string beforeColor = monthTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            monthTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = monthTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeYear()
        {
            TestContext.Progress.WriteLine("TestID: GUI_042");

            cartNav.Click();
            string beforeColor = yearTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            yearTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = yearTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BorderColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_043");

            cartNav.Click();
            string beforeColor = confirmOrderButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            confirmOrderButton.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = confirmOrderButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BackgroundColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_074");

            cartNav.Click();
            string beforeColor = confirmOrderButton.GetCssValue("background-color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(confirmOrderButton).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = confirmOrderButton.GetCssValue("background-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BackgroundColourChangeButtonAddToCart()
        {
            TestContext.Progress.WriteLine("TestID: GUI_077");

            Thread.Sleep(3000);
            productCard.Click();
            Thread.Sleep(3000);
            string childWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(childWindow);
            string beforeColor = addToCartButton.GetCssValue("background-color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(addToCartButton).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = addToCartButton.GetCssValue("background-color");
            TestContext.Progress.WriteLine(afterColor);

        }
        public void BackgroundColourChangeButtonPurchaseOrder()
        {
            TestContext.Progress.WriteLine("TestID: GUI_076");

            cartNav.Click();
            string beforeColor = placeOrderButton.GetCssValue("background-color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(placeOrderButton).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = placeOrderButton.GetCssValue("background-color");
            TestContext.Progress.WriteLine(afterColor);

        }
    }
}
