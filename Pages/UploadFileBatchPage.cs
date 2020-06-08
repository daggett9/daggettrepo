using Autotests.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using SeleniumExtras.WaitHelpers;

namespace Autotests.Pages
{
    class UploadFileBatchPage : PageObject
    {
        public UploadFileBatchPage(IWebDriver driver) : base(driver) { }

        public IWebElement BatchUploadTab => _driver.FindElement(By.Id("batch-upload-tab"));

        public IWebElement FolderToSave => _driver.FindElement(By.CssSelector("span#select2-folder-breakdown-container+span"));

        public IWebElement SubFolderToSave => _driver.FindElement(By.CssSelector("span#select2-subFolder-breakdown-container+span"));

        public IWebElement ChooseFileButton => _driver.FindElement(By.Id("batchFiles"));

        public IWebElement FilesContainer => _driver.FindElement(By.Id("drop_file_zone"));

        public IWebElement UploadButton => _driver.FindElement(By.Id("btnSubmitBatch"));

        public IWebElement UploadFromWindow => _driver.FindElement(By.XPath("//div[@class='tab-content']"));

        public IWebElement LeavePageWindow => _driver.FindElement(By.Id("leaveTabModal"));

        public IWebElement ConfirmButton => _driver.FindElement(By.Id("buttonConfirmOpenTab"));


        public UploadFileBatchPage OpenUploadFilePage()
        {
            _driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/AssetManagement/UploadFile");
            return this;
        }
        public UploadFileBatchPage ClickBatchUploadTab()
        {
            BatchUploadTab.Click();
            return this;
        }
        public UploadFileBatchPage ConfirmLeavePageWindow()
        {
            Wait.Until(_driver => LeavePageWindow.Displayed);
            ConfirmButton.Click();
            Wait.Until(_driver => _driver.FindElement(By.CssSelector("span#select2-folder-breakdown-container+span")).Displayed);
            return this;
        }
        public UploadFileBatchPage SelectFromDD(string CssSelector, string TextValueFromDD)
        {
            IList<IWebElement> DDSelection = _driver.FindElements(By.CssSelector(CssSelector));
            foreach (IWebElement element in DDSelection)
            {
                if (element.Text.Equals(TextValueFromDD))
                {
                    element.Click();
                    return this;
                }
            }
            return this;
        }
        public UploadFileBatchPage SelectParentFolderToSave()
        {
            FolderToSave.Click();
            SelectFromDD("li[class*='select2-results__option']", "ParentFolderFromAutoTest");
            //Wait.Until(_driver => SubFolderToSave.Displayed);
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='spinner-wrap']")));
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='spinner-wrap']")));
            return this;
        }
        public UploadFileBatchPage SelectSubFolderToSave()
        {
            SubFolderToSave.Click();
            SelectFromDD("li[class*='select2-results__option']", "SubFolderFromAutoTest");
            return this;
        }
        public UploadFileBatchPage ClickChooseFileButton()
        {
            ChooseFileButton.Click();
            Wait.Until(_driver => UploadFromWindow.Displayed);
            return this;
        }
        public UploadFileBatchPage ClickUploadButton()
        {
            UploadButton.Click();
            return this;
        }
        public UploadFileBatchPage WaitForPageUpload()
        {
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("gridLoader")));
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("gridLoader")));
            return this;
        }
    }
}
