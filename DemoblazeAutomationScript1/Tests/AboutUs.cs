using DemoblazeAutomationScript1.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V109.Debugger;
using DemoblazeAutomationScript1.PageObjects;

namespace DemoblazeAutomationScript1.Tests
{
    internal class AboutUs:Base
    {
        

        [Test]
        public void AboutVideoStart()
        {
            /*driver.FindElement(By.XPath("//a[@data-target='#videoModal']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vjs-poster']")));
            driver.FindElement(By.XPath("//div[@class='vjs-poster']")).Click();*/

            AboutusPage aboutusPage = new AboutusPage(driver);
            aboutusPage.VideoStart();
        }

        [Test]
        public void AboutVideoPause()
        {
            /*driver.FindElement(By.XPath("//a[@data-target='#videoModal']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vjs-poster']")));
            driver.FindElement(By.XPath("//div[@class='vjs-poster']")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//button[@class='vjs-play-control vjs-control vjs-button vjs-playing']")).Click();*/

            AboutusPage aboutusPage = new AboutusPage(driver);
            aboutusPage.VideoPause();
        }
        [Test]
        public void AboutVideoResume()
        {
           /* driver.FindElement(By.XPath("//a[@data-target='#videoModal']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vjs-poster']")));
            driver.FindElement(By.XPath("//div[@class='vjs-poster']")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//button[@class='vjs-play-control vjs-control vjs-button vjs-playing']")).Click(); 
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//button[@class='vjs-play-control vjs-control vjs-button vjs-paused']")).Click();*/

            AboutusPage aboutusPage = new AboutusPage(driver);
            aboutusPage.VideoResume();

        }
        [Test]
        public void AboutVideoVolumeControl()
        {
            /*driver.FindElement(By.XPath("//a[@data-target='#videoModal']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vjs-poster']")));
            driver.FindElement(By.XPath("//div[@class='vjs-poster']")).Click();
            Thread.Sleep(5000);

            //Mute Video from any level
            if (driver.FindElement(By.XPath("//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-3']")).Displayed)
            {
                driver.FindElement(By.XPath("//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-3']")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-0']")).Click();
            }
            else if(driver.FindElement(By.XPath("//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-2']")).Displayed)
            {
                driver.FindElement(By.XPath("//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-2']")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-0']")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-1']")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-0']")).Click();
            }*/

            AboutusPage aboutusPage = new AboutusPage(driver);
            aboutusPage.VideoVolumeControl();
        }
        [Test]
        public void AboutVideoPictureInPicture()
        {
            /*driver.FindElement(By.XPath("//a[@data-target='#videoModal']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vjs-poster']")));
            driver.FindElement(By.XPath("//div[@class='vjs-poster']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@title='Picture-in-Picture']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@title='Exit Picture-in-Picture']")).Click();*/

            AboutusPage aboutusPage = new AboutusPage(driver);
            aboutusPage.PictureinpictureVideo();
        }
        [Test]
        public void AboutVideoFullscreen()
        {
            /*driver.FindElement(By.XPath("//a[@data-target='#videoModal']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vjs-poster']")));
            driver.FindElement(By.XPath("//div[@class='vjs-poster']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@title='Fullscreen']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@title='Non-Fullscreen']")).Click();*/

            AboutusPage aboutusPage = new AboutusPage(driver);
            aboutusPage.FullscreenVideo();
        }
    }
}
