using AngleSharp.Dom;
using DemoblazeAutomationScript1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoblazeAutomationScript1.PageObjects
{
    internal class AboutusPage
    {
        private IWebDriver driver;
        public CommonFunctions function;

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public AboutusPage(IWebDriver driver)
        {
            this.driver = driver;
            function = new CommonFunctions(driver);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@data-target='#videoModal']")]
        private IWebElement aboutusNav;

        [FindsBy(How = How.XPath, Using = "//div[@class='vjs-poster']")]
        private IWebElement startVideo;

        [FindsBy(How = How.XPath, Using = "//button[@class='vjs-play-control vjs-control vjs-button vjs-playing']")]
        private IWebElement pauseVideo;

        [FindsBy(How = How.XPath, Using = "//button[@class='vjs-play-control vjs-control vjs-button vjs-paused']")]
        private IWebElement resumeVideo;

        [FindsBy(How = How.XPath, Using = "//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-3']")]
        private IWebElement volumeControlVideo3;

        [FindsBy(How = How.XPath, Using = "//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-2']")]
        private IWebElement volumeControlVideo2;

        [FindsBy(How = How.XPath, Using = "//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-1']")]
        private IWebElement volumeControlVideo1;

        [FindsBy(How = How.XPath, Using = "//button[@class='vjs-mute-control vjs-control vjs-button vjs-vol-0']")]
        private IWebElement muteVideo;

        [FindsBy(How = How.XPath, Using = "//button[@title='Picture-in-Picture']")]
        private IWebElement pictureinpictureVideo;

        [FindsBy(How = How.XPath, Using = "//button[@title='Exit Picture-in-Picture']")]
        private IWebElement exitPictureinpictureVideo;

        [FindsBy(How = How.XPath, Using = "//button[@title='Fullscreen']")]
        private IWebElement fullscreenVideo;

        [FindsBy(How = How.XPath, Using = "//button[@title='Non-Fullscreen']")]
        private IWebElement nonFullscreenVideo;

       /* public void waitForDisplay()
        {
            aboutusNav.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vjs-poster']")));
        }*/
        public void VideoStart()
        {
            TestContext.Progress.WriteLine("TestID: FCN_022");
            aboutusNav.Click();
            CommonFunctions.waitForDisplay(driver,5);
            startVideo.Click(); 
        }

        public void VideoPause()
        {
            TestContext.Progress.WriteLine("TestID: FCN_023");
            aboutusNav.Click();
            CommonFunctions.waitForDisplay(driver,5);
            startVideo.Click();
            pauseVideo.Click();

        }

        public void VideoResume()
        {
            TestContext.Progress.WriteLine("TestID: FCN_024");
            aboutusNav.Click();
            CommonFunctions.waitForDisplay(driver,5);
            startVideo.Click();
            pauseVideo.Click();
            resumeVideo.Click();
        }
        
        public void VideoVolumeControl()
        {
            TestContext.Progress.WriteLine("TestID: FCN_025");
            aboutusNav.Click();
            CommonFunctions.waitForDisplay(driver,5);
            startVideo.Click();
            if (volumeControlVideo3.Displayed)
            {
                volumeControlVideo3.Click();
                muteVideo.Click();
            }
            else if(volumeControlVideo2.Displayed)
            {
                volumeControlVideo2.Click();
                muteVideo.Click();
            }
            else
            {
                volumeControlVideo1.Click();
                muteVideo.Click();
            }
        }

        /*public IWebElement WaitForCondition(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }*/

        public void PictureinpictureVideo()
        {
            TestContext.Progress.WriteLine("TestID: FCN_027");
            aboutusNav.Click();
            CommonFunctions.waitForDisplay(driver,5);
            startVideo.Click();
            CommonFunctions.WaitForCondition(driver,pictureinpictureVideo,5);
            pictureinpictureVideo.Click();
            CommonFunctions.WaitForCondition(driver,exitPictureinpictureVideo,5);
            exitPictureinpictureVideo.Click();
        }

        public void FullscreenVideo()
        {
            TestContext.Progress.WriteLine("TestID: FCN_026");
            aboutusNav.Click();
            CommonFunctions.waitForDisplay(driver,5);
            startVideo.Click();
            CommonFunctions.WaitForCondition(driver, fullscreenVideo,5);
            fullscreenVideo.Click();
            CommonFunctions.WaitForCondition(driver,nonFullscreenVideo, 5);
            nonFullscreenVideo.Click();
        }



    }
}
