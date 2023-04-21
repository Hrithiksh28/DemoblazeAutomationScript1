using DemoblazeAutomationScript1.PageObjects;
using DemoblazeAutomationScript1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.Tests
{
    internal class GUITestCart: Base
    {
        [Test]
        public void BorderColourChangeName()
        {
            CartPage cartpage = new CartPage(driver);
            cartpage.BorderColourChangeName();

        }
        [Test]
        public void BorderColourChangeCountry()
        {
            CartPage cartpage = new CartPage(driver);
            cartpage.BorderColourChangeCountry();

        }
        [Test]
        public void BorderColourChangeCity()
        {
            CartPage cartpage = new CartPage(driver);
            cartpage.BorderColourChangeCity();

        }
        [Test]
        public void BorderColourChangeCard()
        {
            CartPage cartpage = new CartPage(driver);
            cartpage.BorderColourChangeCard();

        }
        [Test]
        public void BorderColourChangeMonth()
        {
            CartPage cartpage = new CartPage(driver);
            cartpage.BorderColourChangeMonth();

        }
        [Test]
        public void BorderColourChangeYear()
        {
            CartPage cartpage = new CartPage(driver);
            cartpage.BorderColourChangeYear();

        }
        [Test]
        public void BorderColourChangeButton()
        {
            CartPage cartPage = new CartPage(driver);
            cartPage.BorderColourChangeButton();

        }
        [Test]
        public void BackgroundColourChangeButton()
        {
            CartPage cartPage = new CartPage(driver);
            cartPage.BackgroundColourChangeButton();

        }
        [Test]
        public void BackgroundColourChangeButtonAddToCart()
        {
            CartPage cartPage = new CartPage(driver);
            cartPage.BackgroundColourChangeButtonAddToCart();

        }
        [Test]
        public void BackgroundColourChangeButtonPurchaseOrder()
        {
            CartPage cartPage = new CartPage(driver);
            cartPage.BackgroundColourChangeButtonPurchaseOrder();

        }
    }
}
