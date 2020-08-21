using Autotests.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Autotests.Pages
{
    class PlantDocumentationDocumentsPage : PageObject
    {
        public PlantDocumentationDocumentsPage(IWebDriver driver) : base(driver) { }

        public IWebElement ManageFoldersButton => _driver.FindElement(By.Id("manageFolders"));
        public IWebElement UploadDocumentButton => _driver.FindElement(By.Id("uploadDocument"));
        public IWebElement SearchField => _driver.FindElement(By.XPath("//input[@id='documentSearch']"));
        public IWebElement DeleteIcon => _driver.FindElement(By.XPath("//div[@id='nav-documents']//button[@title='Delete']"));
        public IWebElement ConfirmDeleteButton => _driver.FindElement(By.XPath("//button[@onclick='confirmDelete()']"));
        public IWebElement JPGFileIcon => _driver.FindElement(By.XPath("//div[@id='nav-documents']//img[@src='/images/file-types/jpg.svg']"));
        public IWebElement DocumentsTable => _driver.FindElement(By.XPath("//div[@class='mt-4 grid-documents jsgrid']/div/table/tbody"));
        IList<IWebElement> TdCollection => DocumentsTable.FindElements(By.TagName("td"));
        //string strMyXPath = "//button[@value='@folderID']";
        public IWebElement ParentFolderButton => _driver.FindElement(By.XPath("//button[@value='@folderID']"));


        public PlantDocumentationDocumentsPage OpenPlantDocumentationDocumentsPage()
        {
            _driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/AssetManagement/PlantDocumentation#nav-documents");
            return this;
        }
        public PlantDocumentationDocumentsPage ClickSearchField()
        {
            SearchField.Click();
            return this;
        }
        public PlantDocumentationDocumentsPage TypeSearchRequest(string fileName)
        {
            SearchField.SendKeys(fileName);
            return this;
        }
        public PlantDocumentationDocumentsPage WaitForSearchExecution()
        {
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("gridLoader")));
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("gridLoader")));
            return this;
        }
        public PlantDocumentationDocumentsPage ClickJPGFileIcon()
        {
            JPGFileIcon.Click();
            return this;
        }
        public PlantDocumentationDocumentsPage WaitForFileDownload()
        {
            Thread.Sleep(10000);
            return this;
        }
        public bool CheckDownloadedFileExists(string DownloadedFilePath)
        {
            bool isFilePresent = false;
            string[] Files = Directory.GetFiles(DownloadsFolderPath);
            foreach (string file in Files)
            {
                if (File.Exists(DownloadedFilePath))
                {
                    isFilePresent = true;
                    break;
                }
            }
            return isFilePresent;
        }
        public PlantDocumentationDocumentsPage DeleteTheFile()
        {
            string[] Files = Directory.GetFiles(DownloadsFolderPath);
            foreach (string file in Files)
            {
                if (Files.Length == 1)
                    File.Delete(file);
            }
            return this;
        }
        public PlantDocumentationDocumentsPage ClickDeleteIcon()
        {
            DeleteIcon.Click();
            return this;
        }
        public PlantDocumentationDocumentsPage WaitForConfirmationWindow()
        {
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='confirmDelete']")));
            return this;
        }
        public PlantDocumentationDocumentsPage ClickConfirmDeleteButton()
        {
            ConfirmDeleteButton.Click();
            return this;
        }
        public bool CheckDocumentExistence(string documentName)
        {
            bool isFound = false;
            foreach (IWebElement td in TdCollection)
            {
                if (td.Text.Equals(documentName))
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }
        public bool CheckFolderExistence(string folderName)
        {
            bool isFound = false;
            foreach (IWebElement td in TdCollection)
            {
                if (td.Text.Equals(folderName))
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }
        public PlantDocumentationDocumentsPage ClickParentFolderButton(string FolderId)
        {
            _driver.FindElement(By.XPath("//button[@value='" + FolderId + "']")).Click();
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("manageFolders")));
            return this;
        }
    }
}
