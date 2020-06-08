using Autotests.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Linq;

namespace Autotests.Pages
{
    class ManageFoldersPage : PageObject
    {
        public ManageFoldersPage(IWebDriver driver) : base(driver) { }

        public IWebElement AddMainFolderButton => _driver.FindElement(By.XPath("//i[@class='btn fa fa-plus btn-plus btn-add-new-folder']"));
        public IWebElement ActiveFolderNameField => _driver.FindElement(By.XPath("//input[@class='folder-name form-control input-active']"));
        public IWebElement SortingArrows => _driver.FindElement(By.XPath("//i[@class='btn btn-sort-style']"));
        public IWebElement SaveChangesAndCloseButton => _driver.FindElement(By.Id("btnSubmit"));
        public IWebElement ParentFolderFromAutoTest => _driver.FindElement(By.XPath("//input[@value='ParentFolderFromAutoTest']"));
        public IWebElement DeleteButton => _driver.FindElement(By.XPath("//input[@value='ParentFolderFromAutoTest']//parent::div//parent::div//parent::div//parent::div//button[@onclick='removeFolder(this)']"));
        //input[@value='ParentFolderFromAutoTest']//ancestor::div[@data-forlder-id='{id}']//button[@onclick='removeFolder(this)']"
        public IWebElement DeleteFolderConfirmWindow => _driver.FindElement(By.CssSelector("div[class*='modal fade show']"));
        public IWebElement ConfirmButton => _driver.FindElement(By.CssSelector("button[onclick*='confirmDeleteFolder()']"));


        public ManageFoldersPage OpenManageFoldersPage()
        {
            _driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/AssetManagement/ManageFolders");
            return this;
        }
        public ManageFoldersPage ClickAddMainFolderButton()
        {
            AddMainFolderButton.Click();
            Wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            Wait.Until(_driver => _driver.FindElements(By.XPath("//input[@class='folder-name form-control input-active']")).Any() == true);
            return this;
        }
        public ManageFoldersPage TypeNewFolderName()
        {
            ActiveFolderNameField.SendKeys("ParentFolderFromAutoTest");
            return this;
        }
        public ManageFoldersPage ClickSortingArrows()
        {
            SortingArrows.Click();
            return this;
        }
        public ManageFoldersPage ClickSaveChangesAndCloseButton()
        {
            SaveChangesAndCloseButton.Click();
            return this;
        }
        public ManageFoldersPage ClickParentFolderFromAutoTest()
        {
            ParentFolderFromAutoTest.Click();
            return this;
        }
        public ManageFoldersPage ClickDeleteButton()
        {
            DeleteButton.Click();
            //Wait.Until(_driver => DeleteFolderConfirmWindow.Displayed);
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("div[class*='modal fade show']")));
            return this;
        }
        public ManageFoldersPage ClickConfirmDeleteButton()
        {
            ConfirmButton.Click();
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='spinner-wrap']")));
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='spinner-wrap']")));
            return this;
        }
        public ManageFoldersPage ClearDownloads()
        {
            string[] Files = Directory.GetFiles(DownloadsFolderPath);
            foreach (string file in Files)
            {
                File.Delete(file);
            }
            return this;
        }
    }
}
