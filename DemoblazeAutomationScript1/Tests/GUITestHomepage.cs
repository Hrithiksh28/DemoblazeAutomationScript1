using AngleSharp.Dom;
using DemoblazeAutomationScript1.PageObjects;
using DemoblazeAutomationScript1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.Tests
{
    internal class GUITestHomepage:Base
    {
        //HomePage homePage = new HomePage(driver);
        public HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(driver);
        }


        [Test]
        public void NavbuttonColourChangeSignUpNav()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.NavbuttonColourChangeSignUpNav();


        }
        [Test]
        public void NavbuttonColourChangeHomeNav()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.NavbuttonColourChangeHomeNav();

        }
        [Test]
        public void NavbuttonColourChangeContactNav()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.NavbuttonColourChangeContactNav();

        }
        [Test]
        public void NavbuttonColourChangeAboutUsNav()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.NavbuttonColourChangeAboutUsNav();

        }
        [Test]
        public void NavbuttonColourChangeCartNav()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.NavbuttonColourChangeCartNav();

        }
        [Test]
        public void NavbuttonColourChangeLoginNav()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.NavbuttonColourChangeLoginNav();

        }
        [Test]
        public void ProductCardUnderline()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.ProductCardUnderline();

        }
        [Test]
        public void BackgroundColourChangeNext()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.BackgroundColourChangeNext();

        }
        [Test]
        public void BackgroundColourChangePrevious()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.BackgroundColourChangePrevious();

        }

        [Test]
        public void FooterContent()
        {
            //HomePage homePage = new HomePage(driver);
            homePage.FooterContent();
        }

       }

    }
