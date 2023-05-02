using DemoblazeAutomationScript1.PageObjects;
using DemoblazeAutomationScript1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeAutomationScript1.Tests
{
    internal class GUITestSignUp: Base
    {

        public SignupPage signupPage;

        [SetUp]
        public void SetUp()
        {
            signupPage = new SignupPage(driver);
        }
        [Test]
        public void BorderColourChangeUsername()
        {
            //SignupPage signupPage = new SignupPage(driver);
            signupPage.BorderColourChangeUsername();

        }
        [Test]
        public void BorderColourChangePassword()
        {
            //SignupPage signupPage = new SignupPage(driver);
            signupPage.BorderColourChangePassword();

        }
        /*[Test]
        public void BorderColourChangeButton()
        {
            //SignupPage signupPage = new SignupPage(driver);
            signupPage.BorderColourChangeButton();

        }*/
        [Test]
        public void BackgroundColourChangeButton()
        {
            //SignupPage signupPage = new SignupPage(driver);
            signupPage.BackgroundColourChangeButton();

        }

    }
}
