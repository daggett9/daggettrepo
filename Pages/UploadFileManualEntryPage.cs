using Autotests.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using SeleniumExtras.WaitHelpers;

namespace Autotests.Pages
{
    class UploadFileManualEntryPage : PageObject
    {
        public UploadFileManualEntryPage(IWebDriver driver) : base(driver) { }

        public IWebElement DocumentName => _driver.FindElement(By.Id("documentName"));

        public IWebElement Description => _driver.FindElement(By.Id("description"));

        public IWebElement FolderToSave => _driver.FindElement(By.CssSelector("span#select2-folder-container+span"));

        public IWebElement SubFolderToSave => _driver.FindElement(By.CssSelector("span#select2-subFolder-container+span"));

        public IWebElement ChooseFileButton => _driver.FindElement(By.Id("chooseFile"));

        public IWebElement StartDate => _driver.FindElement(By.Id("startDate"));

        public IWebElement EndDate => _driver.FindElement(By.Id("endDate"));

        public IWebElement UploadButton => _driver.FindElement(By.Id("btnSubmit"));

        public IWebElement UploadFromWindow => _driver.FindElement(By.Id("uploadFileForm"));

        public IWebElement FilesContainer => _driver.FindElement(By.XPath("//div[@id='drop_file_zone']//input[@id='selectfile']"));

        public UploadFileManualEntryPage OpenUploadFilePage()
        {
            _driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/AssetManagement/UploadFile");
            return this;
        }
        public UploadFileManualEntryPage TypeDocumentName(string documentName)
        {
            DocumentName.SendKeys(documentName);
            return this;
        }
        public UploadFileManualEntryPage TypeDescription()
        {
            Description.SendKeys("ManualEntryfromAuto");
            return this;
        }
        public UploadFileManualEntryPage SelectFromDD(string CssSelector, string TextValueFromDD)
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
        public UploadFileManualEntryPage SelectParentFolderToSave()
        {
            FolderToSave.Click();
            SelectFromDD("li[class*='select2-results__option']", "ParentFolderFromAutoTest");
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='spinner-wrap']")));
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='spinner-wrap']")));
            return this;
        }
        public UploadFileManualEntryPage SelectSubFolderToSave()
        {
            SubFolderToSave.Click();
            SelectFromDD("li[class*='select2-results__option']", "SubFolderFromAutoTest");
            return this;
        }
        public UploadFileManualEntryPage TypeStartDate()
        {
            StartDate.SendKeys("03/01/2020");
            return this;
        }
        public UploadFileManualEntryPage TypeEndDate()
        {
            EndDate.SendKeys("03/04/2020");
            return this;
        }
        public UploadFileManualEntryPage ClickChooseFileButton()
        {
            ChooseFileButton.Click();
            Wait.Until(_driver => UploadFromWindow.Displayed);
            return this;
        }
        public UploadFileManualEntryPage ClickUploadButton()
        {
            UploadButton.Click();
            return this;
        }
        public UploadFileManualEntryPage WaitForPageUpload()
        {
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("gridLoader")));
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("gridLoader")));
            return this;
        }
    }
}
