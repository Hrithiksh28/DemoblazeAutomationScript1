using DemoblazeAutomationScript1.PageObjects;
using DemoblazeAutomationScript1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.Tests
{
    internal class GUITestContact: Base
    {
        ContactPage contactPage;

        [SetUp]
        public void SetUp()
        {
            contactPage = new ContactPage(driver);
        }
        [Test]
        public void BorderColourChangeEmail()
        {
            //ContactPage contactPage = new ContactPage(driver);
            contactPage.BorderColourChangeEmail();

        }
        [Test]
        public void BorderColourChangeName()
        {
            //ContactPage contactPage = new ContactPage(driver);
            contactPage.BorderColourChangeName();

        }
        [Test]
        public void BorderColourChangeMessage()
        {
            //ContactPage contactPage = new ContactPage(driver);
            contactPage.BorderColourChangeMessage();

        }
        /*[Test]
        public void BorderColourChangeButton()
        {
            //ContactPage contactPage = new ContactPage(driver);
            contactPage.BorderColourChangeButton();

        }*/
        [Test]
        public void BackgroundColourChangeButton()
        {
            //ContactPage contactPage = new ContactPage(driver);
            contactPage.BackgroundColourChangeButton();

        }
    }
}
