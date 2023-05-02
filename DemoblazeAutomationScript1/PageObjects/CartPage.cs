using DemoblazeAutomationScript1.Utilities;
using MongoDB.Bson.Serialization.IdGenerators;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.PageObjects
{
    internal class CartPage
    {
        public IWebDriver driver;
        public CommonFunctions function;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            function = new CommonFunctions(driver);
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
            CommonFunctions.WaitForCondition(driver,productCard, 5);
            productCard.Click();
            CommonFunctions.WaitForCondition(driver,addToCartButton, 5);
            //WaitForCondition(addToCartButton);
            string childWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(childWindow);
            addToCartButton.Click();
            CommonFunctions.WaitForAlert(driver, 5);
            string strAlert = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine(strAlert);
            driver.SwitchTo().Alert().Accept();
            cartNav.Click();
            TestContext.Progress.WriteLine("products in Cart:");
            CommonFunctions.WaitForCondition(driver,deleteLinkText, 5);
            TestContext.Progress.WriteLine(cartDetails.Text);

            Assert.IsTrue(cartDetails.Text.Contains(productCard.Text), "Product is not added");
        }
        public void PlaceOrderSteps(string name, string country, string city, string card, string month, string year, string testID)
        {
            CommonFunctions.WaitForCondition(driver,cartNav, 5);
            cartNav.Click();
            placeOrderButton.Click();
            CommonFunctions.WaitForCondition(driver,nameTextField, 5);
            nameTextField.SendKeys(name);
            countryTextField.SendKeys(country);
            cityTextField.SendKeys(city);
            cardTextField.SendKeys(card);
            monthTextField.SendKeys(month);
            yearTextField.SendKeys(year);
            TestContext.Progress.WriteLine("TestID: " + testID);
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
                TestContext.Progress.WriteLine("Outcome: " + strAlert);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                driver.Navigate().Refresh();
                driver.FindElement(By.XPath("//a[@href='index.html']")).Click();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(NoAlertPresentException))
                {
                    //if alert is not present, print Thank you for your purchase and display order receipt
                    //TestContext.Progress.WriteLine("When name or card details are filled:");
                    TestContext.Progress.WriteLine("Outcome: Thank you for your purchase!");

                    Assert.IsTrue(driver.PageSource.Contains("Thank you for your purchase!"));
                    Assert.IsTrue(purchaseReceipt.Text.Contains("Name: " + name));
                    Assert.IsTrue(purchaseReceipt.Text.Contains("Card Number: " + card));
                    Regex orderIdRegex = new Regex("[0-9]{7}");
                    Assert.IsTrue(orderIdRegex.IsMatch(purchaseReceipt.Text));


                    TestContext.Progress.WriteLine(purchaseReceipt.Text);
                    CommonFunctions.WaitForCondition(driver,receiptButtonOK, 5);
                    receiptButtonOK.Click();
                    driver.Navigate().Refresh();
                    driver.FindElement(By.XPath("//a[@href='index.html']")).Click();
                }
                else
                {
                    throw ex;
                }
            }


        }

        public void DeleteOrderSteps()
        {
            CommonFunctions.WaitForCondition(driver,productCard, 5);
            productCard.Click();
            CommonFunctions.WaitForCondition(driver, addToCartButton, 5);
            string childWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(childWindow);
            addToCartButton.Click();
            CommonFunctions.WaitForAlert(driver, 5);
            string strAlert = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine(strAlert);
            driver.SwitchTo().Alert().Accept();
            cartNav.Click();
            TestContext.Progress.WriteLine("products in Cart before delete:");
            CommonFunctions.WaitForCondition(driver,deleteLinkText, 5);
            string cartDetailsBeforeDelete = cartDetails.Text;
            TestContext.Progress.WriteLine(cartDetails.Text);
            deleteLinkText.Click();
            driver.Navigate().Refresh();
            //CommonFunctions.WaitForCondition(driver,deleteLinkText);
            TestContext.Progress.WriteLine("products in Cart after delete:");
            CommonFunctions.WaitForCondition(driver,cartDetails, 5);
            string cartDetailsAfterDelete = cartDetails.Text;
            TestContext.Progress.WriteLine(cartDetails.Text);

            Assert.AreNotEqual(cartDetailsBeforeDelete, cartDetailsAfterDelete, "Cart Details are not Deleted");

        }

        public void CacheRetentionSteps()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithoutTestID("hrithik1", "hrithik");

            CartPage cartPage = new CartPage(driver);
            cartPage.ProductsAddedWhenLoggedOutSteps();

            string cartDetailsFirstTime = cartDetails.Text;

            LogOutPage logOut = new LogOutPage(driver);
            logOut.LogOutSteps();
            Thread.Sleep(3000);

            loginPage.LoginWithoutTestID("hrithik1", "hrithik");
            CommonFunctions.WaitForCondition(driver,cartNav,5);

            cartNav.Click();

            TestContext.Progress.WriteLine("products after re-logging in:");
            CommonFunctions.WaitForCondition(driver,deleteLinkText, 5);
            string cartDetailsSecondTime = cartDetails.Text;
            TestContext.Progress.WriteLine(cartDetails.Text);

            Assert.AreEqual(cartDetailsFirstTime, cartDetailsSecondTime, "Cart Details are not Same");
        }

        public void CacheRemovalAfterLoggingoutSteps()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginWithoutTestID("hrithik1", "hrithik");

            CartPage cartPage = new CartPage(driver);
            cartPage.ProductsAddedWhenLoggedOutSteps();

            CommonFunctions.WaitForCondition(driver,logOutNav, 5);
            logOutNav.Click();

            cartNav.Click();
            TestContext.Progress.WriteLine("products when logged out:");
            //CommonFunctions.WaitForCondition(deleteLinkText);
            Thread.Sleep(3000);
            TestContext.Progress.WriteLine(cartDetails.Text);

            Assert.IsTrue(string.IsNullOrEmpty(cartDetails.Text.Trim()), "Cart is not empty after logging out");

        }

        public void BorderColourChangeName()
        {
            
            TestContext.Progress.WriteLine("TestID: GUI_037");
            cartNav.Click();
            placeOrderButton.Click();
            CommonFunctions.WaitForCondition(driver,nameTextField, 5);
            string beforeColor = nameTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            nameTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = nameTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);


        }
        public void BorderColourChangeCountry()
        {

            TestContext.Progress.WriteLine("TestID: GUI_038");
            cartNav.Click();
            placeOrderButton.Click();
            CommonFunctions.WaitForCondition(driver,nameTextField, 5);
            string beforeColor = countryTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            countryTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = countryTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);


        }
        public void BorderColourChangeCity()
        {
            TestContext.Progress.WriteLine("TestID: GUI_039");
            
            cartNav.Click();
            placeOrderButton.Click();
            CommonFunctions.WaitForCondition(driver,nameTextField, 5);
            string beforeColor = cityTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            cityTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = cityTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);


        }
        public void BorderColourChangeCard()
        {
            TestContext.Progress.WriteLine("TestID: GUI_040");

            cartNav.Click();
            placeOrderButton.Click();
            CommonFunctions.WaitForCondition(driver,nameTextField, 5);
            string beforeColor = cardTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            cardTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = cardTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);


        }
        public void BorderColourChangeMonth()
        {
            TestContext.Progress.WriteLine("TestID: GUI_041");
            
            cartNav.Click();
            placeOrderButton.Click();
            CommonFunctions.WaitForCondition(driver,nameTextField, 5);
            string beforeColor = monthTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            monthTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = monthTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);


        }
        public void BorderColourChangeYear()
        {
            TestContext.Progress.WriteLine("TestID: GUI_042");
            
            cartNav.Click();
            placeOrderButton.Click();
            CommonFunctions.WaitForCondition(driver,nameTextField, 5);
            string beforeColor = yearTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            yearTextField.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = yearTextField.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);


        }
        public void BorderColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_043");
            
            cartNav.Click();
            placeOrderButton.Click();
            CommonFunctions.WaitForCondition(driver,nameTextField, 5);
            string beforeColor = confirmOrderButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine("Before CLicking");
            TestContext.Progress.WriteLine(beforeColor);
            confirmOrderButton.Click();
            TestContext.Progress.WriteLine("After Clicking");
            string afterColor = confirmOrderButton.GetCssValue("border-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);


        }
        public void BackgroundColourChangeButton()
        {
            TestContext.Progress.WriteLine("TestID: GUI_074");
            
            cartNav.Click();
            placeOrderButton.Click();
            CommonFunctions.WaitForCondition(driver,nameTextField, 5);
            string beforeColor = confirmOrderButton.GetCssValue("background-color");
            TestContext.Progress.WriteLine("Before Hovering");
            TestContext.Progress.WriteLine(beforeColor);
            Actions action = new Actions(driver);
            action.MoveToElement(confirmOrderButton).Perform();
            TestContext.Progress.WriteLine("After Hovering");
            string afterColor = confirmOrderButton.GetCssValue("background-color");
            TestContext.Progress.WriteLine(afterColor);

            Assert.AreNotEqual(beforeColor, afterColor);


        }
        public void BackgroundColourChangeButtonAddToCart()
        {
            TestContext.Progress.WriteLine("TestID: GUI_077");

            CommonFunctions.WaitForCondition(driver,productCard, 5);
            productCard.Click();
            CommonFunctions.WaitForCondition(driver,addToCartButton, 5);
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

            Assert.AreNotEqual(beforeColor, afterColor);


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

            Assert.AreNotEqual(beforeColor, afterColor);


        }
    }
}
