using Autotests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using System.IO;

namespace Autotests.Pages
{
    class UploadFromWindowPage : PageObject
    {
        public UploadFromWindowPage(IWebDriver driver) : base(driver) { }


        public IWebElement ManualEntryComputerIcon => _driver.FindElement(By.XPath("//div[@id='chooseTypeOfLoad']//input[@onchange='handleSingleFileSelect()']"));

        public IWebElement BatchComputerIcon => _driver.FindElement(By.XPath("//div[@id='chooseTypeOfLoadBatch']//input[@onchange='handleBatchFileSelect()']"));

        public IWebElement ManualCloseIcon => _driver.FindElement(By.XPath("//div[@id='chooseTypeOfLoad']//i[@class='fa fa-times']"));

        public IWebElement BatchCloseIcon => _driver.FindElement(By.XPath("//div[@id='chooseTypeOfLoadBatch']//i[@class='fa fa-times']"));

        public IWebElement OneDriverIcon => _driver.FindElement(By.Id("btnSubmitOneDriveSingle"));

        public IWebElement DropBoxIcon => _driver.FindElement(By.Id("btnSubmitDropBoxSingle"));

        public IWebElement UploadButton => _driver.FindElement(By.Id("btnSubmit"));

        public IWebElement FilesContainer => _driver.FindElement(By.XPath("//div[@id='drop_file_zone']//input[@id='selectfile']"));


        public UploadFromWindowPage ClickManualEntryComputerIcon()
        {
            Actions act = new Actions(_driver);
            act.MoveToElement(ManualEntryComputerIcon);
            act.Click();
            act.Build().Perform();
            return this;
        }
        public UploadFromWindowPage ClickBatchComputerIcon()
        {
            Actions act = new Actions(_driver);
            act.MoveToElement(BatchComputerIcon);
            act.Click();
            act.Build().Perform();
            return this;
        }
        public UploadFromWindowPage SendPathManualEntry(string filePath)
        {
            Thread.Sleep(900);
            ManualEntryComputerIcon.SendKeys(SetFilePath(filePath));
            Thread.Sleep(900);
            return this;
        }
        public UploadFromWindowPage SendPathBatch(string filePath)
        {
            Thread.Sleep(900);
            BatchComputerIcon.SendKeys(SetFilePath(filePath));
            Thread.Sleep(900);
            return this;
        }
        public UploadFromWindowPage ClickOneDriveIcon()
        {
            Thread.Sleep(900);
            OneDriverIcon.Click();
            return this;
        }
        public UploadFromWindowPage WaitForPageUpload()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("idSIButton9")));
            return this;
        }
        public UploadFromWindowPage ClickDropBoxIcon()
        {
            DropBoxIcon.Click();
            return this;
        }
        public UploadFromWindowPage ClearOneDriveCookies()
        {
            Cookie cookie = _driver.Manage().Cookies.GetCookieNamed("OneDriveAccessToken");
            _driver.Manage().Cookies.DeleteCookie(cookie);
            return this;
            //var cookies = _driver.Manage().Cookies.AllCookies;
            //foreach(var cookie in cookies)
            //{

            //}

        }
        //public UploadFromWindowPage ClearDropBoxCookies()
        //{

        //}
    }
}
